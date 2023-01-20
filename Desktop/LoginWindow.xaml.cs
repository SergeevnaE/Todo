using System.Windows;
using System.Windows.Media;

namespace Desktop
{
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            Manager.CurrentWindow = this;
        }

        private void GoToRegister_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}