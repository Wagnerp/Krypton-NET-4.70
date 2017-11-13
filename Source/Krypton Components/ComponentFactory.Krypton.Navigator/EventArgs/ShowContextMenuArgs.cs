﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2017. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Version 4.5.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Navigator
{
	/// <summary>
	/// Details for a close button action event.
	/// </summary>
    public class ShowContextMenuArgs : KryptonPageCancelEventArgs
	{
		#region Instance Fields

	    #endregion

		#region Identity
		/// <summary>
        /// Initialize a new instance of the ShowContextMenuArgs class.
		/// </summary>
        /// <param name="page">Page effected by event.</param>
        /// <param name="index">Index of page in the owning collection.</param>
        public ShowContextMenuArgs(KryptonPage page, int index)
			: base(page, index)
		{
            ContextMenuStrip = page.ContextMenuStrip;
            KryptonContextMenu = page.KryptonContextMenu;
		}
		#endregion

        #region ContextMenuStrip
        /// <summary>
		/// Gets and sets the context menu strip.
		/// </summary>
        public ContextMenuStrip ContextMenuStrip { get; set; }

	    #endregion

        #region KryptonContextMenu
        /// <summary>
        /// Gets and sets the context menu strip.
        /// </summary>
        public KryptonContextMenu KryptonContextMenu { get; set; }

	    #endregion
    }
}