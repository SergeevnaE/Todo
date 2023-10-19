using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Desktop.Api;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.View
{
    public partial class LoginPage : Page
    {
        private UserControl oldView;
        private bool isAnimationRun;
        
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
                
                var loginUserRemote = new ApiClientImpl().LoginUserAsync(new UserModel
                    { Email = EnterTheEmail.Text, Password = EnterThePassword.Text });

                if (loginUserRemote?.Result != null)
                {
                    TokenManager.Token = loginUserRemote.Result?.access_token;
                    MainEmptyPage nextPage = new MainEmptyPage(new ApiClientImpl().GetUserInformation().Result.Name);
                    PageTransition.Transition(this, nextPage);
                }
                else
                {
                    MessageBox.Show("Неверны почта или пароль!", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Error);
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
            RegistrationPage nextPage = new RegistrationPage();
            PageTransition.Transition(this, nextPage);
        }
        
        private void animatedButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if(button != null)
            {
                DoubleAnimation heightAnimation = new DoubleAnimation(60, TimeSpan.FromSeconds(0.3));
                button.BeginAnimation(Button.HeightProperty, heightAnimation);   
            }
        }

        private void animatedButton_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if(button != null)
            {
                DoubleAnimation heightAnimation = new DoubleAnimation(50, TimeSpan.FromSeconds(0.3));
                button.BeginAnimation(Button.HeightProperty, heightAnimation);   
            }
        }
    }
}