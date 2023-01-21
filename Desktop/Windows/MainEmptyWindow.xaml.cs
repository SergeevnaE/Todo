using System.Windows;
using Entities.Repository;

namespace Desktop.Windows
{
    public partial class MainEmptyWindow
    {
        public MainEmptyWindow()
        {
            InitializeComponent();
            MessageBox.Show(UserRepository.Users.Count.ToString());
        }

        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            Window window = new RegistrationWindow();
            Hide();
            window.Show();
        }
    }
}