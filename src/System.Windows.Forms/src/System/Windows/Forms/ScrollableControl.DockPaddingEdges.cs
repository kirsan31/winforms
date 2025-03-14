﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel;

namespace System.Windows.Forms
{
    public partial class ScrollableControl
    {
        public class DockPaddingEdgesConverter : TypeConverter
        {
            /// <summary>
            ///  Retrieves the set of properties for this type. By default, a type has does
            ///  not return any properties. An easy implementation of this method can just
            ///  call TypeDescriptor.GetProperties for the correct data type.
            /// </summary>
            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(DockPaddingEdges), attributes);
                return props.Sort(new string[] { "All", "Left", "Top", "Right", "Bottom" });
            }

            /// <summary>
            ///  Determines if this object supports properties. By default, this is false.
            /// </summary>
            public override bool GetPropertiesSupported(ITypeDescriptorContext? context) => true;
        }
    }
}
