using System.Windows;
using System.Windows.Controls;
using Desktop.Windows;

namespace Desktop.View
{
    public partial class MainEmptyPage : Page
    {
        
        private string userName;
        
        public MainEmptyPage(string name = "")
        {
            InitializeComponent();
            userName = name;
        }
        
        private void NewTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateTaskPage());
        }
    }
}