using System.Collections.Generic;
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
        }

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

        private void TaskTimeTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TaskTimeTextBox.Text == "HH:MM AM/PM")
            {
                TaskTimeTextBox.Text = "";
                TaskTimeTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void TaskTimeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TaskTimeTextBox.Text))
            {
                TaskTimeTextBox.Text = "HH:MM AM/PM";
                TaskTimeTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskNameTextBox.Text == "Task Name" ? null : TaskNameTextBox.Text;
            string taskDesc = TaskDescriptionTextBox.Text == "Task Description" ? null : TaskDescriptionTextBox.Text;
            string taskTime = TaskTimeTextBox.Text == "HH:MM AM/PM" ? null : TaskTimeTextBox.Text;

            TaskList.Add(new TaskItem { Name = taskName, Description = taskDesc, Time = taskTime });
            MessageBox.Show("Task saved!");
            NavigationService.Navigate(new TaskSavePage());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}