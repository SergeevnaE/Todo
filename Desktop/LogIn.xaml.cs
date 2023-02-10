using System.Windows;
using Desktop.Repository;
using Entities.Models;

namespace Desktop
{
    public partial class LogIn
    {
        public LogIn()
        {
            InitializeComponent();
            Manager.CurrentWindow = this;
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            var wind = new Registration();
            wind.Show();
            Manager.CurrentWindow.Hide();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            var validPass = Validator.PassValid(PasswordBox.Text);
            var validMail = Validator.MailValid(MailBox.Text);
            if (validMail == null)
            {
                if (validPass == null)
                {
                    var loginUser = UserRepository.LoginUser(new UserModel("", MailBox.Text, PasswordBox.Text));
                    if (loginUser != null)
                    {
                        var wind = new MainEmpty(loginUser.name);
                        wind.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не зарегестрирован!");
                    }
                }
                else
                {
                    MessageBox.Show(validPass);
                }
            }
            else
            {
                MessageBox.Show(validMail);
            }
        }
    }
}
