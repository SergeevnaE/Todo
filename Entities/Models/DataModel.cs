using Entities.Annotations;

namespace Entities.Models
{
    public class DataModel
    {
        [CanBeNull] public TokenModel Data { get; set; }
        [CanBeNull] public TaskModel TaskModel { get; set; }
    }
}