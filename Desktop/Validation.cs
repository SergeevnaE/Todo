namespace Desktop
{
    public static class Validation
    {
        public static string PassValid(string pass)
        {
            return pass.Length >= 7 ? "" : "Длина должна быть больше 7 символов";
        }
    }
}