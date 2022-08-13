using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagmentFinalProject.ApplicationLogic.Validations
{
    public static class Validation
    {
        public static bool IsLengthBetween(string text, int start, int end)
        {
            return text.Length >= start && text.Length < end;
        }

        public static void Typewrite(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
