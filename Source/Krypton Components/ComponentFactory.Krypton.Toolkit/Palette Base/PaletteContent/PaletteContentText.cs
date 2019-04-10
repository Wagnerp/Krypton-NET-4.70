﻿// *****************************************************************************
// BSD 3-Clause License (https://github.com/ComponentFactory/Krypton/blob/master/LICENSE)
//  © Component Factory Pty Ltd, 2006-2019, All rights reserved.
// The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to license terms.
// 
//  Modifications by Peter Wagner(aka Wagnerp) & Simon Coghlan(aka Smurf-IV) 2017 - 2019. All rights reserved. (https://github.com/Wagnerp/Krypton-NET-5.470)
//  Version 5.470.0.0  www.ComponentFactory.com
// *****************************************************************************

using System.Drawing;
using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit
{
    /// <summary>
    /// Implement storage for palette content text details.
    /// </summary>
    public class PaletteContentText : Storage
    {
        #region Internal Classes
        private class InternalStorage
        {
            public Font ContentTextFont;
            public PaletteTextHint ContentTextHint;
            public PaletteTextTrim ContentTextTrim;
            public PaletteTextHotkeyPrefix ContentTextPrefix;
            public PaletteRelativeAlign ContentTextH;
            public PaletteRelativeAlign ContentTextV;
            public PaletteRelativeAlign ContentTextMultiLineH;
            public InheritBool ContentTextMultiLine;
            public Color ContentTextColor1;
            public Color ContentTextColor2;
            public PaletteColorStyle ContentTextColorStyle;
            public PaletteRectangleAlign ContentTextColorAlign;
            public float ContentTextColorAngle;
            public Image ContentTextImage;
            public PaletteImageStyle ContentTextImageStyle;
            public PaletteRectangleAlign ContentTextImageAlign;

            /// <summary>
            /// Initialize a new instance of the InternalStorage structure.
            /// </summary>
            public InternalStorage()
            {
                // Set to default values
                ContentTextHint = PaletteTextHint.Inherit;
                ContentTextTrim = PaletteTextTrim.Inherit;
                ContentTextPrefix = PaletteTextHotkeyPrefix.Inherit;
                ContentTextH = PaletteRelativeAlign.Inherit;
                ContentTextV = PaletteRelativeAlign.Inherit;
                ContentTextMultiLineH = PaletteRelativeAlign.Inherit;
                ContentTextMultiLine = InheritBool.Inherit;
                ContentTextColor1 = Color.Empty;
                ContentTextColor2 = Color.Empty;
                ContentTextColorStyle = PaletteColorStyle.Inherit;
                ContentTextColorAlign = PaletteRectangleAlign.Inherit;
                ContentTextColorAngle = -1;
                ContentTextImageStyle = PaletteImageStyle.Inherit;
                ContentTextImageAlign = PaletteRectangleAlign.Inherit;
            }

            /// <summary>
            /// Gets a value indicating if all values are default.
            /// </summary>
            public bool IsDefault => ((ContentTextFont == null) &&
                                      (ContentTextHint == PaletteTextHint.Inherit) &&
                                      (ContentTextTrim == PaletteTextTrim.Inherit) &&
                                      (ContentTextPrefix == PaletteTextHotkeyPrefix.Inherit) &&
                                      (ContentTextH == PaletteRelativeAlign.Inherit) &&
                                      (ContentTextV == PaletteRelativeAlign.Inherit) &&
                                      (ContentTextMultiLineH == PaletteRelativeAlign.Inherit) &&
                                      (ContentTextMultiLine == InheritBool.Inherit) &&
                                      (ContentTextColor1 == Color.Empty) &&
                                      (ContentTextColor2 == Color.Empty) &&
                                      (ContentTextColorStyle == PaletteColorStyle.Inherit) &&
                                      (ContentTextColorAlign == PaletteRectangleAlign.Inherit) &&
                                      (ContentTextColorAngle == -1) &&
                                      (ContentTextImage == null) &&
                                      (ContentTextImageStyle == PaletteImageStyle.Inherit) &&
                                      (ContentTextImageAlign == PaletteRectangleAlign.Inherit));
        }
        #endregion

        #region Instance Fields
        private InternalStorage _storage;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when a property has changed value.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the PaletteContentText class.
        /// </summary>
        /// <param name="needPaint">Delegate for notifying paint requests.</param>
        public PaletteContentText(NeedPaintHandler needPaint)
        {
            // Store the provided paint notification delegate
            NeedPaint = needPaint;
        }
        #endregion

        #region IsDefault
        /// <summary>
        /// Gets a value indicating if all values are default.
        /// </summary>
        [Browsable(false)]
        public override bool IsDefault => ((_storage == null) || _storage.IsDefault);

        #endregion

        #region Font
        /// <summary>
        /// Gets the font for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Font for drawing the content text.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Font Font
        {
            get => _storage?.ContentTextFont;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextFont != value)
                    {
                        _storage.ContentTextFont = value;
                        OnPropertyChanged("Font");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != null)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextFont = value
                        };
                        OnPropertyChanged("Font");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region Hint
        /// <summary>
        /// Gets the text rendering hint for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Text rendering hint for the content text.")]
        [DefaultValue(typeof(PaletteTextHint), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteTextHint Hint
        {
            get => _storage?.ContentTextHint ?? PaletteTextHint.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextHint != value)
                    {
                        _storage.ContentTextHint = value;
                        OnPropertyChanged("Hint");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteTextHint.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextHint = value
                        };
                        OnPropertyChanged("Hint");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region Trim
        /// <summary>
        /// Gets the text trimming for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Text trimming style for the content text.")]
        [DefaultValue(typeof(PaletteTextTrim), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteTextTrim Trim
        {
            get => _storage?.ContentTextTrim ?? PaletteTextTrim.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextTrim != value)
                    {
                        _storage.ContentTextTrim = value;
                        OnPropertyChanged("Trim");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteTextTrim.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextTrim = value
                        };
                        OnPropertyChanged("Trim");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region Prefix
        /// <summary>
        /// Gets the drawing used for prefix characters.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("How to draw prefix characters for the content text.")]
        [DefaultValue(typeof(PaletteTextHotkeyPrefix), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteTextHotkeyPrefix Prefix
        {
            get => _storage?.ContentTextPrefix ?? PaletteTextHotkeyPrefix.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextPrefix != value)
                    {
                        _storage.ContentTextPrefix = value;
                        OnPropertyChanged("Prefix");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteTextHotkeyPrefix.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextPrefix = value
                        };
                        OnPropertyChanged("Prefix");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion
        
        #region TextH
        /// <summary>
        /// Gets the horizontal relative alignment of the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Relative horizontal alignment of content text.")]
        [DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteRelativeAlign TextH
        {
            get => _storage?.ContentTextH ?? PaletteRelativeAlign.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextH != value)
                    {
                        _storage.ContentTextH = value;
                        OnPropertyChanged("TextH");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteRelativeAlign.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextH = value
                        };
                        OnPropertyChanged("TextH");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region TextV
        /// <summary>
        /// Gets the vertical relative alignment of the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Relative vertical alignment of content text.")]
        [DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteRelativeAlign TextV
        {
            get => _storage?.ContentTextV ?? PaletteRelativeAlign.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextV != value)
                    {
                        _storage.ContentTextV = value;
                        OnPropertyChanged("TextV");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteRelativeAlign.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextV = value
                        };
                        OnPropertyChanged("TextV");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region MultiLineH
        /// <summary>
        /// Gets the relative horizontal alignment of multiline content text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Relative horizontal alignment of multiline content text.")]
        [DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteRelativeAlign MultiLineH
        {
            get => _storage?.ContentTextMultiLineH ?? PaletteRelativeAlign.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextMultiLineH != value)
                    {
                        _storage.ContentTextMultiLineH = value;
                        OnPropertyChanged("MultiLineH");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != PaletteRelativeAlign.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextMultiLineH = value
                        };
                        OnPropertyChanged("MultiLineH");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region MultiLine
        /// <summary>
        /// Gets the flag indicating if multiline text is allowed.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Flag indicating if multiline text is allowed..")]
        [DefaultValue(typeof(InheritBool), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual InheritBool MultiLine
        {
            get => _storage?.ContentTextMultiLine ?? InheritBool.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextMultiLine != value)
                    {
                        _storage.ContentTextMultiLine = value;
                        OnPropertyChanged("MultiLine");
                        PerformNeedPaint(true);
                    }
                }
                else
                {
                    if (value != InheritBool.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextMultiLine = value
                        };
                        OnPropertyChanged("MultiLine");
                        PerformNeedPaint(true);
                    }
                }
            }
        }
        #endregion

        #region Color1
        /// <summary>
        /// Gets and sets the first color for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Main color for the text.")]
        [KryptonDefaultColorAttribute()]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Color Color1
        {
            get => _storage?.ContentTextColor1 ?? Color.Empty;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextColor1 != value)
                    {
                        _storage.ContentTextColor1 = value;
                        OnPropertyChanged("Color1");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != Color.Empty)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextColor1 = value
                        };
                        OnPropertyChanged("Color1");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region Color2
        /// <summary>
        /// Gets and sets the second color for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Secondary color for the text.")]
        [KryptonDefaultColorAttribute()]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Color Color2
        {
            get => _storage?.ContentTextColor2 ?? Color.Empty;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextColor2 != value)
                    {
                        _storage.ContentTextColor2 = value;
                        OnPropertyChanged("Color2");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != Color.Empty)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextColor2 = value
                        };
                        OnPropertyChanged("Color2");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region ColorStyle
        /// <summary>
        /// Gets and sets the color drawing style for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Color drawing style for the text.")]
        [DefaultValue(typeof(PaletteColorStyle), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteColorStyle ColorStyle
        {
            get => _storage?.ContentTextColorStyle ?? PaletteColorStyle.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextColorStyle != value)
                    {
                        _storage.ContentTextColorStyle = value;
                        OnPropertyChanged("ColorStyle");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != PaletteColorStyle.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextColorStyle = value
                        };
                        OnPropertyChanged("ColorStyle");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region ColorAlign
        /// <summary>
        /// Gets and set the color alignment for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Color alignment style for the text.")]
        [DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteRectangleAlign ColorAlign
        {
            get => _storage?.ContentTextColorAlign ?? PaletteRectangleAlign.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextColorAlign != value)
                    {
                        _storage.ContentTextColorAlign = value;
                        OnPropertyChanged("ColorAlign");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != PaletteRectangleAlign.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextColorAlign = value
                        };
                        OnPropertyChanged("ColorAlign");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region ColorAngle
        /// <summary>
        /// Gets and sets the color angle for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Color angle for the text.")]
        [DefaultValue(-1f)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual float ColorAngle
        {
            get
            {
                if (_storage == null)
                {
                    return -1f;
                }
                else
                {
                    return _storage.ContentTextColorAngle;
                }
            }

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextColorAngle != value)
                    {
                        _storage.ContentTextColorAngle = value;
                        OnPropertyChanged("ColorAngle");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != -1f)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextColorAngle = value
                        };
                        OnPropertyChanged("ColorAngle");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region Image
        /// <summary>
        /// Gets and sets the image for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image for the text.")]
        [DefaultValue(null)]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual Image Image
        {
            get => _storage?.ContentTextImage;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextImage != value)
                    {
                        _storage.ContentTextImage = value;
                        OnPropertyChanged("Image");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != null)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextImage = value
                        };
                        OnPropertyChanged("Image");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region ImageStyle
        /// <summary>
        /// Gets and sets the image style for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image style for the text.")]
        [DefaultValue(typeof(PaletteImageStyle), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteImageStyle ImageStyle
        {
            get => _storage?.ContentTextImageStyle ?? PaletteImageStyle.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextImageStyle != value)
                    {
                        _storage.ContentTextImageStyle = value;
                        OnPropertyChanged("ImageStyle");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != PaletteImageStyle.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextImageStyle = value
                        };
                        OnPropertyChanged("ImageStyle");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region ImageAlign
        /// <summary>
        /// Gets and set the image alignment for the text.
        /// </summary>
        [KryptonPersist(false)]
        [Category("Visuals")]
        [Description("Image alignment style for the text.")]
        [DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
        [RefreshPropertiesAttribute(RefreshProperties.All)]
        public virtual PaletteRectangleAlign ImageAlign
        {
            get => _storage?.ContentTextImageAlign ?? PaletteRectangleAlign.Inherit;

            set
            {
                if (_storage != null)
                {
                    if (_storage.ContentTextImageAlign != value)
                    {
                        _storage.ContentTextImageAlign = value;
                        OnPropertyChanged("ImageAlign");
                        PerformNeedPaint();
                    }
                }
                else
                {
                    if (value != PaletteRectangleAlign.Inherit)
                    {
                        _storage = new InternalStorage
                        {
                            ContentTextImageAlign = value
                        };
                        OnPropertyChanged("ImageAlign");
                        PerformNeedPaint();
                    }
                }
            }
        }
        #endregion

        #region Protected
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="property">Name of the property changed.</param>
        protected virtual void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
    }
}
