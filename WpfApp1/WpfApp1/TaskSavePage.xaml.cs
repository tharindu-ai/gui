using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    public partial class TaskSavePage : Page
    {
        public TaskSavePage()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            TaskListBox.Items.Clear();

            
            var sortedTasks = TaskAddPage.TaskList.OrderBy(t => t.Time).ToList();

            int count = 1;
            foreach (var task in sortedTasks)
            {
                ListBoxItem item = new ListBoxItem
                {
                    Content = $"{count}. {task.Name} - {task.Description} (Time: {task.Time:hh:mm tt})",
                    Tag = task 
                };
                TaskListBox.Items.Add(item);
                count++;
            }

            TaskCountTextBlock.Text = $"Total Tasks: {sortedTasks.Count}";

            
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            EditButton.IsEnabled = TaskListBox.SelectedItem != null;
            DeleteButton.IsEnabled = TaskListBox.SelectedItem != null;
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                int index = TaskListBox.SelectedIndex;
                TaskAddPage.TaskList.RemoveAt(index);
                LoadTasks();
                MessageBox.Show("Task deleted.");
            }
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                ListBoxItem selectedItem = (ListBoxItem)TaskListBox.SelectedItem;
                TaskItem taskToEdit = (TaskItem)selectedItem.Tag;

                
                NavigationService.Navigate(new TaskEditPage(taskToEdit));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }
    }
}
