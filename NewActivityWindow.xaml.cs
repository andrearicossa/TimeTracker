using System;
using System.Windows;

namespace TimeTracker
{
    public partial class NewActivityWindow : Window
    {
        public Activity? CreatedActivity { get; private set; }

        public NewActivityWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Inserisci il nome dell'attività.");
                return;
            }
            if (!int.TryParse(DurationTextBox.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Inserisci una durata valida.");
                return;
            }
            CreatedActivity = new Activity
            {
                Name = NameTextBox.Text,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(duration),
                DurationMinutes = duration
            };
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
