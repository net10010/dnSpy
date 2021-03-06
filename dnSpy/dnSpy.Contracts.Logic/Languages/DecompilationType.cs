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

namespace dnSpy.Contracts.Languages {
	/// <summary>
	/// Decompilation type
	/// </summary>
	public enum DecompilationType {
		/// <summary>
		/// Decompiles a partial type, data is a <see cref="DecompilePartialType"/> instance
		/// </summary>
		PartialType,

		/// <summary>
		/// Decompiles AssemblyInfo.{cs,vb}, data is a <see cref="DecompileAssemblyInfo"/> instance
		/// </summary>
		AssemblyInfo,

		/// <summary>
		/// Decompiles selected methods, the other ones have empty bodies, data is a <see cref="DecompileTypeMethods"/>
		/// </summary>
		TypeMethods,
	}
}
