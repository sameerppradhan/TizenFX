/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace ElmSharp
{
    /// <summary>
    /// The FloatingButton is a widget that to add floating area for buttons.
    /// </summary>
    public class FloatingButton : Layout
    {
        /// <summary>
        /// Creates and initializes a new instance of the FloatingButton class.
        /// </summary>
        /// <param name="parent">Created on this parent container..</param>
        public FloatingButton(EvasObject parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets or gets floatingbutton mode.
        /// </summary>
        public FloatingButtonMode Mode
        {
            get
            {
                return (FloatingButtonMode)Interop.Eext.eext_floatingbutton_mode_get(Handle);
            }
            set
            {
                Interop.Eext.eext_floatingbutton_mode_set(Handle, (int)value);
            }
        }

        /// <summary>
        /// Gets floatingbutton Position.
        /// </summary>
        public FloatingButtonPosition Position
        {
            get
            {
                return (FloatingButtonPosition)Interop.Eext.eext_floatingbutton_pos_get(Handle);
            }
        }

        /// <summary>
        /// Sets or gets movability for a given floatingbutton widget.
        /// </summary>
        public bool MovementBlock
        {
            get
            {
                return Interop.Eext.eext_floatingbutton_movement_block_get(Handle);
            }
            set
            {
                Interop.Eext.eext_floatingbutton_movement_block_set(Handle, value);
            }
        }

        /// <summary>
        /// Get Opacity's value of the given FloatingButton.
        /// </summary>
        public override int Opacity
        {
            get
            {
                return Color.Default.A;
            }

            set
            {
                Console.WriteLine("FloatingButton instance doesn't support to set Opacity.");
            }
        }

        /// <summary>
        /// Set the floatingbutton position with animation or not.
        /// </summary>
        /// <param name="position">Button position</param>
        /// <param name="animated">Animat flag</param>
        public void SetPosition(FloatingButtonPosition position, bool animated)
        {
            if (animated)
            {
                Interop.Eext.eext_floatingbutton_pos_bring_in(Handle, (int)position);
            }
            else
            {
                Interop.Eext.eext_floatingbutton_pos_set(Handle, (int)position);
            }
        }

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Eext.eext_floatingbutton_add(parent.Handle);
        }
    }

    /// <summary>
    /// Enumeration for FloatingButtonMode
    /// </summary>
    public enum FloatingButtonMode
    {
        /// <summary>
        /// Allows all positions
        /// </summary>
        All,

        /// <summary>
        /// Allows LEFT and RIGHT positions only
        /// </summary>
        LeftRightOnly,
    }

    /// <summary>
    /// Enumeration for FloatingButtonPosition
    /// </summary>
    public enum FloatingButtonPosition
    {
        /// <summary>
        /// Hides in the left, but small handler will show only
        /// </summary>
        LeftOut,

        /// <summary>
        /// Shows all of buttons, but lies on the left
        /// </summary>
        Left,

        /// <summary>
        /// Shows all of buttons, but lies on the center
        /// </summary>
        Center,

        /// <summary>
        /// Shows all of buttons, but lies on the right
        /// </summary>
        Right,

        /// <summary>
        /// Hides in the right, but small handler will show only
        /// </summary>
        RightOut,
    }
}