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
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

using TopKey.Data;
using TopKey.Hooks;

namespace TopKey.Frames
{
    public partial class BroadcastSetup : Form
    {

        private bool Contracted = true;
        private Point LastMousePos;
        private bool MouseDown = false;

        static ProcessConfigure Info;

        private List<KeyboardProfile> Profiles;
        //static ProcessHooks Hooks;


        public BroadcastSetup()
        {
            InitializeComponent();
        }


        private void BroadcastSetup_Load(object sender, EventArgs e)
        {
            this.Top = -(this.Height) + this.ExpandContract.Height;
            Contracted = false;
            this.ExpandContract.Text = "vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv";
            Profiles = new List<KeyboardProfile>();
            LoadProfiles();

            this.keyboard1.CheckChanged += new EventHandler(keyboard1_CheckChanged);

            Info = new ProcessConfigure();
            Info.ProcessListChanged += new EventHandler(Info_ProcessListChanged);
            Info.Show();
            ProcessHooks.init(Info.SelectedProcess, Profiles[ProfileList.SelectedIndex]);

            this.TopMost = false;
            this.TopMost = true;
        }

        void Info_ProcessListChanged(object sender, EventArgs e)
        {
            ProcessHooks.UpdateProcessList(Info.SelectedProcess);
        }

        void keyboard1_CheckChanged(object sender, EventArgs e)
        {
            if (ProfileList.SelectedIndex == -1)
                return;

            KeyboardProfile TmpKP = keyboard1.GetProfile();
            Profiles[ProfileList.SelectedIndex].SelectedKeys = TmpKP.SelectedKeys;
            ProcessHooks.ChangeProfile(Profiles[ProfileList.SelectedIndex]);
        }

        private void NewProfile_Click(object sender, EventArgs e)
        {
            Input NewName = new Input();
            KeyboardProfile KP = new KeyboardProfile();
            if (NewName.ShowDialog("Please enter a name.") == System.Windows.Forms.DialogResult.OK)
            {
                foreach (char c in Path.GetInvalidPathChars())
                {
                    if (NewName.Value.Contains(c))
                    {
                        MessageBox.Show(string.Format("Name must not contain any of the following characters: {0}", Path.GetInvalidPathChars()));
                        return;
                    }
                }
                KP.Name = NewName.Value;
                KP.SelectedKeys = new Win32.Keys[0];
                Profiles.Add(KP);
                ProfileList.Items.Add(KP);
                ProfileList.SelectedItem = KP;
                ProcessHooks.ChangeProfile(KP);
            }
        }

        private void BroadcastSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveProfiles();
        }

        public void SaveProfiles()
        {
            if (!Directory.Exists(@"./Profiles/"))
            {
                Directory.CreateDirectory(@"./Profiles/");
            }

            foreach (KeyboardProfile KP in ProfileList.Items)
            {
                using (Stream stream = File.Open(string.Format(@"./Profiles/{0}.xml", KP.Name), FileMode.Create))
                {
                    XmlSerializer bin = new XmlSerializer(typeof(KeyboardProfile));
                    bin.Serialize(stream, KP);
                    stream.Close();
                }
            }
        }

