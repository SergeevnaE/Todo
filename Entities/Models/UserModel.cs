using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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