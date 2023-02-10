using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Desktop
{
    public static class Validator
    {
        public static string PassValid(string pass) => pass.Length >= 6 ? null : "Длина пароля должна быть не менее 6 символов!";

        public static string NameValid(string name) => name.Length >= 3 ? null : "Введено имя менее 3 символов";

        public static string ComparisonPass(string pass, string replayPass) => pass == replayPass ? null : "Пароли не совпадают!";

        public static string MailValid(string mail)
        {
            try
            {
                return Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") ? null : "Неверная форма ввода почты";
            }
            catch
            {
                return "Неверная форма ввода почты";
            }
        }
    }
}
