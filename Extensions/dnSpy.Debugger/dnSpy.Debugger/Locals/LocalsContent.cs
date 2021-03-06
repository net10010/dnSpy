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

using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using dnSpy.Contracts.Controls;
using dnSpy.Contracts.Themes;
using dnSpy.Contracts.Utilities;

namespace dnSpy.Debugger.Locals {
	interface ILocalsContent : IUIObjectProvider {
		void OnShow();
		void OnClose();
		void OnVisible();
		void OnHidden();
		void Focus();
		ListView ListView { get; }
		ILocalsVM LocalsVM { get; }
	}

	[Export(typeof(ILocalsContent))]
	sealed class LocalsContent : ILocalsContent {
		public object UIObject => localsControl;
		public IInputElement FocusedElement => localsControl.ListView;
		public FrameworkElement ScaleElement => localsControl;
		public ListView ListView => localsControl.ListView;
		public ILocalsVM LocalsVM => vmLocals;

		readonly LocalsControl localsControl;
		readonly ILocalsVM vmLocals;

		[ImportingConstructor]
		LocalsContent(IWpfCommandManager wpfCommandManager, IThemeManager themeManager, ILocalsVM localsVM) {
			this.localsControl = new LocalsControl();
			this.vmLocals = localsVM;
			this.localsControl.DataContext = this.vmLocals;
			themeManager.ThemeChanged += ThemeManager_ThemeChanged;

			wpfCommandManager.Add(CommandConstants.GUID_DEBUGGER_LOCALS_CONTROL, localsControl);
			wpfCommandManager.Add(CommandConstants.GUID_DEBUGGER_LOCALS_LISTVIEW, localsControl.ListView);
		}

		void ThemeManager_ThemeChanged(object sender, ThemeChangedEventArgs e) => vmLocals.RefreshThemeFields();
		public void Focus() => UIUtilities.FocusSelector(localsControl.ListView);
		public void OnClose() => vmLocals.IsEnabled = false;
		public void OnShow() => vmLocals.IsEnabled = true;
		public void OnHidden() => vmLocals.IsVisible = false;
		public void OnVisible() => vmLocals.IsVisible = true;
	}
}
