using System.Windows.Controls;

namespace Desktop
{
    public static class ExtensionsTextBox
    {
        public static string ValidPass(this TextBox tb)
        {
            if(tb.Text.Length >= 7)
            {
                
            }
            
            return tb.Text.Length == 7 ? "" : "Длина должна быть больше 7 символов";
        }
    }
}