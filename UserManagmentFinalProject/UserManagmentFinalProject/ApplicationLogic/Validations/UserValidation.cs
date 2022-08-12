using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserManagmentFinalProject.ApplicationLogic.Validations
{
    internal class UserValidation
    {
        public static bool IsValidFirstName(string firstName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{3,30})$");

            if (regex.IsMatch(firstName))
            {
                return true;
            }
            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters," +
                " the first letter is capitalized, and the length is greater than 3 and less than 30.");


            return false;
        }

        public static bool IsValidLastName(string lastName)
        {
            Regex regex = new Regex(@"^(?=[A-Z]{1})([A-Za-z]{4,29})$");
            if (regex.IsMatch(lastName))
            {
                return true;
            }
            Console.WriteLine("The name you entered is incorrect, make sure the name contains only letters," +
                "the first letter is capitalized, and the length is greater than 3 and less than 30.");


            return false;
        }
    }
}
