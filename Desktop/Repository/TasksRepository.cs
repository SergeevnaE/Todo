using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Desktop.Api;
using Entities.Models;

namespace Desktop.Repository
{
    public static class TasksRepository
    {

        private static ObservableCollection<TaskModel> Tasks;

        static TasksRepository()
        {
            Tasks = new ApiClientImpl().GetTasksAsync()?.Result;
        }
        public static bool GetIsCheckedTask(TaskModel task)
        {
            return task.IsCompleted;
        }
        
        public static ObservableCollection<TaskModel> GetTasks()
        {
            Tasks = new ApiClientImpl().GetTasksAsync()?.Result;
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
                    if (task.IsCompleted && taskCategory.Title == task.Category)
                    {
                        tasks.Add(task);
                    }
                }
            }
            else
            {
                foreach (var task in Tasks)
                {
                    if (!task.IsCompleted && taskCategory.Title == task.Category)
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
            task.IsCompleted = true;
        }
    }
}