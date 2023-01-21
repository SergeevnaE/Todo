﻿using System.Windows;

namespace Desktop.Windows
{
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            Manager.CurrentWindow = this;
        }

        private void GoToMainWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EnterTheEmail.ValidEmail() == null && EnterThePassword.ValidPassword() == null)
            {
                ErrorMessageEmail.Text = "";
                ErrorMessagePassword.Text = "";
                
                Window window = new MainEmptyWindow();
                Hide();
                window.Show();
            }
            else
            {
                ErrorMessageEmail.Text = EnterTheEmail.ValidEmail();
                ErrorMessagePassword.Text = EnterThePassword.ValidPassword();
            }
            
        }

        private void GoToRegister_OnClick(object sender, RoutedEventArgs e)
        {
            Window window = new RegistrationWindow();
            Hide();
            window.Show();
        }
    }
}