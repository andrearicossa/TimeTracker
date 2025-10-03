using System;
using System.Windows;

namespace TimeTracker
{
    public partial class EditActivityWindow : Window
    {
        public Activity? EditedActivity { get; private set; }

        public EditActivityWindow(Activity activity)
        {
            InitializeComponent();
            
            // Popola i campi con i dati dell'attività esistente
            NameTextBox.Text = activity.Name ?? "";
            DurationTextBox.Text = activity.DurationMinutes.ToString();
            
            // Gestione date e orari
            if (activity.StartTime.HasValue)
            {
                StartDatePicker.SelectedDate = activity.StartTime.Value.Date;
                StartHourTextBox.Text = activity.StartTime.Value.Hour.ToString("D2");
                StartMinuteTextBox.Text = activity.StartTime.Value.Minute.ToString("D2");
            }
            else
            {
                // Lascia i campi vuoti se non c'è data di inizio
                StartDatePicker.SelectedDate = null;
                StartHourTextBox.Text = "";
                StartMinuteTextBox.Text = "";
            }
            
            if (activity.EndTime.HasValue)
            {
                EndDatePicker.SelectedDate = activity.EndTime.Value.Date;
                EndHourTextBox.Text = activity.EndTime.Value.Hour.ToString("D2");
                EndMinuteTextBox.Text = activity.EndTime.Value.Minute.ToString("D2");
            }
            else
            {
                // Lascia i campi vuoti se non c'è data di fine
                EndDatePicker.SelectedDate = null;
                EndHourTextBox.Text = "";
                EndMinuteTextBox.Text = "";
            }
            
            EditedActivity = activity;
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
            
            // Costruzione delle date complete - gestione campi vuoti
            DateTime? startDateTime = null;
            DateTime? endDateTime = null;
            
            // Validazione e costruzione data di inizio solo se i campi sono compilati
            if (StartDatePicker.SelectedDate.HasValue && 
                !string.IsNullOrWhiteSpace(StartHourTextBox.Text) && 
                !string.IsNullOrWhiteSpace(StartMinuteTextBox.Text))
            {
                if (!int.TryParse(StartHourTextBox.Text, out int startHour) || startHour < 0 || startHour > 23)
                {
                    MessageBox.Show("Inserisci un'ora di inizio valida (0-23).", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                if (!int.TryParse(StartMinuteTextBox.Text, out int startMinute) || startMinute < 0 || startMinute > 59)
                {
                    MessageBox.Show("Inserisci i minuti di inizio validi (0-59).", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                startDateTime = StartDatePicker.SelectedDate.Value.Date.AddHours(startHour).AddMinutes(startMinute);
            }
            
            // Validazione e costruzione data di fine solo se i campi sono compilati
            if (EndDatePicker.SelectedDate.HasValue && 
                !string.IsNullOrWhiteSpace(EndHourTextBox.Text) && 
                !string.IsNullOrWhiteSpace(EndMinuteTextBox.Text))
            {
                if (!int.TryParse(EndHourTextBox.Text, out int endHour) || endHour < 0 || endHour > 23)
                {
                    MessageBox.Show("Inserisci un'ora di fine valida (0-23).", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                if (!int.TryParse(EndMinuteTextBox.Text, out int endMinute) || endMinute < 0 || endMinute > 59)
                {
                    MessageBox.Show("Inserisci i minuti di fine validi (0-59).", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                
                endDateTime = EndDatePicker.SelectedDate.Value.Date.AddHours(endHour).AddMinutes(endMinute);
            }
            
            // Validazione che la data di fine sia successiva a quella di inizio (solo se entrambe sono impostate)
            if (startDateTime.HasValue && endDateTime.HasValue && endDateTime <= startDateTime)
            {
                MessageBox.Show("La data/ora di fine deve essere successiva a quella di inizio.", "Errore", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            
            // Aggiorna l'attività con i nuovi valori
            if (EditedActivity != null)
            {
                EditedActivity.Name = NameTextBox.Text;
                EditedActivity.DurationMinutes = duration;
                EditedActivity.StartTime = startDateTime;
                EditedActivity.EndTime = endDateTime;
            }
            
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