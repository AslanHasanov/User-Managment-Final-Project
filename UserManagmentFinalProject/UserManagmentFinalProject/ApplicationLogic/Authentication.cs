using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentFinalProject.ApplicationLogic.Validations;

namespace UserManagmentFinalProject.ApplicationLogic
{
    public class Authentication
    {
        private static string GetFirstName()
        {
            string firstName = string.Empty;
            bool isExceptionExists = false;

            do
            {
                try
                {
                    Console.Write("Enter your first name :");
                    firstName = Console.ReadLine();
                    isExceptionExists = false;
                }
                catch
                {
                    Console.Write("Something went wrong :");
                    isExceptionExists = true;
                }
            } while (!isExceptionExists && !UserValidation.IsValidFirstName(firstName));


            return firstName;
        }

        private static string GetLastName()
        {
            string lastName = string.Empty;
            bool isExceptionExists = false;

            do
            {
                try
                {
                    Console.Write("Enter your last name :");
                    lastName = Console.ReadLine();
                    isExceptionExists = false;
                }
                catch
                {
                    Console.Write("Something went wrong :");
                    isExceptionExists = true;
                }
            } while (!isExceptionExists && !UserValidation.IsValidLastName(lastName));


            return lastName;
        }
    }
}
