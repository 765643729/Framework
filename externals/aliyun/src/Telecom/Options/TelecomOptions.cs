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
 * This file is part of Zongsoft.Externals.Aliyun library.
 *
 * The Zongsoft.Externals.Aliyun is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License,
 * or (at your option) any later version.
 *
 * The Zongsoft.Externals.Aliyun is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Zongsoft.Externals.Aliyun library. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace Zongsoft.Externals.Aliyun.Telecom.Options
{
	/// <summary>
	/// 表示电信通讯相关的配置选项。
	/// </summary>
	public class TelecomOptions
	{
		#region 公共属性
		/// <summary>
		/// 获取或设置电信运营商区域。
		/// </summary>
		public ServiceCenterName? Region
		{
			get; set;
		}

		/// <summary>
		/// 获取或设置关联的凭证名。
		/// </summary>
		public string Certificate
		{
			get; set;
		}

		/// <summary>
		/// 获取电信短信服务配置。
		/// </summary>
		public TelecomMessageOption Message
		{
			get;
		}

		/// <summary>
		/// 获取电信语音服务配置。
		/// </summary>
		public TelecomVoiceOption Voice
		{
			get;
		}
		#endregion

		#region 嵌套子类
		/// <summary>
		/// 表示电信短信服务的配置选项。
		/// </summary>
		public class TelecomMessageOption
		{
			public TelecomMessageOption()
			{
				this.Templates = new TemplateOptionCollection();
			}

			/// <summary>
			/// 获取短信模板配置项集合。
			/// </summary>
			public Collections.INamedCollection<TemplateOption> Templates
			{
				get;
			}
		}

		/// <summary>
		/// 表示电信语音服务的配置选项。
		/// </summary>
		public class TelecomVoiceOption
		{
			public TelecomVoiceOption()
			{
				this.Templates = new TemplateOptionCollection();
			}

			/// <summary>
			/// 获取或设置语音号码数组。
			/// </summary>
			public string[] Numbers
			{
				get; set;
			}

			/// <summary>
			/// 获取语音模板配置项集合。
			/// </summary>
			public Collections.INamedCollection<TemplateOption> Templates
			{
				get;
			}
		}
		#endregion
	}
}
