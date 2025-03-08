using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskAddPage());
        }

        private void ViewTasksButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TaskSavePage());
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
           
            NavigationService.Navigate(new LoginPage());
        }
    }
}
