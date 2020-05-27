/*
 * Copyright 2011 Alice Cash. All rights reserved.
 * 
 * Redistribution and use in source and binary forms, with or without modification, are
 * permitted provided that the following conditions are met:
 * 
 *    1. Redistributions of source code must retain the above copyright notice, this list of
 *       conditions and the following disclaimer.
 * 
 *    2. Redistributions in binary form must reproduce the above copyright notice, this list
 *       of conditions and the following disclaimer in the documentation and/or other materials
 *       provided with the distribution.
 * 
 * THIS SOFTWARE IS PROVIDED BY Alice Cash ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Alice Cash OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of Alice Cash.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TopKey.Frames
{
    public partial class Popup : Form
    {
        private Timer timer, timer2;
        private int startPosX;
        private int startPosY;

        public Popup(string ToastText)
        {
            InitializeComponent();

            label1.Text = ToastText;
        }

        void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Move window out of screen
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            SetDesktopLocation(startPosX, startPosY);
            base.OnLoad(e);

            Show();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += timer_Tick;
            timer2 = new Timer();
            timer2.Interval = 5000;
            timer2.Tick += timer2_Tick;

            timer.Start();
            timer2.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 5;
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
                timer.Stop();
            else
                SetDesktopLocation(startPosX, startPosY);
        }

        private void Popup_MouseMove(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
