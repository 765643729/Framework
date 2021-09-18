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
using System.Collections.Generic;

namespace Zongsoft.Services
{
	/// <summary>
	/// 提供实现<see cref="ICommand"/>接口功能的基类，建议需要完成<see cref="ICommand"/>接口功能的实现者从此类继承。
	/// </summary>
	/// <typeparam name="TContext">指定命令的执行上下文类型。</typeparam>
	public abstract class CommandBase<TContext> : CommandBase, ICommand<TContext>, Components.IPredication<TContext> where TContext : CommandContext
	{
		#region 构造函数
		protected CommandBase() : base(null, true)
		{
		}

		protected CommandBase(string name) : base(name, true)
		{
		}

		protected CommandBase(string name, bool enabled) : base(name, enabled)
		{
		}
		#endregion

		#region 公共方法
		/// <summary>
		/// 判断命令是否可被执行。
		/// </summary>
		/// <param name="context">判断命令是否可被执行的上下文对象。</param>
		/// <returns>如果返回真(true)则表示命令可被执行，否则表示不可执行。</returns>
		/// <remarks>
		///		<para>本方法为虚拟方法，可由子类更改基类的默认实现方式。</para>
		///		<para>如果<seealso cref="CommandBase.Predication"/>属性为空(null)，则返回<seealso cref="CommandBase.Enabled"/>属性值；否则返回由<seealso cref="CommandBase.Predication"/>属性指定的断言对象的断言方法的值。</para>
		/// </remarks>
		public virtual bool CanExecute(TContext context)
		{
			return base.CanExecute(context);
		}

		/// <summary>
		/// 执行命令。
		/// </summary>
		/// <param name="context">执行命令的上下文对象。</param>
		/// <returns>返回执行的返回结果。</returns>
		/// <remarks>
		///		<para>本方法的实现中首先调用<seealso cref="CommandBase.CanExecute"/>方法，以确保阻止非法的调用。</para>
		/// </remarks>
		public object Execute(TContext context)
		{
			return base.Execute(context);
		}
		#endregion

		#region 抽象方法
		protected virtual TContext CreateContext(object parameter)
		{
			return parameter as TContext;
		}

		protected abstract object OnExecute(TContext context);
		#endregion

		#region 重写方法
		protected override bool CanExecute(object parameter)
		{
			var context = parameter as TContext;

			if(context == null)
				context = this.CreateContext(parameter);

			return this.CanExecute(context);
		}

		protected override object OnExecute(object parameter)
		{
			var context = parameter as TContext;

			if(context == null)
				context = this.CreateContext(parameter);

			//执行具体的命令操作
			return this.OnExecute(context);
		}
		#endregion

		#region 显式实现
		bool Components.IPredication<TContext>.Predicate(TContext context)
		{
			return this.CanExecute(context);
		}
		#endregion
	}
}
