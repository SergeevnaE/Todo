using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Desktop.Repository;
using Entities.Models;

namespace Desktop.View
{
    public partial class MainPage : Page
    {
        private static bool isChecked;
        
        public MainPage(string name = "")
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

            TranslateTransform transformLeft = (TranslateTransform)DetailDescriptionBlock.RenderTransform;

            DoubleAnimation enterAnimationLeft = new DoubleAnimation
            {
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5)
            };

            DetailDescriptionBlock.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, TimeSpan.FromSeconds(0.5)));
            transformLeft.BeginAnimation(TranslateTransform.XProperty, enterAnimationLeft);

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
                TranslateTransform transformRight = (TranslateTransform)DetailDescriptionBlock.RenderTransform;

                DoubleAnimation enterAnimationRight = new DoubleAnimation
                {
                    To = 800,
                    Duration = TimeSpan.FromSeconds(0.5)
                };

                DetailDescriptionBlock.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(1, TimeSpan.FromSeconds(0.5)));
                transformRight.BeginAnimation(TranslateTransform.XProperty, enterAnimationRight);
            }
        }
        
        private void AddTaskButton_OnClick(object sender, RoutedEventArgs e)
        {
            CreateTaskPage nextPage = new CreateTaskPage();
            PageTransition.Transition(this, nextPage);
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