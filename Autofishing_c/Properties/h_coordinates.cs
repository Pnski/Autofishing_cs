using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
class coord
{
    [DllImport("gdi32.dll")]
    static extern int GetPixel(IntPtr hdc, int nXPos, int nYPos);

    public static int GetPixelColor(int x, int y)
    {
        Process[] dotexe = Process.GetProcessesByName(_const._process);
        if (dotexe[0] != null)
        {
            return GetPixel(dotexe[0].MainWindowHandle, x, y);
        }
        else
            return 0;
    }    
}