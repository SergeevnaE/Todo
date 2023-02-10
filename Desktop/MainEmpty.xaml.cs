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
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainEmpty.xaml
    /// </summary>
    public partial class MainEmpty : Window
    {
        private string userName;
        public MainEmpty(string name)
        {
            InitializeComponent();

            userName = name;
            UserName.Text = userName;
        }

        private void Creature_Click(object sender, RoutedEventArgs e)
        {
            var window = new Main(userName);
            window.Show();
            Hide();
        }
    }
}
