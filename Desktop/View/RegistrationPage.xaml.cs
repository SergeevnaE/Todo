using System.Windows;
using System.Windows.Controls;
using Desktop.Repository;
using Desktop.Windows;
using Entities.Models;

namespace Desktop.View
{
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LoginPage());
        }

        private void RegistrationButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (TextNameUser.ValidName() == null &&
                TextEmail.ValidEmail() == null &&
                TextPassword.ValidPassword() == null &&
                TextConfirmPassword.ValidConfirmPassword(TextPassword) == null)
            {
                ErrorTextNameUser.Text = "";
                ErrorTextEmail.Text = "";
                ErrorTextPassword.Text = "";
                ErrorTextConfirmPassword.Text = "";
                
                var registerUser = UserRepository.RegistrationUser(new UserModel(TextNameUser.Text, TextEmail.Text, TextPassword.Text));

                if (registerUser != null)
                {
                    NavigationService?.Navigate(new MainEmptyPage(TextNameUser.Text));
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже зарегестрирован");
                }
            }
            else
            {
                ErrorTextNameUser.Text = TextNameUser.ValidName();
                ErrorTextEmail.Text = TextEmail.ValidEmail();
                ErrorTextPassword.Text = TextPassword.ValidPassword();
                ErrorTextConfirmPassword.Text = TextConfirmPassword.ValidConfirmPassword(TextPassword);
            }
        }
    }
}