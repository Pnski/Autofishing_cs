using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class messaging
{
    [DllImport("User32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

    static void Send(char cha)
    {
        switch (cha)
        {
            case '5':
                SendToProcess((int)_const.K_5);
                break;
            case '6':
                SendToProcess((int)_const.K_6);
                break;
            case '7':
                SendToProcess((int)_const.K_7);
                break;
            case '8':
                SendToProcess((int)_const.K_8);
                break;
            case 'f':
                SendToProcess((int)_const.K_F);
                break;
        }
    }

    static void SendToProcess(int key)
    {
        Process[] dotexe = Process.GetProcessesByName(_const._process);
        if (dotexe[0] != null)
        {
            SendMessage(dotexe[0].MainWindowHandle, 0x0100, key, null);
        }
    }
}