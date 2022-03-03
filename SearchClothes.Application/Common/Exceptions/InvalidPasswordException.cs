using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Exceptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public InvalidPasswordException(string email, string password, string message) : base(message)
        {
            Email = email;
            Password = password;
        }

        public InvalidPasswordException(string email, string password, string message, Exception innerException) :
            base(message, innerException)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }

    }
}
