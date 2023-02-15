using System.Windows;
using System.Windows.Controls;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.View
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void GoToMainWindowButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EnterTheEmail.ValidEmail() == null && EnterThePassword.ValidPassword() == null)
            {
                ErrorMessageEmail.Text = "";
                ErrorMessagePassword.Text = "";

                var loginUser = UserRepository.LoginUser(new UserModel("", EnterTheEmail.Text, EnterThePassword.Text));

                if (loginUser != null)
                {
                    NavigationService?.Navigate(new MainEmptyPage(loginUser.UserName));
                }
                else
                {
                    MessageBox.Show("Пользователя с такой почтой не существует");
                }
            }
            else
            {
                ErrorMessageEmail.Text = EnterTheEmail.ValidEmail();
                ErrorMessagePassword.Text = EnterThePassword.ValidPassword();
            }

        }

        private void GoToRegister_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegistrationPage());
        }
    }
}