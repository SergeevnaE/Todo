using System.Windows;

namespace Desktop.Windows
{
    public partial class MainEmptyWindow
    {
        private string userName;
        public MainEmptyWindow(string name = "")
        {
            InitializeComponent();
            userName = name;
        }

        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            Window window = new CreateTaskWindow(userName);
            window.Show();
            Hide();
        }
    }
}