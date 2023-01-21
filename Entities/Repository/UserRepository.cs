using System.Collections.Generic;
using Entities.Models;

namespace Entities.Repository
{
    public static class UserRepository
    {
        public static List<UserModel> Users = new List<UserModel>();

        public static void RegistrationUser(UserModel user)
        {
            Users.Add(user);
        }

        public static string LoginUser(UserModel user)
        {
            return Users.Contains(user) ? null : "Пользователь с такой почтой уже зарегистрирован";
        }
    }
}