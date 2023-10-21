using System.Text;
using System.Text.RegularExpressions;

namespace Security
{
    public static class StringHelper
    {
        private const string ValidCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string SpecialCharacters = "!@#$%&()+-=[]{}|'\"?/";
        private const string FORMAT_PASSWORD = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=*!])[A-Za-z\d@#$%^&+=*!]{8,}$";

        public static string GenerateUniqueCode(int? length = null)
        {
            if (length == null || length == 0) return Guid.NewGuid().ToString();
            return Guid.NewGuid().ToString().Substring(0, length.Value);
        }

        public static string GeneratePassword(int length, int lengthSpecialCharacter)
        {
            StringBuilder password = new StringBuilder();
            Random rd = new Random();

            for (int i = 1; i < length - lengthSpecialCharacter; i++)
            {
                password.Append(ValidCharacters[rd.Next(ValidCharacters.Length)]);
            }

            for (int i = 0; i < lengthSpecialCharacter - 1; i++)
            {
                password.Append(SpecialCharacters[rd.Next(SpecialCharacters.Length)]);
            }

            string newPassword = new string(password.ToString().ToCharArray().Shuffle());

            return newPassword;
        }

        public static bool IsCorrectPasswordFormat(string password)
        {
            Regex regex = new Regex(FORMAT_PASSWORD);
            return regex.IsMatch(password);
        }
    }

    static class Extensions
    {
        public static T[] Shuffle<T>(this T[] array)
        {
            Random random = new Random();
            int n = array.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }
    }
}
