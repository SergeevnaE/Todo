using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Entities.Models;

namespace Desktop.Repository
{
    public static class TasksCategoryRepository
    {
        private static readonly ObservableCollection<TaskCategoryModel> TasksCategory =
            new ObservableCollection<TaskCategoryModel>();

        public static void AddAllTasksCategory(ObservableCollection<TaskCategoryModel> tasksCategory)
        {
            foreach (var _tasksCategory in tasksCategory)
            {
                TasksCategory.Add(_tasksCategory);
            }
        }

        public static void AddTaskCategory(TaskCategoryModel taskCategory)
        {
            TasksCategory.Add(taskCategory);
        }

        public static ObservableCollection<TaskCategoryModel> GetTasksCategory()
        {
            return TasksCategory;
        }

        public static IEnumerable<TaskCategoryModel> GetTasksCategoryByTasksListAndIsChecked
        (
            ObservableCollection<TaskModel> tasks,
            bool isChecked
        )
        {
            TasksCategory.Clear();
            
            var _tasksCategory = new ObservableCollection<TaskModel>();
            var random = new Random();

            if (isChecked)
            {
                foreach (var item in tasks)
                {
                    if (item.IsCompleted)
                    {
                        _tasksCategory.Add(item);
                    }
                }
                
                foreach (var taskCategory in _tasksCategory.Select(category => category.Category).Distinct())
                {
                    var item = new TaskCategoryModel {ColorId = random.Next(5), Title = taskCategory};
                    TasksCategory.Add(item);
                }
            }   
            else
            {
                foreach (var item in tasks)
                {
                    if (!item.IsCompleted)
                    {
                        _tasksCategory.Add(item);
                    }
                }
                
                foreach (var taskCategory in _tasksCategory.Select(category => category.Category).Distinct())
                {
                    var item = new TaskCategoryModel {ColorId = random.Next(5), Title = taskCategory};
                    TasksCategory.Add(item);
                }
            }
            return TasksCategory;
        }

        public static void DeleteTaskCategory(TaskCategoryModel taskCategory)
        {
            TasksCategory.Remove(taskCategory);
        }
    }
}