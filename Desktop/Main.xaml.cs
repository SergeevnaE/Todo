using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Entities.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Collections.Generic;

namespace Desktop
{
    public partial class Main : Window
    {
        private ObservableCollection<TaskCategoryModelDesktop> TasksCategory { get; set; } 
        private List<SolidColorBrush> colors { get; set; }  
        private ObservableCollection<TaskModel> Tasks { get; set; }
        public Main(string name)
        {
            InitializeComponent();

            UserNameTextBlock.Text = name;
            
            Random random = new Random();
            colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Red),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Yellow),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush(Colors.Purple)
            };

            TasksCategory = new ObservableCollection<TaskCategoryModelDesktop>
            {
                new TaskCategoryModelDesktop {Title = "Дом", TextColor = colors[random.Next(colors.Count)]},
                new TaskCategoryModelDesktop {Title = "Работа", TextColor = colors[random.Next(colors.Count)]},
                new TaskCategoryModelDesktop {Title = "Учёба", TextColor = colors[random.Next(colors.Count)]},
                new TaskCategoryModelDesktop {Title = "Отдых", TextColor = colors[random.Next(colors.Count)]},
            };
            MenuList.ItemsSource = TasksCategory;

            Tasks = new ObservableCollection<TaskModel>
            {
                new TaskModel {Task = "Go fishing with Setphan", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
                new TaskModel {Task = "Go fishing with Setphan", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
                new TaskModel {Task = "Read the book Zlatan", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
                new TaskModel {Task = "Meet according with design team", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
                new TaskModel {Task = "Meet according with design team", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
                new TaskModel {Task = "Meet according with design team", Time = "9:00am", Done = false, CheckBoxColor = Brushes.White},
            };
            TasksList.ItemsSource = Tasks;
        }

        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel) TasksList.SelectedItem; 
            Tasks.Remove(task);
        }

        private void Done_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel) TasksList.SelectedItem; 
            task.Done = true;
            task.CheckBoxColor = new SolidColorBrush(Colors.Red);

        }

        private void TasksList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem is TaskModel task)
            {
                TitleTextBlock.Text = task.Task;
                TimeTextBlock.Text = task.Time;
                DateTextBlock.Text = task.Time;
                TaskFullContent.Visibility = Visibility.Visible;
            }
            else
            {
                TaskFullContent.Visibility = Visibility.Hidden;
            }

        }
    }
}
