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
    }
}
