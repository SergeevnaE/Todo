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

        private void GoToLogin_OnClick(object sender, RoutedEventArgs e)
        {
            Manager.CurrentWindow.Show();
            Close();
        }
    }
}