        public void LoadProfiles()
        {
            if (!Directory.Exists(@"./Profiles/"))
            {
                try
                {
                    Directory.CreateDirectory(@"./Profiles/");
                    SaveDefault();
                }
                catch (IOException)
                {
                    MessageBox.Show("There is a possible file/folder permission error. Please check the read/write permission of the sub folder 'Profiles'.");
                }
            }
            KeyboardProfile KP;
            foreach (string Profile in Directory.GetFiles(@"./Profiles/"))
            {
                XmlReader stream = XmlReader.Create(File.Open(Profile, FileMode.Open));

                XmlSerializer bin = new XmlSerializer(typeof(KeyboardProfile));
                if (bin.CanDeserialize(stream))
                {
                    KP = (KeyboardProfile)bin.Deserialize(stream);
                    Profiles.Add(KP);
                    ProfileList.Items.Add(KP);
                }

                stream.Close();

            }

            if (Profiles.Count == 0)
            {
                SaveDefault();
                try
                {
                    XmlReader stream = XmlReader.Create(File.Open(@"./Profiles/_DEFAULT.xml", FileMode.Open));
                    XmlSerializer bin = new XmlSerializer(typeof(KeyboardProfile));
                    if (bin.CanDeserialize(stream))
                    {
                        KP = (KeyboardProfile)bin.Deserialize(stream);
                        Profiles.Add(KP);
                        ProfileList.Items.Add(KP);
                    }
                    else
                    {
                        KP = new KeyboardProfile();
                        KP.Name = "Blank";
                        MessageBox.Show("There was an error loading the default key profile. If you see this message repeadly, then there is an error with the default profile template or file permission error.", "Error!");
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("There is a possible file/folder permission error. Please check the read/write permission of the sub folder 'Profiles'.");
                    KP = new KeyboardProfile();
                    KP.Name = "_DEFAULT";
                    Profiles.Add(KP);
                    ProfileList.Items.Add(KP);
                }
                
            }

            foreach (var item in ProfileList.Items)
            {
                if (item is KeyboardProfile)
                {
                    if (((KeyboardProfile)item).Name == "_DEFAULT")
                    {
                        ProfileList.SelectedItem = item;
                        break;
                    }
                }
            }


            keyboard1.SetProfile(Profiles[ProfileList.SelectedIndex]);
            ProcessHooks.ChangeProfile(Profiles[ProfileList.SelectedIndex]);

        }

        private void SaveDefault()
        {
            File.WriteAllText(@"./Profiles/_DEFAULT.xml", Properties.Resources._DEFAULT);
        }

        private void ExpandContract_Click(object sender, EventArgs e)
        {
            if (Contracted)
            {
                this.Top = -(this.Height) + this.ExpandContract.Height;
                Contracted = false;
                this.ExpandContract.Text = "vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv";
            }
            else
            {
                this.Top = 0;
                Contracted = true;
                this.ExpandContract.Text = "^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
            }
        }

        private void Move_MouseMove(object sender, MouseEventArgs e)
        {
            Point NowPos;
            int Diff;
            if (MouseDown)
            {
                NowPos = Cursor.Position;
                Diff = NowPos.X - LastMousePos.X;
                LastMousePos = Cursor.Position;

                if (this.Left + Diff < 0)
                {
                    this.Left = 0;
                }
                else if (this.Left + Diff > Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                {
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                }
                else
                {
                    this.Left += Diff;
                }

            }
        }

        private void Move_MouseDown(object sender, MouseEventArgs e)
        {
            LastMousePos = Cursor.Position;
            MouseDown = true;
        }

        private void Move_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void ProfileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProfileList.SelectedIndex != -1)
            {
                keyboard1.SetProfile(Profiles[ProfileList.SelectedIndex]);
                ProcessHooks.ChangeProfile(Profiles[ProfileList.SelectedIndex]);
            }
        }

        private void DeleteProfile_Click(object sender, EventArgs e)
        {
            if (Profiles.Count == 1)
            {
                MessageBox.Show("You cannot delete the last profile!");
                return;
            }
            if (MessageBox.Show("Are you sure? This cannot be undone!", "DELETE CONFERM", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ProfileList.SelectedIndex != -1)
                {
                    if (File.Exists(string.Format(@"./Profiles/{0}.xml", (Profiles[ProfileList.SelectedIndex]).Name)))
                    {
                        File.Delete(string.Format(@"./Profiles/{0}.xml", (Profiles[ProfileList.SelectedIndex]).Name));
                    }

                    Profiles.RemoveAt(ProfileList.SelectedIndex);
                    ProfileList.Items.RemoveAt(ProfileList.SelectedIndex);
                    if (ProfileList.Items.Count > 0)
                    {
                        ProfileList.SelectedIndex = 0;
                        keyboard1.SetProfile(Profiles[ProfileList.SelectedIndex]);
                        ProcessHooks.ChangeProfile(Profiles[ProfileList.SelectedIndex]);

                    }
                    else
                    {
                        ProcessHooks.ChangeProfile(null);
                    }

                }
            }
        }

        private void Process_Click(object sender, EventArgs e)
        {
            Info.Show();
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            SaveProfiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }




    }
}
