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
        public static string PassValid(string pass)
        {
            if (pass.Length >= 6)
            {
                return null;
            }

            return "Длина пароля должна быть не менее 6 символов!";
        }

        public static string NameValid(string name)
        {
            if (name.Length >= 3)
            {
                return null;
            }

            return "Введено имя менее 3 символов";
        }

        public static string ComparisonPass(string pass, string replayPass)
        {
            if (pass == replayPass)
            {
                return null;
            }
            else
            {
                return "Пароли не совпадают!";
            }
        }

        public static string MailValid(string mail)
        {
            try
            {
                if (Regex.IsMatch(mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    return null;
                }
                else
                {
                    return "Неверная форма ввода почты";
                }
            }
            catch
            {
                return "Неверная форма ввода почты";
            }
        }
    }
}
