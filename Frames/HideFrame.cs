using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using TopKey.Win32;
using TopKey.Data;
using TopKey.Localization;

namespace TopKey.Frames
{
    public partial class HideFrame : Form
    {
        public HideFrame()
        {
            InitializeComponent();
            SetupLocalization.SetupForm(this);
        }

        public static void HideBorder(Process proc)
        {
            int lStyle = DllImports.GetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE);
            //lStyle &= ~((int)WindowStyles.WS_BORDER | (int)WindowStyles.WS_THICKFRAME | (int)WindowStyles.WS_DLGFRAME);
            lStyle &= ~((int)WindowStyles.WS_THICKFRAME);
            DllImports.SetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE, lStyle);

            //int lExStyle = DllImports.GetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_EXSTYLE);
            //lExStyle &= ~((int)WindowStyles.WS_EX_DLGMODALFRAME | (int)WindowStyles.WS_EX_CLIENTEDGE | (int)WindowStyles.WS_EX_STATICEDGE);
            //DllImports.SetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_EXSTYLE, lExStyle);

        }
        public static void ShowBorder(Process proc)
        {
            int lStyle = DllImports.GetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE);
            //lStyle |= ((int)WindowStyles.WS_BORDER | (int)WindowStyles.WS_THICKFRAME | (int)WindowStyles.WS_DLGFRAME);
            lStyle |= ((int)WindowStyles.WS_THICKFRAME);
            DllImports.SetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE, lStyle);

            //int lExStyle = DllImports.GetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_EXSTYLE);
            //lExStyle |= ((int)WindowStyles.WS_EX_DLGMODALFRAME | (int)WindowStyles.WS_EX_CLIENTEDGE | (int)WindowStyles.WS_EX_STATICEDGE);
            //DllImports.SetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_EXSTYLE, lExStyle);

        }

        public static bool IsHidden(Process proc)
        {
            int style = DllImports.GetWindowLong(proc.MainWindowHandle, (int)WindowLongFlags.GWL_STYLE);
            int test = style | ~((int)WindowStyles.WS_CAPTION | (int)WindowStyles.WS_SYSMENU | (int)WindowStyles.WS_THICKFRAME);
            return (test != -1);
        }

        private void HideFrame_Load(object sender, EventArgs e)
        {
            BroadcastSetup.Info.ProcessListChanged += new EventHandler(Info_ProcessListChanged);
        }

        void Info_ProcessListChanged(object sender, EventArgs e)
        {
            ProcessList.Items.Clear();
            foreach (ProcessInfo P in BroadcastSetup.Info.SelectedProcess)
            {
                ProcessList.Items.Add(P);
            }

            
        }

        private void ProcessList_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedIndex == -1) return;
            if (IsHidden(((ProcessInfo)ProcessList.SelectedItem)))
                ShowBorder(((ProcessInfo)ProcessList.SelectedItem));
            else
                HideBorder(((ProcessInfo)ProcessList.SelectedItem));
        }

        private void HideFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
