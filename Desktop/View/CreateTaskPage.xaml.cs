using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.View
{
    public partial class CreateTaskPage : Page
    {
        
        private string userName;
        
        public CreateTaskPage(string name = "")
        {
            InitializeComponent();
            userName = name;
        }
        
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MainPage(userName));
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

                NavigationService?.Navigate(new MainPage(userName));
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