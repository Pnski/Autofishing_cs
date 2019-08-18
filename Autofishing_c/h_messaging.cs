using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class messaging
{
    [DllImport("User32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

    //5-8:
    private const uint K_5 = 0x35;
    private const uint K_6 = 0x36;
    private const uint K_7 = 0x37;
    private const uint K_8 = 0x38;
    //f:
    private const uint K_F = 0x46;

    static void SendToProcess(int key, string processname)
    {
        Process[] dotexe = Process.GetProcessesByName(processname);
        if (dotexe[0] != null)
        {
            SendMessage(dotexe[0].MainWindowHandle, 0x0100, key, null);
        }
    }
}