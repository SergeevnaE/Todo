using Entities.Annotations;

namespace Entities.Models
{
    public class UserModel
    {
        public UserModel([CanBeNull] string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public UserModel() { }

        [CanBeNull] public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}