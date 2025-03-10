﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using static Interop;

namespace System.Windows.Forms
{
    public abstract partial class UpDownBase
    {
        internal partial class UpDownEdit
        {
            internal class UpDownEditAccessibleObject : ControlAccessibleObject
            {
                private readonly UpDownEdit _owningUpDownEdit;
                private readonly TextBoxBaseUiaTextProvider _textProvider;
                private readonly UpDownBase _parent;

                public UpDownEditAccessibleObject(UpDownEdit owner, UpDownBase parent) : base(owner)
                {
                    _parent = parent.OrThrowIfNull();
                    _owningUpDownEdit = owner;
                    _textProvider = new TextBoxBaseUiaTextProvider(owner);
                    UseTextProviders(_textProvider, _textProvider);
                }

                internal override bool IsIAccessibleExSupported() => true;

                public override string? Name
                {
                    get => _parent.AccessibilityObject.Name
                        ?? _parent switch
                        {
                            NumericUpDown _ => SR.EditDefaultAccessibleName,
                            DomainUpDown _ => SR.EditDefaultAccessibleName,
                            _ => null
                        };
                    set => _parent.AccessibilityObject.Name = value;
                }

                public override string? KeyboardShortcut => _parent.AccessibilityObject.KeyboardShortcut;

                internal override bool IsPatternSupported(UiaCore.UIA patternId)
                    => patternId switch
                    {
                        UiaCore.UIA.TextPatternId => true,
                        UiaCore.UIA.TextPattern2Id => true,
                        _ => base.IsPatternSupported(patternId)
                    };

                internal override bool IsReadOnly => _owningUpDownEdit.ReadOnly;
            }
        }
    }
}
