using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Desktop.Repository;
using Desktop.View;
using Entities.Models;

namespace Desktop.Windows
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainControl.Content = new LoginPage();
        }
    }
}