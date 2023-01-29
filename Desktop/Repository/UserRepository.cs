using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Desktop.Repository
{
    public static class UserRepository
    {
        private static readonly List<UserModel> Users = new List<UserModel>
        {
            new UserModel("Elizaveta", "zaicaliza12@gmail.com", "lizKA04"),
            new UserModel("Den", "deniskafrolkin@gmail.com", "dddEEEn123456")
        };
        
        public static UserModel RegistrationUser(UserModel user)
        {
            if (Users.Any(item => item.email == user.email))
            {
                return null;
            }
            Users.Add(user);
            return user;
        }

        public static UserModel LoginUser(UserModel user) =>
            Users.FirstOrDefault(item => item.email == user.email && item.password == user.password);
    }
    

}
