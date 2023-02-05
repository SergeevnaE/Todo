using System.Windows;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.Windows
{
    public partial class RegistrationWindow
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.CurrentWindow.Show();
            Close();
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
                    Window window = new MainEmptyWindow(TextNameUser.Text);
                    Hide();
                    window.Show();   
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