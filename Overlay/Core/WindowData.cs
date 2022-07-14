using System;

namespace Overlay.Core
{
    internal class WindowData
    {
        public IntPtr WindowHandle { get; set; } = IntPtr.Zero;
        public string WindowTitle { get; set; } = string.Empty;

        public Win32.RECT Bounds
        {
            get
            {
                Win32.RECT rect;
                Win32.GetWindowRect(this.WindowHandle, out rect);
                return rect;
            }
        }

        public WindowData() { }

        public WindowData(IntPtr windowHandle, string windowTitle)
        {
            WindowHandle = windowHandle;
            WindowTitle = windowTitle;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            return (obj as WindowData)?.WindowHandle == WindowHandle;
        }

        public override string ToString()
        {
            return $"{WindowHandle} : {WindowTitle}";
        }
    }
}
