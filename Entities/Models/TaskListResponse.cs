using System.Collections.ObjectModel;

namespace Entities.Models
{
    public class TaskListResponse
    {
        public ObservableCollection<TaskModel> Data { get; set; }
    }
}