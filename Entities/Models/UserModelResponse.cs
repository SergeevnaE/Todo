using Entities.Annotations;

namespace Entities.Models
{
    public class UserModelResponse
    {
        [CanBeNull] public UserModel Data { get; set; }
    }
}