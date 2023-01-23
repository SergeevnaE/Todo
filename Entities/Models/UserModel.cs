namespace Entities.Models
{
    public class UserModel
    {
        public UserModel(string name, string email, string password)
        {
            UserName = name;
            UserEmail = email;
            UserPassword = password;
        }

        public string UserName;
        public string UserEmail;
        public string UserPassword;
    }
}