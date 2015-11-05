﻿/*
    Copyright (C) 2014-2015 de4dot@gmail.com

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

using System;
using System.Windows;
using System.Windows.Controls;

namespace dnSpy.Contracts.ToolBars {
	/// <summary>
	/// ToolBar manager
	/// </summary>
	public interface IToolBarManager {
		/// <summary>
		/// Creates a <see cref="ToolBar"/>
		/// </summary>
		/// <param name="toolBarGuid">Guid of toolbar, eg. <see cref="ToolBarConstants.APP_TOOLBAR_GUID"/></param>
		/// <param name="commandTarget">Command target for toolbar items, eg. the owner window, or null</param>
		/// <returns></returns>
		ToolBar CreateToolBar(Guid toolBarGuid, IInputElement commandTarget);
	}
}