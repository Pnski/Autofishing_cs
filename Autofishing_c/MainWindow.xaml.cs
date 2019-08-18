using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Diagnostics;

namespace Autofishing_c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Base Hotkey from: https://social.technet.microsoft.com/wiki/contents/articles/30568.wpf-implementing-global-hot-keys.aspx
        //PInvoke for c# implementation form .NET
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        private const int HOTKEY_ID = 9000;


        //From: https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
        //Modifiers:
        private const uint MOD_NONE = 0x0000; //(none)
        //F1-5:
        private const uint VK_F1 = 0x70;
        private const uint VK_F2 = 0x71;
        private const uint VK_F3 = 0x72;
        private const uint VK_F4 = 0x73;
        private const uint VK_F5 = 0x74;
        //5-8:
        private const uint K_5 = 0x35;
        private const uint K_6 = 0x36;
        private const uint K_7 = 0x37;
        private const uint K_8 = 0x38;
        //f:
        private const uint K_F = 0x46;


        public MainWindow()
        {
            InitializeComponent();
        }

        static void SendToProcess(string key, string processname)
        {
            Process[] dotexe = Process.GetProcessesByName(processname);
            if (dotexe[0] != null)
            {
                SendMessage(dotexe[0].MainWindowHandle, 0x0100, key, null);
            }
        }

        private IntPtr _windowHandle;
        private HwndSource _source;
        //Register defined Hotkeys at WPF startup
        /// <summary>
        /// F1: Tooltip
        /// F2: Coordinates
        /// F3: Start
        /// F4: Pause
        /// F5: Exit
        /// </summary>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);
           
            foreach (uint i in new uint[] {VK_F1, VK_F2, VK_F3, VK_F4, VK_F5})
            {
                RegisterHotKey(_windowHandle, HOTKEY_ID, MOD_NONE, i);
            }
        }
        

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == VK_F1) //Tooltip
                            {
                                return 0;
                            }
                            else if (vkey == VK_F2) //Coordinates
                            {
                                return 0;
                            }
                            else if (vkey == VK_F3) //Coordinates
                            {
                                return 0;
                            }
                            else if (vkey == VK_F4) //Coordinates
                            {
                                return 0;
                            }
                            else if (vkey == VK_F5) //exit
                            {
                                Environment.Exit(0);
                            }
                            handled = true;
                            break;
                    }
                    break;
            }
            return IntPtr.Zero;
        }
        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            UnregisterHotKey(_windowHandle, HOTKEY_ID);
            base.OnClosed(e);
        }  
    }

}