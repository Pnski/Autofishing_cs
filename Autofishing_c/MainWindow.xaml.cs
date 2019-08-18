using System;
using System.Windows;
using System.Windows.Interop;

namespace Autofishing_c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }  

        IntPtr _windowHandle;
        private HwndSource _source;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            _windowHandle = new WindowInteropHelper(this).Handle;
            _source = HwndSource.FromHwnd(_windowHandle);
            _source.AddHook(HwndHook);

            hotkeys.InitHotkeys(_windowHandle);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312; //is registered by RegisterHotkey
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case hotkeys.HOTKEY_ID:
                            int vkey = (((int)lParam >> 16) & 0xFFFF);
                            if (vkey == _const.VK_F1) //Tooltip
                            {
                                tblock.Text += "1";
                            }
                            else if (vkey == _const.VK_F2) //Coordinates
                            {
                            }
                            else if (vkey == _const.VK_F3) //Resume
                            {
                            }
                            else if (vkey == _const.VK_F4) //Pause
                            {
                            }
                            else if (vkey == _const.VK_F5) //exit
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
            hotkeys.UnregisterHotkeys(_windowHandle);
            base.OnClosed(e);
        }  
    }

}