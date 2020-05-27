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
using System.Diagnostics;
using System.Linq;

using TopKey.Data;
using TopKey.Win32;
using StormLib.Localization;

namespace TopKey.Hooks
{
    static class ProcessHooks
    {
        static IEnumerable<object> ProcessList;
        static KeyboardHook KH;
        static KeyboardProfile CurrentProfile;
        static List<Keys> PressedKeys = new List<Keys>();

        public static event EventHandler<KeyStateChangesArgs> KeyStateChanged;

        public static void init(IEnumerable<object> NewProcessList, KeyboardProfile KP)
        {
            ProcessList = NewProcessList;
            KH = new KeyboardHook(KeyboardHook.Parameters.PassAllKeysToNextApp);
            KH.KeyIntercepted += new KeyboardHook.KeyboardHookEventHandler(KH_KeyIntercepted);

            CurrentProfile = KP;
        }

        public static void ChangeProfile(KeyboardProfile KP)
        {
            CurrentProfile = KP;
        }

        public static void UpdateProcessList(IEnumerable<object> NewProcessList)
        {
            ProcessList = NewProcessList;
        }

        static void KH_KeyIntercepted(KeyboardHook.KeyboardHookEventArgs e)
        {

            //IntPtr hWnd;
            IntPtr ActiveWindow = WindowIsActive();
            if (CurrentProfile != null && CurrentProfile.SelectedKeys != null && ActiveWindow != IntPtr.Zero && CurrentProfile.SelectedKeys.Contains(e.KeyCode))
            {
                foreach (ProcessInfo P in ProcessList)
                {
                    if (P.ThisProcess.MainWindowHandle != ActiveWindow)
                    {

                        uint lParam = 0x01;

                        if (e.WindowMessage == Win32.WM.KEYUP)
                        {
                            lParam |= 0xC0000000;
                        }
                        DllImports.PostMessage(P.ThisProcess.MainWindowHandle, e.WindowMessage, (int)e.KeyCode, lParam);
                    }
                }
            }

            if (e.WindowMessage == Win32.WM.KEYUP)
            {
                if (PressedKeys.Contains(e.KeyCode))
                    PressedKeys.Remove(e.KeyCode);
#if DEBUG
                Console.WriteLine(DefaultLanguage.Strings.GetFormatedString("DEBUG_KEY_RELEASE", e.KeyCode));
#endif
            }
            else
            {
                if (!PressedKeys.Contains(e.KeyCode))
                    PressedKeys.Add(e.KeyCode);
#if DEBUG
                Console.WriteLine(DefaultLanguage.Strings.GetFormatedString("DEBUG_KEY_PRESS", e.KeyCode));
#endif
            }
#if DEBUG
            Console.WriteLine(DefaultLanguage.Strings.GetFormatedString("DEBUG_KEY_LIST", ((Func<string>)(() => { string s = ""; foreach (Keys k in PressedKeys) s += ", " + k; return s; }))()));
#endif
            if (KeyStateChanged != null)
                KeyStateChanged(null, new KeyStateChangesArgs(PressedKeys.ToArray()));

        }



        static IntPtr WindowIsActive()
        {
            IntPtr ActiveWindow = DllImports.GetForegroundWindow();
            foreach (ProcessInfo P in ProcessList)
            {
                if (P.ThisProcess.MainWindowHandle == ActiveWindow)
                {
                    return ActiveWindow;
                }
            }
            return IntPtr.Zero;
        }
    }
}
