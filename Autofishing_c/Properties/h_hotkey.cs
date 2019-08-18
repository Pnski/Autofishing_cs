using System;
using System.Runtime.InteropServices;

class hotkeys
{
    public const int HOTKEY_ID = 9000;

    //From: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    //Modifiers:
    private const uint MOD_NONE = 0x0000; //(none)


    //Base Hotkey from: https://social.technet.microsoft.com/wiki/contents/articles/30568.wpf-implementing-global-hot-keys.aspx
    //PInvoke for c# implementation form .NET
    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    public static void InitHotkeys(IntPtr hWnd)
    {
        foreach (uint i in new uint[] { _const.VK_F1, _const.VK_F2, _const.VK_F3, _const.VK_F4, _const.VK_F5})
        // Register F1 - F5 to the WPF form at startup
        {
            RegisterHotKey(hWnd, HOTKEY_ID, MOD_NONE, i);
        }
    }
    
    public static void UnregisterHotkeys(IntPtr hWnd)
    {

    }
}