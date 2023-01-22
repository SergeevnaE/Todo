using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
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
            if (validMail == true)
            {
                if (validPass == null)
                {
                    var wind = new MainEmpty();
                    wind.Show();
                    Manager.CurrentWindow.Close();
                }
                else
                {
                    MessageBox.Show(validPass);
                }
            }
            else
            {
                MessageBox.Show("Неверная форма ввода почты");
            }
        }
    }
}
