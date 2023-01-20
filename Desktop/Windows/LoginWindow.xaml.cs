using System.Windows;

namespace Desktop.Windows
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
            if (EnterTheEmail.ValidEmail() == null && EnterThePassword.ValidPass() == null)
            {
                Window window = new RegistrationWindow();
                Hide();
                window.Show();
                
                ErrorMessageEmail.Text = "";
                ErrorMessagePassword.Text = "";
            }
            else
            {
                ErrorMessageEmail.Text = EnterTheEmail.ValidEmail();
                ErrorMessagePassword.Text = EnterThePassword.ValidPass();
            }
            
        }
    }
}