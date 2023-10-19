using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Desktop.Api;
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
            MainPage nextPage = new MainPage(userName);
            PageTransition.Transition(this, nextPage);
        }

        private void CreateTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (EnterTitleTextBox.ValidIsNull() == null && 
                EnterCategoryTextBox.ValidIsNull() == null &&
                EnterContentTextBox.ValidIsNull() == null &&
                EnterDate.ValidDate() == null && 
                EnterTimeTextBox.ValidTime() == null)
            {
                if (new ApiClientImpl().CreateTaskAsync(new TaskModel
                {
                    Id = Guid.NewGuid(),
                    Title = EnterTitleTextBox.Text,
                    Category = EnterCategoryTextBox.Text,
                    Description = EnterContentTextBox.Text,
                    Date = ToUnixTime(EnterDate.Text + " " + EnterTimeTextBox.Text),
                    Time = EnterTimeTextBox.Text,
                    IsCompleted = false
                }) == null)
                {
                    MessageBox.Show("Ошибка добавления задачи, попробуйте позже", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MainPage nextPage = new MainPage(userName);
                    PageTransition.Transition(this, nextPage);   
                }
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

        public long ToUnixTime(string dateTime)
        {
            //string dateTimeString = "19.10.2023 13:18";
            
            string[] dateTimeParts = dateTime.Split(' ');
            string dateString = dateTimeParts[0];
            string timeString = dateTimeParts[1];
            
            string[] dateParts = dateString.Split('.');
            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);
            
            string[] timeParts = timeString.Split(':');
            int hour = int.Parse(timeParts[0]);
            int minute = int.Parse(timeParts[1]);
            
            DateTime date = new DateTime(year, month, day);
            
            DateTime time = new DateTime(1, 1, 1, hour, minute, 0);

            DateTime combinedDateTime = date.Add(time.TimeOfDay);

            long unixTime = ((DateTimeOffset)combinedDateTime).ToUnixTimeSeconds();

            return unixTime;
        }
    }
}