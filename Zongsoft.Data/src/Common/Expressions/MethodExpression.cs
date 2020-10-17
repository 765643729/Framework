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
 * This file is part of Zongsoft.Data library.
 *
 * The Zongsoft.Data is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3.0 of the License,
 * or (at your option) any later version.
 *
 * The Zongsoft.Data is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with the Zongsoft.Data library. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;

namespace Zongsoft.Data.Common.Expressions
{
	public class MethodExpression : Expression
	{
		#region 构造函数
		protected MethodExpression(string name, MethodType type, IList<IExpression> arguments = null)
		{
			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			this.Name = name.Trim();
			this.MethodType = type;
			this.Arguments = arguments;
		}
		#endregion

		#region 公共属性
		public string Name
		{
			get;
			set;
		}

		public string Alias
		{
			get;
			set;
		}

		public MethodType MethodType
		{
			get;
		}

		public IList<IExpression> Arguments
		{
			get;
		}
		#endregion

		#region 静态方法
		public static MethodExpression Function(string name, params IExpression[] arguments)
		{
			return new MethodExpression(name, MethodType.Function, arguments);
		}

		public static MethodExpression Procedure(string name, params IExpression[] arguments)
		{
			return new MethodExpression(name, MethodType.Procedure, arguments);
		}
		#endregion
	}
}
