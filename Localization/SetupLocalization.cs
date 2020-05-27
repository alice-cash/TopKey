using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StormLib.Localization;

namespace TopKey.Localization
{
    static class SetupLocalization
    {
        public static void SetupForm(Form target)
        {
            foreach (Control control in target.Controls)
            {
                if (DefaultLanguage.Strings.ContainsName(control.Text))
                    control.Text = DefaultLanguage.Strings.GetString(control.Text);
            }
            if (DefaultLanguage.Strings.ContainsName(target.Text))
                target.Text = DefaultLanguage.Strings.GetString(target.Text);
        }
    }
}
