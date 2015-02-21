namespace TopKey.Frames
{
    partial class HideFrame
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
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.Location = new System.Drawing.Point(12, 12);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(153, 199);
            this.ProcessList.TabIndex = 0;
            this.ProcessList.Click += new System.EventHandler(this.ProcessList_Click);
            // 
            // HideFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 227);
            this.Controls.Add(this.ProcessList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HideFrame";
            this.ShowInTaskbar = false;
            this.Text = "HideFrame";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HideFrame_FormClosing);
            this.Load += new System.EventHandler(this.HideFrame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ProcessList;
    }
}