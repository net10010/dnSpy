﻿/*
    Copyright (C) 2014-2016 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Windows;
using System.Windows.Media;

namespace dnSpy.Contracts.Themes {
	/// <summary>
	/// Text color
	/// </summary>
	public sealed class ThemeTextColor : IThemeTextColor {
		/// <summary>
		/// An instance with no foreground and background color
		/// </summary>
		public static readonly ThemeTextColor Null = new ThemeTextColor(null);

		/// <summary>
		/// Font weight or null
		/// </summary>
		public FontWeight? FontWeight { get; }

		/// <summary>
		/// Font style or null
		/// </summary>
		public FontStyle? FontStyle { get; }

		/// <summary>
		/// Foreground color or null
		/// </summary>
		public Brush Foreground { get; }

		/// <summary>
		/// Background color null
		/// </summary>
		public Brush Background { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="foreground">Foreground color or null</param>
		/// <param name="background">Background color or null</param>
		/// <param name="fontWeight">Font weight or null</param>
		/// <param name="fontStyle">Font style or null</param>
		public ThemeTextColor(Brush foreground, Brush background = null, FontWeight? fontWeight = null, FontStyle? fontStyle = null) {
			Foreground = foreground;
			Background = background;
			FontWeight = fontWeight;
			FontStyle = fontStyle;
		}
	}
}
