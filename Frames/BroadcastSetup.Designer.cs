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


namespace TopKey.Frames
{
    partial class BroadcastSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ExpandContract = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProfileList = new System.Windows.Forms.ComboBox();
            this.DeleteProfile = new System.Windows.Forms.Button();
            this.NewProfile = new System.Windows.Forms.Button();
            this.Move = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.Process = new System.Windows.Forms.Button();
            this.SaveAll = new System.Windows.Forms.Button();
            this.SetHotkey = new System.Windows.Forms.Button();
            this.keyboard1 = new TopKey.Frames.Keyboard_QWERT();
            this.borderwindowcontrol = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ExpandContract
            // 
            this.ExpandContract.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ExpandContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpandContract.Location = new System.Drawing.Point(0, 229);
            this.ExpandContract.Name = "ExpandContract";
            this.ExpandContract.Size = new System.Drawing.Size(858, 14);
            this.ExpandContract.TabIndex = 1;
            this.ExpandContract.Text = "vvvvvvvvvvvvvvvvvvvvv";
            this.ExpandContract.UseVisualStyleBackColor = true;
            this.ExpandContract.Click += new System.EventHandler(this.ExpandContract_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Click the keys to change their State.           keys are broadcasted.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(187, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Blue";
            // 
            // ProfileList
            // 
            this.ProfileList.FormattingEnabled = true;
            this.ProfileList.Location = new System.Drawing.Point(618, 178);
            this.ProfileList.Name = "ProfileList";
            this.ProfileList.Size = new System.Drawing.Size(228, 21);
            this.ProfileList.TabIndex = 4;
            this.ProfileList.SelectedIndexChanged += new System.EventHandler(this.ProfileList_SelectedIndexChanged);
            // 
            // DeleteProfile
            // 
            this.DeleteProfile.Location = new System.Drawing.Point(794, 200);
            this.DeleteProfile.Name = "DeleteProfile";
            this.DeleteProfile.Size = new System.Drawing.Size(52, 23);
            this.DeleteProfile.TabIndex = 5;
            this.DeleteProfile.Text = "Delete";
            this.DeleteProfile.UseVisualStyleBackColor = true;
            this.DeleteProfile.Click += new System.EventHandler(this.DeleteProfile_Click);
            // 
            // NewProfile
            // 
            this.NewProfile.Location = new System.Drawing.Point(676, 200);
            this.NewProfile.Name = "NewProfile";
            this.NewProfile.Size = new System.Drawing.Size(52, 23);
            this.NewProfile.TabIndex = 6;
            this.NewProfile.Text = "New";
            this.NewProfile.UseVisualStyleBackColor = true;
            this.NewProfile.Click += new System.EventHandler(this.NewProfile_Click);
            // 
            // Move
            // 
            this.Move.AutoSize = true;
            this.Move.Location = new System.Drawing.Point(768, 1);
            this.Move.Name = "Move";
            this.Move.Size = new System.Drawing.Size(46, 13);
            this.Move.TabIndex = 7;
            this.Move.Text = "<--------->";
            this.Move.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_MouseDown);
            this.Move.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_MouseMove);
            this.Move.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_MouseUp);
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.Red;
            this.Quit.FlatAppearance.BorderSize = 0;
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quit.Location = new System.Drawing.Point(826, 1);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(20, 17);
            this.Quit.TabIndex = 8;
            this.Quit.Text = "X";
            this.Quit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // Process
            // 
            this.Process.Location = new System.Drawing.Point(12, 200);
            this.Process.Name = "Process";
            this.Process.Size = new System.Drawing.Size(126, 23);
            this.Process.TabIndex = 9;
            this.Process.Text = "Configure Processes";
            this.Process.UseVisualStyleBackColor = true;
            this.Process.Click += new System.EventHandler(this.Process_Click);
            // 
            // SaveAll
            // 
            this.SaveAll.Location = new System.Drawing.Point(734, 200);
            this.SaveAll.Name = "SaveAll";
            this.SaveAll.Size = new System.Drawing.Size(54, 23);
            this.SaveAll.TabIndex = 10;
            this.SaveAll.Text = "Save All";
            this.SaveAll.UseVisualStyleBackColor = true;
            this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
            // 
            // SetHotkey
            // 
            this.SetHotkey.Location = new System.Drawing.Point(618, 200);
            this.SetHotkey.Name = "SetHotkey";
            this.SetHotkey.Size = new System.Drawing.Size(52, 23);
            this.SetHotkey.TabIndex = 11;
            this.SetHotkey.Text = "Hotkey";
            this.SetHotkey.UseVisualStyleBackColor = true;
            this.SetHotkey.Click += new System.EventHandler(this.SetHotkey_Click);
            // 
            // keyboard1
            // 
            this.keyboard1.Location = new System.Drawing.Point(12, 17);
            this.keyboard1.MaximumSize = new System.Drawing.Size(834, 155);
            this.keyboard1.MinimumSize = new System.Drawing.Size(834, 155);
            this.keyboard1.Name = "keyboard1";
            this.keyboard1.Size = new System.Drawing.Size(834, 155);
            this.keyboard1.TabIndex = 0;
            // 
            // borderwindowcontrol
            // 
            this.borderwindowcontrol.Location = new System.Drawing.Point(144, 200);
            this.borderwindowcontrol.Name = "borderwindowcontrol";
            this.borderwindowcontrol.Size = new System.Drawing.Size(126, 23);
            this.borderwindowcontrol.TabIndex = 12;
            this.borderwindowcontrol.Text = "Hide Borders";
            this.borderwindowcontrol.UseVisualStyleBackColor = true;
            this.borderwindowcontrol.Click += new System.EventHandler(this.button1_Click);
            // 
            // BroadcastSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 243);
            this.ControlBox = false;
            this.Controls.Add(this.borderwindowcontrol);
            this.Controls.Add(this.SetHotkey);
            this.Controls.Add(this.SaveAll);
            this.Controls.Add(this.Process);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Move);
            this.Controls.Add(this.NewProfile);
            this.Controls.Add(this.DeleteProfile);
            this.Controls.Add(this.ProfileList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExpandContract);
            this.Controls.Add(this.keyboard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(858, 243);
            this.MinimumSize = new System.Drawing.Size(858, 243);
            this.Name = "BroadcastSetup";
            this.Text = "BroadcastSetup";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BroadcastSetup_FormClosing);
            this.Load += new System.EventHandler(this.BroadcastSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Keyboard_QWERT keyboard1;
        private System.Windows.Forms.Button ExpandContract;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ProfileList;
        private System.Windows.Forms.Button DeleteProfile;
        private System.Windows.Forms.Button NewProfile;
        private System.Windows.Forms.Label Move;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.Button Process;
        private System.Windows.Forms.Button SaveAll;
        private System.Windows.Forms.Button SetHotkey;
        private System.Windows.Forms.Button borderwindowcontrol;

    }
}