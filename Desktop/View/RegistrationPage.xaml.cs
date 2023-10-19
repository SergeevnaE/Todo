using System.Windows;
using System.Windows.Controls;
using Desktop.Api;
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
            LoginPage nextPage = new LoginPage();
            PageTransition.Transition(this, nextPage);
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

                var loginUserRemote = new ApiClientImpl().RegistrationUserAsync(new UserModel
                    { Name = TextNameUser.Text, Email = TextEmail.Text, Password = TextPassword.Text });
                
                if (loginUserRemote?.Result != null)
                {
                    TokenManager.Token = loginUserRemote.Result?.access_token;
                    MainEmptyPage nextPage = new MainEmptyPage(TextNameUser.Text);
                    PageTransition.Transition(this, nextPage);
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже зарегестрирован!", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Error);
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