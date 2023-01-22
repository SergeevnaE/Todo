using System.Collections.Generic;
using Entities.Models;

namespace Desktop.Repository
{
    public static class UserRepository
    {
        public static List<UserModel> Users = new List<UserModel>();

        public static string RegistrationUser(UserModel user)
        {
            if (!Users.Contains(user))
            {
                Users.Add(user);
            }
            else
            {
                return "Пользователь с такой почтой уже сущетсвует";
            }

            return null;
        }

        public static string LoginUser(UserModel user) => Users.Contains(user) ? null : "Пользователя с такой почтой не сущетсвует";
    }
}