using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopKey.Win32;

namespace TopKey.Hooks
{
    class KeyStateChangesArgs: EventArgs
    {
        public Keys[] PressedKeys;
        public KeyStateChangesArgs(Keys[] pK)
        {
            PressedKeys = pK;
        }
    }
}
