using System.Net.Mime;
using System.Windows;
using System.Windows.Media;

namespace Desktop
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterTheEmail_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (EnterTheEmail.Text != "Введите почту") return;
            EnterTheEmail.Text = "";
            EnterTheEmail.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void EnterTheEmail_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterTheEmail.Text != "") return;
            EnterTheEmail.Text = "Введите почту";
            EnterTheEmail.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }

        private void EnterThePassword_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (EnterThePassword.Text != "Введите пароль") return;
            EnterThePassword.Text = "";
            EnterThePassword.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void EnterThePassword_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (EnterThePassword.Text != "") return;
            EnterThePassword.Text = "Введите пароль";
            EnterThePassword.Foreground = new SolidColorBrush(Color.FromRgb(198, 198, 198));
        }
    }
}