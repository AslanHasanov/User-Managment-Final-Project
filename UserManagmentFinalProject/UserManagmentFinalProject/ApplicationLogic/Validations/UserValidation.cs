using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserManagmentFinalProject.DataBase.Repo;

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

        public static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^[A-Za-z0-9]{10,20}@code\.edu\.az$");
            if (regex.IsMatch(email))
            {
                return true;
            }
            Console.WriteLine("The email you entered is incorrect");


            return false;
        }

        public static bool IsUserExist(string email)
        {
            if (UserRepo.IsUserExistsByEmail(email))
            {
                Console.WriteLine("User already exists");
                return true;
            }


            return false;
        }

        public static bool IsPasswordsMatch(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }
            Console.WriteLine("Password is not match");


            return false;

        }

        public static bool IsValidPassword(string password)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
            if (regex.IsMatch(password))
            {
                return true;
            }
            Console.WriteLine("The password you entered is incorrect");


            return false;
        }
    }
}
