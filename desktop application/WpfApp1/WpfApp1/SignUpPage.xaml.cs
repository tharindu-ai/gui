using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace ToDoApp
{
    public partial class SignUpPage : Page
    {
        // Store registered users (This should be replaced with a database in a real application)
        public static Dictionary<string, string> Users = new Dictionary<string, string>();

        public SignUpPage()
        {
            InitializeComponent();
        }

        // Handle GotFocus event for the Username TextBox
        private void NewUsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NewUsernameTextBox.Text == "New Username")
            {
                NewUsernameTextBox.Text = "";
                NewUsernameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }

        // Handle LostFocus event for the Username TextBox
        private void NewUsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NewUsernameTextBox.Text))
            {
                NewUsernameTextBox.Text = "New Username";
                NewUsernameTextBox.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray);
            }
        }

        // Handle GotFocus event for the Password Box
        private void NewPasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Password placeholder should disappear when the user starts typing
            PasswordError.Visibility = Visibility.Collapsed;
        }

        // Handle LostFocus event for the Password Box
        private void NewPasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // Show error message if the password box is empty
            if (string.IsNullOrWhiteSpace(NewPasswordBox.Password))
            {
                PasswordError.Visibility = Visibility.Visible;
            }
        }

        // Handle Create Account Button click event
        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string username = NewUsernameTextBox.Text.Trim();
            string password = NewPasswordBox.Password.Trim();

            // Clear previous error messages
            UsernameError.Visibility = Visibility.Collapsed;
            PasswordError.Visibility = Visibility.Collapsed;

            // Username validation
            if (string.IsNullOrWhiteSpace(username) || username == "New Username")
            {
                UsernameError.Text = "Username cannot be empty!";
                UsernameError.Visibility = Visibility.Visible;
                return;
            }

            // Validate username format (no spaces)
            if (username.Contains(" "))
            {
                UsernameError.Text = "Username cannot contain spaces!";
                UsernameError.Visibility = Visibility.Visible;
                return;
            }

            // Password validation
            if (string.IsNullOrWhiteSpace(password))
            {
                PasswordError.Text = "Password cannot be empty!";
                PasswordError.Visibility = Visibility.Visible;
                return;
            }

            // Validate password strength (e.g., minimum length, requires both letters and numbers)
            if (password.Length < 8 || !Regex.IsMatch(password, @"[a-zA-Z]") || !Regex.IsMatch(password, @"[0-9]"))
            {
                PasswordError.Text = "Password must be at least 8 characters long and contain both letters and numbers!";
                PasswordError.Visibility = Visibility.Visible;
                return;
            }

            // Check if username already exists
            if (Users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Store new user
            Users.Add(username, password);

            MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new LoginPage());
        }

        // Back to Login Page Button Click event
        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void NewUsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NewUsernameTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
