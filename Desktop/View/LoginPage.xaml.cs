using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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

                var loginUser = UserRepository.LoginUser(new UserModel("", EnterTheEmail.Text, EnterThePassword.Text));

                if (loginUser != null)
                {
                    MainEmptyPage nextPage = new MainEmptyPage(loginUser.UserName);
                    PageTransition.Transition(this, nextPage);
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