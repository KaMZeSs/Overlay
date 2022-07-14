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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Overlay.Core;

namespace Overlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ActiveWindowWatcher watcher;
        Options options;

        public MainWindow()
        {
            InitializeComponent();
            this.Width = 0; this.Height = 0;
            options = new()
            {
                WindowUpdateInterval = 1000
            };
        }

        private void Watcher_ActiveWindowChanged(object? sender, WindowData e)
        {
            Win32.RECT bounds = e.Bounds;

            this.Dispatcher.Invoke(() =>
            {
                this.Width = bounds.right - bounds.left;
                this.Height = bounds.bottom - bounds.top;
                this.Top = bounds.top;
                this.Left = bounds.left;
            });
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Get this window's handle
            var hwnd = new WindowInteropHelper(this).Handle;

            // Make ClickThroug
            Win32.MakeClickThrough(hwnd);

            // ForeGround Window Watcher
            watcher = new(TimeSpan.FromMilliseconds(options.WindowUpdateInterval));
            watcher.ActiveWindowChanged += this.Watcher_ActiveWindowChanged;
            watcher.Start();
        }
    }
}
