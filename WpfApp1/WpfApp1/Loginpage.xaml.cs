using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToDoApp
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = "";
                UsernameTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username";
                UsernameTextBox.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (username == "admin" && password == "password")
            {
                MessageBox.Show("Login successful!");
                NavigationService.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }
    }
}
