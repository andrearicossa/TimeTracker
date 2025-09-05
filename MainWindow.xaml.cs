using System.Collections.Generic;
using System.Windows;

namespace TimeTracker
{
    public partial class MainWindow : Window
    {
        private List<Activity> activities;

        public MainWindow()
        {
            InitializeComponent();
            activities = ActivityManager.LoadActivities();
            ActivitiesDataGrid.ItemsSource = activities;
        }

        private void NewActivityButton_Click(object sender, RoutedEventArgs e)
        {
        var newActivityWindow = new NewActivityWindow();
        if (newActivityWindow.ShowDialog() == true)
        {
            var activity = newActivityWindow.CreatedActivity;
            if (activity != null)
            {
                var timerWindow = new TimerWindow(activity.Name ?? "", activity.DurationMinutes);
                this.Hide();
                var timerResult = timerWindow.ShowDialog();
                this.Show();
                this.WindowState = WindowState.Normal;
                this.Activate();
                if (timerResult == true)
                {
                    activity.EndTime = DateTime.Now;
                    activities.Add(activity);
                    ActivityManager.SaveActivities(activities);
                    ActivitiesDataGrid.Items.Refresh();
                }
                // Qui si può gestire la logica di pausa/continua
            }
        }
        }
    }
}