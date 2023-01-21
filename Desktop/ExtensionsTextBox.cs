using System;
using System.Net.Mail;
using System.Windows.Controls;
using System.Windows.Media;

namespace Desktop
{
    public static class ExtensionsTextBox
    {
        public static string ValidEmail(this TextBox tb)
        {
            try
            {
                var address = new MailAddress(tb.Text);
                if (address.Address == tb.Text && tb.Text.Contains("."))
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
            catch
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
                }
                else
                {
                    startPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    endPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    return "Пароли не совпадают";
                }
            }
            else
            {
                endPassword.BorderBrush = new SolidColorBrush(Colors.Gray);
                return null;
            }
        }
    }
}