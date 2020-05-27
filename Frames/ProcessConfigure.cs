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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TopKey.Data;

using TopKey.Localization;

namespace TopKey.Frames
{
    public partial class ProcessConfigure : Form
    {
        public event EventHandler ProcessListChanged;

        public IEnumerable<object> SelectedProcess
        {
            get { return ProcessList.Items.Cast<object>(); }
        }

        public ProcessConfigure()
        {
            InitializeComponent();
            SetupLocalization.SetupForm(this);
        }

        private void ProcessConfigure_Load(object sender, EventArgs e)
        {
            DoSearch();
        }

        private void ProcessConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedItem != null)
            {
                ProcessList.Items.Remove(ProcessList.SelectedItem);
                FireProcessListChanged();
                 
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            FoundProcesses.Items.Clear();
            DoSearch();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (FoundProcesses.SelectedItem != null)
            {
                ProcessList.Items.Add(FoundProcesses.SelectedItem);
                FireProcessListChanged();
            }
        }


        private void DoSearch()
        {
            foreach (var p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.ToLower().Contains(SearchText.Text.ToLower()) ||
                    p.ProcessName.ToLower().Contains(SearchText.Text.ToLower()))
                {
                    FoundProcesses.Items.Add((ProcessInfo)p);
                }
            }
        }

        private void ProcessCheck_Tick(object sender, EventArgs e)
        {
            bool Removed = false;
            for(int i = 0; i < ProcessList.Items.Count; i++)
            {
                if (((ProcessInfo)ProcessList.Items[i]).ThisProcess.HasExited)
                {
                    ProcessList.Items.RemoveAt(i);
                    Removed = true;
                }
            }
            if (Removed)
            {
                FireProcessListChanged();
            }

        }

        private void FireProcessListChanged()
        {
            if (ProcessListChanged != null)
                ProcessListChanged(this, EventArgs.Empty);
        }
    }
}
