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
            new UserModel("Ruslan", "ruslan@mail.ru", "12345678"),
            new UserModel("Kirill", "kirill@mail.ru", "87654321")
        };

        public static UserModel RegistrationUser(UserModel user)
        {
            if (Users.Any(item => item.Email == user.Email))
            {
                return null;
            }
            Users.Add(user);
            return user;
        }

        public static UserModel LoginUser(UserModel user) => 
            Users.FirstOrDefault(item => item.Email == user.Email && item.Password == user.Password);
    }
}