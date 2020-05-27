/*
 * Copyright 2020 Alice Cash. All rights reserved.
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

namespace TopKey.Frames
{
    partial class ProcessConfigure
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
            this.components = new System.ComponentModel.Container();
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.Remove = new System.Windows.Forms.Button();
            this.FoundProcesses = new System.Windows.Forms.ComboBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.ProcessCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(12, 12);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(120, 95);
            this.ProcessList.TabIndex = 0;
            // 
            // Remove
            // 
            this.Remove.Location = new System.Drawing.Point(12, 113);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(120, 23);
            this.Remove.TabIndex = 1;
            this.Remove.Text = "PROCESS_CONFIGURE_REMOVE";
            this.Remove.UseVisualStyleBackColor = true;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // FoundProcesses
            // 
            this.FoundProcesses.DropDownWidth = 190;
            this.FoundProcesses.FormattingEnabled = true;
            this.FoundProcesses.Location = new System.Drawing.Point(12, 142);
            this.FoundProcesses.Name = "FoundProcesses";
            this.FoundProcesses.Size = new System.Drawing.Size(120, 21);
            this.FoundProcesses.TabIndex = 3;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(12, 169);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(120, 20);
            this.SearchText.TabIndex = 4;
            this.SearchText.Text = "wow";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(13, 195);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(120, 23);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "PROCESS_CONFIGURE_SEARCH";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(12, 224);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(120, 23);
            this.Add.TabIndex = 6;
            this.Add.Text = "PROCESS_CONFIGURE_ADD";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ProcessCheck
            // 
            this.ProcessCheck.Enabled = true;
            this.ProcessCheck.Tick += new System.EventHandler(this.ProcessCheck_Tick);
            // 
            // ProcessConfigure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(143, 256);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.FoundProcesses);
            this.Controls.Add(this.Remove);
            this.Controls.Add(this.ProcessList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProcessConfigure";
            this.ShowInTaskbar = false;
            this.Text = "PROCESS_CONFIGURE_TITLE";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessConfigure_FormClosing);
            this.Load += new System.EventHandler(this.ProcessConfigure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.ComboBox FoundProcesses;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Timer ProcessCheck;
    }
}