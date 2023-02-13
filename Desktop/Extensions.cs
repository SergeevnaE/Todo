using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace Desktop
{
    public static class Extensions
    {

        public static string ValidIsNull(this TextBox tb)
        {
            if (tb.Text != "")
            {
                tb.BorderBrush = new SolidColorBrush(Colors.White);
                return null;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Поле не должно быть пустым";
            }
        }
        
        public static string ValidEmail(this TextBox tb)
        {
            var regex = new Regex(@"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)");
            var matchCollection = regex.Matches(tb.Text);

            if (matchCollection.Count != 0)
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Gray);
                return null;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Неккоректная почта. Пример: example@yandex.ru";
            }
        }

        public static string ValidName(this TextBox tb)
        {
            if (tb.Text.Length >= 3)
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Gray);
                return null;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Имя должно содержать не менее 3 символов";
            }
        }
        
        public static string ValidPassword(this TextBox tb)
        {
            if (tb.Text.Length >= 6)
            {  
                tb.BorderBrush = new SolidColorBrush(Colors.Gray);
                return null;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Пароль должен содержать не менее 6 символов";
            }
        }

        public static string ValidConfirmPassword(this TextBox endPassword, TextBox startPassword)
        {

            if (startPassword.ValidPassword() == null)
            {
                if (startPassword.Text == endPassword.Text)
                {
                    startPassword.BorderBrush = new SolidColorBrush(Colors.Gray);
                    endPassword.BorderBrush = new SolidColorBrush(Colors.Gray);
                    return null;
                } else
                {
                    startPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    endPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    return "Пароли не совпадают";
                }
            } else
            {
                endPassword.BorderBrush = new SolidColorBrush(Colors.Gray);
                return null;
            }
        }

        public static string ValidDate(this DatePicker dp)
        {
            if (dp.Text != "")
            {
                dp.BorderBrush = new SolidColorBrush(Colors.White);
                return null;
            }
            else
            {
                dp.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Выберите дату";
            }
        }

        public static string ValidTime(this TextBox tb)
        {
            var regex = new Regex("([01]?[0-9]|2[0-3]):[0-5][0-9]");
            var matchCollection = regex.Matches(tb.Text);
            if (matchCollection.Count != 0)
            {
                tb.BorderBrush = new SolidColorBrush(Colors.White);
                return null;
            }
            else
            {
                tb.BorderBrush = new SolidColorBrush(Colors.Red);
                return "Неверный формат времени. Пример: " + DateTime.Now.ToString("HH:mm");
            }
        }
    }
}