﻿/*
 *   _____                                ______
 *  /_   /  ____  ____  ____  _________  / __/ /_
 *    / /  / __ \/ __ \/ __ \/ ___/ __ \/ /_/ __/
 *   / /__/ /_/ / / / / /_/ /\_ \/ /_/ / __/ /_
 *  /____/\____/_/ /_/\__  /____/\____/_/  \__/
 *                   /____/
 *
 * Authors:
 *   钟峰(Popeye Zhong) <zongsoft@gmail.com>
 *
 * Copyright (C) 2010-2020 Zongsoft Studio <http://www.zongsoft.com>
 *
 * This file is part of Zongsoft.Core library.
 *
 * The Zongsoft.Core is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License,
 * or (at your option) any later version.
 *
 * The Zongsoft.Core is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Zongsoft.Core library. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

using Zongsoft.Common;
using Zongsoft.Services;

namespace Zongsoft.Security.Membership
{
	public abstract class SecretAuthenticatorBase : IAuthenticator<string, string>
	{
		#region 构造函数
		protected SecretAuthenticatorBase() { }
		#endregion

		#region 公共属性
		public string Name => "Secret";

		[ServiceDependency]
		public IAttempter Attempter { get; set; }

		[ServiceDependency]
		public ISecretor Secretor { get; set; }
		#endregion

		#region 校验方法
		async ValueTask<OperationResult> IAuthenticator.VerifyAsync(string key, object data, string scenario, CancellationToken cancellation)
		{
			if(data == null)
				throw new ArgumentNullException(nameof(data));

			return await this.VerifyAsync(key, GetTicket(data), scenario, cancellation);
		}

		public async ValueTask<OperationResult<string>> VerifyAsync(string key, string data, string scenario, CancellationToken cancellation = default)
		{
			if(string.IsNullOrEmpty(data))
				return OperationResult.Fail("InvalidToken");

			var index = data.IndexOfAny(new[] { ':', '=' });

			if(index <= 0 || index >= data.Length - 1)
				return OperationResult.Fail(SecurityReasons.InvalidArgument, $"Illegal identity verification token format.");

			var identifier = data.Substring(0, index);
			var secret = data.Substring(index + 1);

			//获取验证失败的解决器
			var attempter = this.Attempter;

			//确认验证失败是否超出限制数，如果超出则返回账号被禁用
			if(attempter != null && !attempter.Verify(key))
				return OperationResult.Fail(SecurityReasons.AccountSuspended);

			if(!this.Secretor.Verify(key, secret, out var extra))
			{
				//通知验证尝试失败
				if(attempter != null)
					attempter.Fail(key);

				return OperationResult.Fail(SecurityReasons.VerifyFaild);
			}

			//通知验证尝试成功，即清空验证失败记录
			if(attempter != null)
				attempter.Done(key);

			return (string.IsNullOrEmpty(extra) && string.IsNullOrEmpty(identifier)) || string.Equals(identifier, extra, StringComparison.OrdinalIgnoreCase) ?
				OperationResult.Success(extra) :
				OperationResult.Fail(SecurityReasons.VerifyFaild, $"Identity verification data is inconsistent.");
		}
		#endregion

		#region 身份签发
		ValueTask<ClaimsIdentity> IAuthenticator.IssueAsync(object identifier, string scenario, IDictionary<string, object> parameters, CancellationToken cancellation)
		{
			return identifier == null ? ValueTask.FromResult<ClaimsIdentity>(null) : this.IssueAsync(identifier.ToString(), scenario, parameters, cancellation);
		}

		public ValueTask<ClaimsIdentity> IssueAsync(string identifier, string scenario, IDictionary<string, object> parameters, CancellationToken cancellation = default)
		{
			if(string.IsNullOrEmpty(identifier))
				throw new ArgumentNullException(nameof(identifier));

			//从数据库中获取指定身份的用户对象
			var user = this.GetUser(identifier);

			if(user == null)
				return ValueTask.FromResult<ClaimsIdentity>(null);

			return ValueTask.FromResult(this.Identity(user, scenario));
		}
		#endregion

		#region 虚拟方法
		protected virtual TimeSpan GetPeriod(string scenario) => TimeSpan.FromHours(2);
		protected virtual ClaimsIdentity Identity(IUser user, string scenario) => user.Identity(this.Name, this.Name, this.GetPeriod(scenario));
		protected abstract IUser GetUser(string identifier);
		#endregion

		#region 私有方法
		private static string GetTicket(object data)
		{
			if(data is string text)
				return text;

			if(data is byte[] bytes)
				return Encoding.UTF8.GetString(bytes);

			if(data is Stream stream)
			{
				using var reader = new StreamReader(stream, Encoding.UTF8);
				return reader.ReadToEnd();
			}

			throw new InvalidOperationException($"The identity verification data type '{data.GetType().FullName}' is not supported.");
		}
		#endregion
	}
}
