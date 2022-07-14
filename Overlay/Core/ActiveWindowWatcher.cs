using System;

namespace Overlay.Core
{
    internal class ActiveWindowWatcher
    {
        private System.Timers.Timer stateTimer;

        private WindowData currentActiveWindow = new();
        public event EventHandler<WindowData> ActiveWindowChanged;

        /// <summary>
        ///  Raise event every time active window changes
        /// </summary>
        /// <param name="interval">
        ///  Interval in milliseconds
        /// </param>
        public ActiveWindowWatcher(TimeSpan interval)
        { 
            stateTimer = new(interval.TotalMilliseconds);
            stateTimer.Elapsed += (o, e) => GetActiveWindow();
        }

        public void Start() => stateTimer.Start();
        public void Stop() => stateTimer.Stop();

        private void GetActiveWindow()
        {
            var active = Win32.GetActiveWindow();
            if (active is null)
                return;

            if (active.Equals(currentActiveWindow))
                return;

            currentActiveWindow = active;
            ActiveWindowChanged?.Invoke(this, currentActiveWindow);
        }
    }
}
