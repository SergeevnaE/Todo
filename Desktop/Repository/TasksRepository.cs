using System.Collections.Generic;
using System.Collections.ObjectModel;
using Entities.Models;

namespace Desktop.Repository
{
    public static class TasksRepository
    {
        private static readonly ObservableCollection<TaskModel> Tasks = new ObservableCollection<TaskModel>
        {
            new TaskModel {Id = 0, Title = "Сходить на рыбалку со Стефаном", 
                Category = "Отдых", Content = "Сегодня нужно позвать Стефана на рыбалку", 
                Date = "08.02.2023", Time = "12:00", IsChecked = false},
            
            new TaskModel {Id = 1, Title = "Прочитать книгу Рассказы Чехова", 
                Category = "Учеба", Content = "На уроке задали прочитать 3 рассказа Чехова", 
                Date = "06.02.2023", Time = "16:00", IsChecked = true},
            
            new TaskModel {Id = 2, Title = "Убраться по дому", 
                Category = "Дом", Content = "Мама сказала убраться по дому до ее прихода", 
                Date = "07.02.2023", Time = "11:00", IsChecked = false},
            
            new TaskModel {Id = 3, Title = "Выполнить то, что не успел сделать на работе", 
                Category = "Работа", Content = "Сегодня я не успел сделать все отчеты по прошедшему месяцу", 
                Date = "09.02.2023", Time = "18:00", IsChecked = false},
            
            new TaskModel {Id = 4, Title = "Android", 
                Category = "Программирование", Content = "Нужно реализовать кастомную нижнюю навигацию", 
                Date = "05.02.2023", Time = "14:00", IsChecked = true},
            
            new TaskModel {Id = 5, Title = "WPF", 
                Category = "Программирование", Content = "Нужно реализовать добавление задачи", 
                Date = "08.02.2023", Time = "12:00", IsChecked = false},
            
            new TaskModel {Id = 6, Title = "Сходить поиграть в футбол с пацанами", 
                Category = "Отдых", Content = "Завтра меня Стефан позвал поиграть футбол, нужно сходить", 
                Date = "09.02.2023", Time = "10:00", IsChecked = true},
        };

        public static bool GetIsCheckedTask(TaskModel task)
        {
            return task.IsChecked;
        }
        
        public static ObservableCollection<TaskModel> GetTasks()
        {
            return Tasks;
        }

        public static IEnumerable<TaskModel> GetTaskByIsCheckedAndTaskCategory
        (
            bool isChecked,
            TaskCategoryModel taskCategory = null
        ) {
            var tasks = new ObservableCollection<TaskModel>();

            if (taskCategory == null) return tasks;
            
            if (isChecked)
            {
                foreach (var task in Tasks)
                {
                    if (task.IsChecked && taskCategory.Title == task.Category)
                    {
                        tasks.Add(task);
                    }
                }
            }
            else
            {
                foreach (var task in Tasks)
                {
                    if (!task.IsChecked && taskCategory.Title == task.Category)
                    {
                        tasks.Add(task);
                    }
                }
            }

            return tasks;
        }

        public static void AddTask(TaskModel task)
        {
            Tasks.Add(task);
        }

        public static void AddAllTasks(List<TaskModel> tasks)
        {
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        public static void DeleteTask(TaskModel task)
        {
            Tasks.Remove(task);
        }

        public static void IsCheckedTask(TaskModel task)
        {
            task.IsChecked = true;
        }
    }
}