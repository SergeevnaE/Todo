using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.Windows
{
    public partial class MainWindow
    {

        private static bool isChecked;
        
        public MainWindow(string name = "")
        {
            InitializeComponent();

            UserNameTextBlock.Text = name;
            TaskCategoryListBox.ItemsSource =
                TasksCategoryRepository.GetTasksCategoryByTasksListAndIsChecked(TasksRepository.GetTasks(), isChecked);
            TasksListBox.ItemsSource =
                TasksRepository.GetTaskByIsCheckedAndTaskCategory(isChecked, (TaskCategoryModel) TaskCategoryListBox.SelectedItem);
        }

        private void TaskCategoryListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TasksListBox.ItemsSource = TasksRepository.GetTaskByIsCheckedAndTaskCategory(
                isChecked,
                (TaskCategoryModel) TaskCategoryListBox.SelectedItem);
        }

        private void TasksListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var task = (TaskModel) TasksListBox.SelectedItem;

            DetailDescriptionBlock.Visibility = Visibility.Visible;

            if (task != null)
            {
                TitleTextBlock.Text = task.Title;
                ContentTextBlock.Text = task.Content;
                TimeTextBlock.Text = task.Time;
                DateTextBlock.Text = task.Date;

                DoneButton.Visibility = TasksRepository.GetIsCheckedTask(task) ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                DetailDescriptionBlock.Visibility = Visibility.Hidden;
            }
        }
        
        private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new CreateTaskWindow();
            window.Show();
            Hide();
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            DoneButton.Visibility = Visibility.Collapsed;
            TasksRepository.IsCheckedTask((TaskModel) TasksListBox.SelectedItem);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            TasksRepository.DeleteTask((TaskModel) TasksListBox.SelectedItem);
            TasksListBox.ItemsSource = TasksRepository.GetTaskByIsCheckedAndTaskCategory(isChecked, (TaskCategoryModel) TaskCategoryListBox.SelectedItem);

            if (TasksListBox.Items.Count != 0) return;
            
            TasksCategoryRepository.DeleteTaskCategory((TaskCategoryModel) TaskCategoryListBox.SelectedItem);
            TaskCategoryListBox.SelectedIndex = 0;
            TasksListBox.ItemsSource =
                TasksRepository.GetTaskByIsCheckedAndTaskCategory(isChecked,
                    (TaskCategoryModel) TaskCategoryListBox.SelectedItem);
        }

        private void HistoryConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isChecked = true;
            
            TaskCategoryListBox.ItemsSource = TasksCategoryRepository.GetTasksCategoryByTasksListAndIsChecked(
                TasksRepository.GetTasks(), isChecked);

            TaskCategoryListBox.SelectedIndex = 0;
            
            TasksListBox.ItemsSource =
                TasksRepository.GetTaskByIsCheckedAndTaskCategory(
                    isChecked,
                    (TaskCategoryModel) TaskCategoryListBox.SelectedItem);
        }

        private void TasksConditionTextBlock_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isChecked = false;
            
            TaskCategoryListBox.ItemsSource = TasksCategoryRepository.GetTasksCategoryByTasksListAndIsChecked(
                TasksRepository.GetTasks(), isChecked);
            
            TaskCategoryListBox.SelectedIndex = 0;
            
            TasksListBox.ItemsSource =
                TasksRepository.GetTaskByIsCheckedAndTaskCategory(
                    isChecked,
                    (TaskCategoryModel) TaskCategoryListBox.SelectedItem);
        }
    }
}