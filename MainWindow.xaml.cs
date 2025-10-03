using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

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
            
            // Imposta la versione dinamicamente
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            VersionTextBlock.Text = $"v{version?.Major}.{version?.Minor}.{version?.Build}";
        }

        private void NewActivityButton_Click(object sender, RoutedEventArgs e)
        {
            var newActivityWindow = new NewActivityWindow();
            newActivityWindow.Owner = this;
            
            if (newActivityWindow.ShowDialog() == true)
            {
                var activity = newActivityWindow.CreatedActivity;
                if (activity != null)
                {
                    // Salva l'attività direttamente nella lista
                    activities.Add(activity);
                    ActivityManager.SaveActivities(activities);
                    ActivitiesDataGrid.Items.Refresh();
                }
            }
        }

        private void EditActivityButton_Click(object sender, RoutedEventArgs e)
        {
            // Ottiene l'attività associata al pulsante tramite il Tag
            if (sender is Button button && button.Tag is Activity activity)
            {
                var editWindow = new EditActivityWindow(activity);
                editWindow.Owner = this;
                
                if (editWindow.ShowDialog() == true)
                {
                    // L'attività è già stata modificata nel dialogo
                    // Salva le modifiche e aggiorna la griglia
                    ActivityManager.SaveActivities(activities);
                    ActivitiesDataGrid.Items.Refresh();
                }
            }
        }

        private void TimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Ottiene l'attività associata al pulsante tramite il Tag
            if (sender is Button button && button.Tag is Activity activity)
            {
                var timerWindow = new TimerWindow(activity);
                
                // Nascondi la MainWindow
                this.Hide();
                
                // Mostra il timer come finestra modale
                var result = timerWindow.ShowDialog();
                
                // Ripristina la MainWindow
                this.Show();
                this.WindowState = WindowState.Normal;
                this.Activate();
                
                // Se il timer è stato completato o fermato, salva le modifiche
                if (result == true)
                {
                    ActivityManager.SaveActivities(activities);
                    ActivitiesDataGrid.Items.Refresh();
                }
            }
        }

        private void DeleteActivityButton_Click(object sender, RoutedEventArgs e)
        {
            // Ottiene l'attività associata al pulsante tramite il Tag
            if (sender is Button button && button.Tag is Activity activity)
            {
                // Mostra una finestra di conferma prima di eliminare
                var result = MessageBox.Show(
                    $"Sei sicuro di voler eliminare l'attività '{activity.Name}'?\n\nQuesta operazione non può essere annullata.",
                    "Conferma eliminazione",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.No);

                if (result == MessageBoxResult.Yes)
                {
                    // Rimuovi l'attività dalla lista
                    activities.Remove(activity);
                    
                    // Salva le modifiche
                    ActivityManager.SaveActivities(activities);
                    
                    // Aggiorna la griglia
                    ActivitiesDataGrid.Items.Refresh();
                }
            }
        }
    }
}