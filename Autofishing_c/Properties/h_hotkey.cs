using System;
//using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Interop;
//using System.Windows.Interop;
//using System.Diagnostics;

class hotkeys
{
    //Base Hotkey from: https://social.technet.microsoft.com/wiki/contents/articles/30568.wpf-implementing-global-hot-keys.aspx
    //PInvoke for c# implementation form .NET
    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    
}



namespace h_hotkey
{

}