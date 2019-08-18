using System;
using System.Windows;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Autofishing_c
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetCursorPos(ref Win32Point pt);

        [StructLayout(LayoutKind.Sequential)]
        internal struct Win32Point
        {
            public Int32 X;
            public Int32 Y;
        };
        public static Point GetMousePosition()
        {
            Win32Point w32Mouse = new Win32Point();
            GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

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
            _fishing.init();
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
                            }
                            else if (vkey == _const.VK_F2) //Coordinates
                            {
                                _ref.mouse = GetMousePosition();
                                l_coordinates.Text = _ref.mouse.X.ToString() + '/' + _ref.mouse.Y.ToString();
                            }
                            else if (vkey == _const.VK_F3) //Resume
                            {
                                _ref.status = false;
                            }
                            else if (vkey == _const.VK_F4) //Pause
                            {
                                _ref.status = true;
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