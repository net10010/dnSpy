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

using System.ComponentModel.Composition;
using System.Windows.Input;
using dnSpy.Contracts.Controls;
using dnSpy.Contracts.Files.Tabs;
using dnSpy.Contracts.Files.Tabs.TextEditor;
using dnSpy.Contracts.Languages;
using dnSpy.Contracts.Menus;
using dnSpy.Contracts.Themes;
using dnSpy.Files.Tabs.TextEditor.ToolTips;

namespace dnSpy.Files.Tabs.TextEditor {
	[ExportFileTabUIContextCreator(Order = TabsConstants.ORDER_TEXTEDITORUICONTEXTCREATOR)]
	sealed class TextEditorUIContextCreator : IFileTabUIContextCreator {
		readonly IThemeManager themeManager;
		readonly IWpfCommandManager wpfCommandManager;
		readonly IMenuManager menuManager;
		readonly ICodeToolTipManager codeToolTipManager;

		[ImportingConstructor]
		TextEditorUIContextCreator(IThemeManager themeManager, IWpfCommandManager wpfCommandManager, IMenuManager menuManager, ICodeToolTipManager codeToolTipManager) {
			this.themeManager = themeManager;
			this.wpfCommandManager = wpfCommandManager;
			this.menuManager = menuManager;
			this.codeToolTipManager = codeToolTipManager;
		}

		public IFileTabUIContext Create<T>() where T : class, IFileTabUIContext {
			if (typeof(T) == typeof(ITextEditorUIContext)) {
				var ttRefFinder = new ToolTipReferenceFinder();
				var tec = new TextEditorControl(themeManager, new ToolTipHelper(codeToolTipManager, ttRefFinder));
				var uiContext = new TextEditorUIContext(wpfCommandManager, menuManager, tec);
				ttRefFinder.UIContext = uiContext;
				return uiContext;
			}
			return null;
		}

		sealed class ToolTipReferenceFinder : IToolTipReferenceFinder {
			public TextEditorUIContext UIContext { get; set; }

			public ReferenceInfo? GetReference(MouseEventArgs e) {
				if (UIContext == null)
					return null;

				var @ref = UIContext.GetReferenceSegmentAt(e);
				if (@ref == null)
					return null;

				var lang = GetLanguage();
				if (lang == null)
					return null;

				return new ReferenceInfo(lang, @ref);
			}

			ILanguage GetLanguage() {
				if (UIContext == null)
					return null;
				var content = UIContext.FileTab.Content as ILanguageTabContent;
				return content == null ? null : content.Language;
			}
		}
	}
}