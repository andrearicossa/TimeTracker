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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Inserisci il nome dell'attività.", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            if (!int.TryParse(DurationTextBox.Text, out int duration) || duration <= 0)
            {
                MessageBox.Show("Inserisci una durata valida.", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            CreatedActivity = new Activity
            {
                Name = NameTextBox.Text,
                StartTime = null,
                EndTime = null,
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
