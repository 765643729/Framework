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
using System.Linq;

namespace Zongsoft.Data
{
	public readonly struct Complex<T> : IEquatable<Complex<T>> where T : struct, IEquatable<T>, IComparable<T>
	{
		#region 构造函数
		public Complex(T value)
		{
			this.Array = null;
			this.Range = new Range<T>(value);
		}

		public Complex(T[] array)
		{
			this.Array = array;
			this.Range = default;
		}

		public Complex(Range<T> range)
		{
			this.Array = null;
			this.Range = range;
		}
		#endregion

		#region 公共属性
		public T Value { get => this.Range.Minimum.HasValue ? this.Range.Minimum.Value : default; }
		public readonly T[] Array;
		public readonly Range<T> Range;

		public bool HasValue => (this.Array != null && this.Array.Length > 0) || this.Range.HasValue;
		public bool IsEmpty => this.Array == null || this.Array.Length == 0 || this.Range.IsEmpty;
		#endregion

		#region 重写方法
		public bool Equals(Complex<T> other)
		{
			if(this.Array != null && this.Array.Length > 0)
			{
				if(other.Array == null || other.Array.Length != this.Array.Length)
					return false;

				for(int i = 0; i < this.Array.Length; i++)
				{
					if(!this.Array[i].Equals(other.Array[i]))
						return false;
				}

				return true;
			}

			return this.Range.Equals(other.Range);
		}
		public override bool Equals(object obj) => obj is Complex<T> other && this.Equals(other);

		public override int GetHashCode()
		{
			if(this.Array != null && this.Array.Length > 0)
			{
				var hashcode = new HashCode();

				for(int i = 0; i < this.Array.Length; i++)
					hashcode.Add(this.Array[i]);

				return hashcode.ToHashCode();
			}

			return this.Range.GetHashCode();
		}

		public override string ToString()
		{
			return this.Array != null && this.Array.Length > 0 ?
				string.Join(',', this.Array) :
				this.Range.ToString();
		}
		#endregion

		#region 解析方法
		public static bool TryParse(string text, out Complex<T> result)
		{
			if(Range<T>.TryParse(text, out var range))
				result = new Complex<T>(range);
			else
				result = new Complex<T>(Common.StringExtension.Slice<T>(text, ',', Common.Convert.TryConvertValue).ToArray());

			return result.HasValue;
		}
		#endregion

		#region 符号重写
		public static bool operator ==(Complex<T> left, Complex<T> right) => left.Equals(right);
		public static bool operator !=(Complex<T> left, Complex<T> right) => !(left == right);
		#endregion
	}

	public static class ComplexUtility
	{
		public static Condition ToCondition<T>(this Complex<T> complex, string name) where T : struct, IEquatable<T>, IComparable<T>
		{
			if(string.IsNullOrEmpty(name))
				throw new ArgumentNullException(nameof(name));

			if(complex.Array != null && complex.Array.Length > 0)
				return Condition.In(name, complex.Array);

			if(complex.Range.HasValue)
				return Condition.Between(name, complex.Range);

			return null;
		}
	}

	public class ComplexConverter<T> : IConditionConverter where T : struct, IEquatable<T>, IComparable<T>
	{
		public ICondition Convert(ConditionConverterContext context) => context.Value is Complex<T> complex ? complex.ToCondition(context.GetFullName()) : null;
	}
}
