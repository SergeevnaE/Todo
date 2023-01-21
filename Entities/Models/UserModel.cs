namespace Entities.Models
{
    public class UserModel
    {
        public UserModel(string name, string email, string password)
        {
            _userName = name;
            _userEmail = email;
            _userPassword = password;
        }

        private string _userName;
        private string _userEmail;
        private string _userPassword;
    }
}