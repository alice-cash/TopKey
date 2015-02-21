/*
 * Copyright 2010 Matthew Cash. All rights reserved.
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
 * THIS SOFTWARE IS PROVIDED BY Matthew Cash ``AS IS'' AND ANY EXPRESS OR IMPLIED
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
 * FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL Matthew Cash OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
 * CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 * The views and conclusions contained in the software and documentation are those of the
 * authors and should not be interpreted as representing official policies, either expressed
 * or implied, of Matthew Cash.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TopKey.Data;
using TopKey.Win32;

namespace TopKey.Frames
{
    public partial class Keyboard_QWERT : UserControl
    {

        private string ProfileName = "";

        public event EventHandler CheckChanged;
        private bool SettingProfile = false;

        public Keyboard_QWERT()
        {
            InitializeComponent();
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Keyboard_QWERT_Load(object sender, EventArgs e)
        {

        }

        public KeyboardProfile GetProfile()
        {
            KeyboardProfile Profile = new KeyboardProfile();
            List<Win32.Keys> TmpKeys = new List<Win32.Keys>();
            EnumConverter Con = new EnumConverter(typeof(Win32.Keys));

            foreach (Control k in this.Controls)
            {
                if (k.GetType() == typeof(CheckBox) && ((CheckBox)k).Checked && k.Enabled)
                {
                    TmpKeys.Add((Win32.Keys)Con.ConvertFromString(k.Name));
                }
            }

            Profile.SelectedKeys = TmpKeys.ToArray();
            Profile.Name = ProfileName;
            return Profile;
        }

        public void SetProfile(KeyboardProfile Profile, bool UseHotkey)
        {
            SettingProfile = true;
            EnumConverter Con = new EnumConverter(typeof(Win32.Keys));

            foreach (Control k in this.Controls)
            {
                if (k.GetType() == typeof(CheckBox) && k.Enabled)
                    ((CheckBox)k).Checked = false;
            }

            Win32.Keys[] KeyProfile;
            if (UseHotkey)
                KeyProfile = Profile.Hotkey;
            else
                KeyProfile = Profile.SelectedKeys;

            foreach (Control k in this.Controls)
            {
                if (k.GetType() == typeof(CheckBox) && k.Enabled && KeyProfile.Contains((Win32.Keys)Con.ConvertFromString(k.Name)))
                    ((CheckBox)k).Checked = true;
            }
            ProfileName = Profile.Name;
            SettingProfile = false;
            /*
            if (Profile.SelectedKeys != null)
            {
                
                foreach (Win32.Keys k in Profile.SelectedKeys)
                {
                    if (this.Controls.ContainsKey(Con.ConvertToString(k)))
                        ((CheckBox)this.Controls[k.ToString()]).Checked = true;
                }
            }*/

        }

        private void Key_CheckedChanged(object sender, EventArgs e)
        {
            if (!SettingProfile && CheckChanged != null)
                CheckChanged(sender, e);
        }


    }
}
