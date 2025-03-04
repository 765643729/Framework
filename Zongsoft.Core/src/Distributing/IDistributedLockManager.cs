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
using System.Threading;
using System.Threading.Tasks;

namespace Zongsoft.Distributing
{
	/// <summary>
	/// 提供分布式锁管理功能的接口。
	/// </summary>
	public interface IDistributedLockManager
	{
		/// <summary>获取或设置分布式锁的令牌规范器。</summary>
		IDistributedLockNormalizer Normalizer { get; set; }

		/// <summary>
		/// 获取一个指定标识的分布式锁。
		/// </summary>
		/// <param name="key">要获取的锁定标识。</param>
		/// <param name="duration">锁定的有效时长。</param>
		/// <param name="cancellation">异步操作的取消凭证。</param>
		/// <returns>如果获取成功则返回分布式锁对象，否则返回空(null)。</returns>
		ValueTask<IDistributedLock> AcquireAsync(string key, TimeSpan duration, CancellationToken cancellation = default);

		/// <summary>
		/// 释放指定的分布式锁。
		/// </summary>
		/// <param name="key">指定要释放的锁定标识。</param>
		/// <param name="token">指定要释放的锁令牌。</param>
		/// <param name="cancellation">异步操作的取消凭证。</param>
		/// <returns>如果释放成功则返回真(True)，否则返回假(False)。</returns>
		ValueTask<bool> ReleaseAsync(string key, ReadOnlyMemory<byte> token, CancellationToken cancellation = default);
	}
}
