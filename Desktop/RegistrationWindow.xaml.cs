using System.Windows;
using System.Windows.Media;

namespace Desktop
{
    public partial class RegistrationWindow
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void TextNameUser_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (TextNameUser.Text != "Введите имя пользователя") return;
            TextNameUser.Text = "";
            TextNameUser.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextNameUser_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (TextNameUser.Text != "") return;
            TextNameUser.Text = "Введите имя пользователя";
            TextNameUser.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }

        private void TextEmail_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (TextEmail.Text != "exam@yandex.ru") return;
            TextEmail.Text = "";
            TextEmail.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextEmail_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (TextEmail.Text != "") return;
            TextEmail.Text = "exam@yandex.ru";
            TextEmail.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }

        private void TextPassword_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (TextPassword.Text != "Введите пароль") return;
            TextPassword.Text = "";
            TextPassword.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (TextPassword.Text != "") return;
            TextPassword.Text = "Введите пароль";
            TextPassword.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }

        private void TextConfirmPassword_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (TextConfirmPassword.Text != "Повторите пароль") return;
            TextConfirmPassword.Text = "";
            TextConfirmPassword.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextConfirmPassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (TextConfirmPassword.Text != "") return;
            TextConfirmPassword.Text = "Повторите пароль";
            TextConfirmPassword.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }
    }
}