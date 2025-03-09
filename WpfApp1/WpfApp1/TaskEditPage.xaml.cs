using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    public partial class TaskEditPage : Page
    {
        private TaskItem _task;

        public TaskEditPage(TaskItem task)
        {
            InitializeComponent();
            _task = task;
            PopulateFields();
        }

        private void PopulateFields()
        {
            TaskNameTextBox.Text = _task.Name;
            TaskDescriptionTextBox.Text = _task.Description;

            string[] timeParts = _task.Time.ToString("hh:mm tt").Split(new[] { ':', ' ' });

            HourComboBox.ItemsSource = Enumerable.Range(1, 12).Select(i => i.ToString("D2"));
            MinuteComboBox.ItemsSource = Enumerable.Range(0, 60).Where(i => i % 5 == 0).Select(i => i.ToString("D2"));
            AmPmComboBox.ItemsSource = new[] { "AM", "PM" };

            HourComboBox.SelectedItem = timeParts[0];
            MinuteComboBox.SelectedItem = timeParts[1];
            AmPmComboBox.SelectedItem = timeParts[2];
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            _task.Name = TaskNameTextBox.Text;
            _task.Description = TaskDescriptionTextBox.Text;

            if (HourComboBox.SelectedItem == null || MinuteComboBox.SelectedItem == null || AmPmComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid time.");
                return;
            }

            string selectedTime = $"{HourComboBox.SelectedItem}:{MinuteComboBox.SelectedItem} {AmPmComboBox.SelectedItem}";

            if (DateTime.TryParseExact(selectedTime, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
            {
                _task.Time = parsedTime;
                MessageBox.Show("Task updated!");
                NavigationService.Navigate(new TaskSavePage());
            }
            else
            {
                MessageBox.Show("Invalid time format.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
