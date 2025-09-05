using System;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class TimerWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime endTime;
        private int durationMinutes;
        public bool StoppedEarly { get; private set; } = false;
        private NotifyIcon trayIcon;

        public TimerWindow(string activityName, int minutes)
        {
            InitializeComponent();
            ActivityNameText.Text = activityName;
            durationMinutes = minutes;
            endTime = DateTime.Now.AddMinutes(minutes);
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTimerText();

            trayIcon = new NotifyIcon();
            trayIcon.Icon = System.Drawing.SystemIcons.Information;
            trayIcon.Visible = false;
            trayIcon.Text = $"Timer: {activityName}";
            trayIcon.DoubleClick += TrayIcon_DoubleClick;

            this.StateChanged += TimerWindow_StateChanged;
            this.Closed += TimerWindow_Closed;
        }

        private void TimerWindow_StateChanged(object? sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Hide();
                trayIcon.Visible = true;
            }
        }

        private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
            trayIcon.Visible = false;
        }

        private void TimerWindow_Closed(object? sender, EventArgs e)
        {
            trayIcon.Visible = false;
            trayIcon.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimerText();
            if (DateTime.Now >= endTime)
            {
                timer.Stop();
                trayIcon.BalloonTipTitle = "Timer concluso";
                trayIcon.BalloonTipText = "Il tempo dell'attività è terminato.";
                trayIcon.ShowBalloonTip(3000);
                DialogResult = true;
                Close();
            }
        }
        private void UpdateTimerText()
        {
            var remaining = endTime - DateTime.Now;
            if (remaining.TotalSeconds < 0) remaining = TimeSpan.Zero;
            TimerText.Text = remaining.ToString(@"mm\:ss");
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            StoppedEarly = true;
            DialogResult = false;
            Close();
        }
    }
}
