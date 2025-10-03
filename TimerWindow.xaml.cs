using System;
using System.Windows;
using System.Windows.Threading;

namespace TimeTracker
{
    public partial class TimerWindow : Window
    {
        private DispatcherTimer timer;
        private DateTime startTime;
        private DateTime endTime;
        private int durationMinutes;
        private Activity activity;
        public bool StoppedEarly { get; private set; } = false;

        public TimerWindow(Activity activityToTime)
        {
            InitializeComponent();
            activity = activityToTime;
            ActivityNameText.Text = activity.Name ?? "Attività";
            durationMinutes = activity.DurationMinutes;
            
            startTime = DateTime.Now;
            endTime = startTime.AddMinutes(durationMinutes);
            
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            timer.Start();
            UpdateTimerText();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            UpdateTimerText();
            if (DateTime.Now >= endTime)
            {
                timer.Stop();
                
                // Aggiorna l'attività con i tempi effettivi
                activity.StartTime = startTime;
                activity.EndTime = DateTime.Now;
                
                MessageBox.Show("Il tempo dell'attività è terminato.", "Timer concluso", MessageBoxButton.OK, MessageBoxImage.Information);
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
            
            // Aggiorna l'attività con i tempi effettivi anche se fermato in anticipo
            activity.StartTime = startTime;
            activity.EndTime = DateTime.Now;
            
            DialogResult = true; // Cambiato da false a true per indicare successo
            Close();
        }
    }
}
