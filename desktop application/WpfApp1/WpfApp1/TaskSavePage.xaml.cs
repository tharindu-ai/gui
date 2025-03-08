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
            int count = 1;

            foreach (var task in TaskAddPage.TaskList)
            {
                TaskListBox.Items.Add($"{count}. {task.Name} - {task.Description} (Time: {task.Time})");
                count++;
            }

            TaskCountTextBlock.Text = $"Total Tasks: {TaskAddPage.TaskList.Count}";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomePage());
        }

        private void TaskListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                int index = TaskListBox.SelectedIndex;
                TaskAddPage.TaskList.RemoveAt(index);
                LoadTasks();
            }
        }

        private void TaskListBox_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                ContextMenu menu = new ContextMenu();
                MenuItem deleteItem = new MenuItem { Header = "Delete Task" };
                deleteItem.Click += DeleteTask_Click;
                menu.Items.Add(deleteItem);
                TaskListBox.ContextMenu = menu;
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedItem != null)
            {
                int index = TaskListBox.SelectedIndex;
                TaskAddPage.TaskList.RemoveAt(index);
                LoadTasks();
                MessageBox.Show("Task deleted.");
            }
        }
    }
}