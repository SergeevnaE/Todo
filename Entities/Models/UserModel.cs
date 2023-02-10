namespace Entities.Models
{
    public class UserModel
    {
        public UserModel (string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }

        public string name;
        public string email;
        public string password;
    }
}