using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDoApp
{
    public partial class TaskAddPage : Page
    {
        public static List<TaskItem> TaskList = new List<TaskItem>();

        public TaskAddPage()
        {
            InitializeComponent();
            PopulateTimeSelectors();
        }

        private void PopulateTimeSelectors()
        {
            
            for (int i = 1; i <= 12; i++)
                HourComboBox.Items.Add(i.ToString("D2"));

            
            for (int i = 0; i < 60; i += 5) 
                MinuteComboBox.Items.Add(i.ToString("D2"));

            
            AmPmComboBox.Items.Add("AM");
            AmPmComboBox.Items.Add("PM");

            
            HourComboBox.SelectedIndex = 0;
            MinuteComboBox.SelectedIndex = 0;
            AmPmComboBox.SelectedIndex = 0;
        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskNameTextBox.Text.Trim();
            string taskDesc = TaskDescriptionTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(taskName) || taskName == "Task Name")
            {
                MessageBox.Show("Task name cannot be empty.");
                return;
            }

            if (HourComboBox.SelectedItem == null || MinuteComboBox.SelectedItem == null || AmPmComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid time.");
                return;
            }

            
            string selectedTime = $"{HourComboBox.SelectedItem}:{MinuteComboBox.SelectedItem} {AmPmComboBox.SelectedItem}";

            if (!DateTime.TryParseExact(selectedTime, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
            {
                MessageBox.Show("Invalid time selected.");
                return;
            }

            TaskList.Add(new TaskItem { Name = taskName, Description = taskDesc, Time = parsedTime });

            MessageBox.Show("Task saved!");
            NavigationService.Navigate(new TaskSavePage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        // TextBox Placeholder Management
        private void TaskNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskNameTextBox.Text == "Task Name")
            {
                TaskNameTextBox.Text = "";
                TaskNameTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TaskNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskNameTextBox.Text))
            {
                TaskNameTextBox.Text = "Task Name";
                TaskNameTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void TaskDescriptionTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskDescriptionTextBox.Text == "Task Description")
            {
                TaskDescriptionTextBox.Text = "";
                TaskDescriptionTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TaskDescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskDescriptionTextBox.Text))
            {
                TaskDescriptionTextBox.Text = "Task Description";
                TaskDescriptionTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }
    }
}
