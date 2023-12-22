using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using Desktop.Windows;
using Entities.Models;

namespace Desktop.Repository
{
    public static class UserRepository
    {
        private static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel("Liza", "zaicaliza@gmail.ru", "lizka345_SER"),
        };

        public static UserModel RegistrationUser(UserModel user)
        {
            if (Users.Any(item => item.UserEmail == user.UserEmail))
            {
                return null;
            }
            Users.Add(user);
            return user;
        }

        public static UserModel LoginUser(UserModel user) => 
            Users.FirstOrDefault(item => item.UserEmail == user.UserEmail && item.UserPassword == user.UserPassword);
    }
}