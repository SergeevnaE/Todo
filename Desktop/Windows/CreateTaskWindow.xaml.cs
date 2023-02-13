using System.Linq;
using System.Windows;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.Windows
{
    public partial class CreateTaskWindow : Window
    {
        private string userName;
        public CreateTaskWindow(string name = "")
        {
            InitializeComponent();
            userName = name;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow(userName);

            Hide();

            if (window.TasksListBox.Items.Count == 0)
            {
                new MainEmptyWindow(userName).Show();
            }
            else
            {
                window.Show();
            }
        }

        private void CreateTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EnterTitleTextBox.ValidIsNull() == null && 
                EnterCategoryTextBox.ValidIsNull() == null &&
                EnterContentTextBox.ValidIsNull() == null &&
                EnterDate.ValidDate() == null && 
                EnterTimeTextBox.ValidTime() == null)
            {
                var task = new TaskModel { 
                    Id = TasksRepository.GetTasks().Count() != 0 ? TasksRepository.GetTasks().Count() : 0, 
                    Title = EnterTitleTextBox.Text, 
                    Category = EnterCategoryTextBox.Text,
                    Content = EnterContentTextBox.Text,
                    Date = EnterDate.Text,
                    Time = EnterTimeTextBox.Text,
                    IsChecked = false
                };
                
                TasksRepository.AddTask(task);
                Hide();
                new MainWindow().Show();
            }
            else
            {
                ErrorMessageTitle.Text = EnterTitleTextBox.ValidIsNull();
                ErrorMessageCategory.Text = EnterCategoryTextBox.ValidIsNull();
                ErrorMessageContent.Text = EnterContentTextBox.ValidIsNull();
                ErrorMessageDate.Text = EnterDate.ValidDate();
                ErrorMessageTime.Text = EnterTimeTextBox.ValidTime();
            }
        }
    }
}