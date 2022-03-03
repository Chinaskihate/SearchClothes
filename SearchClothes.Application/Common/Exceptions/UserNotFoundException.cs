using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public string Email { get; set; }
        public UserNotFoundException(string email)
        {
            Email = email;
        }

        public UserNotFoundException(string email, string message) : base(message)
        {
            Email = email;
        }

        public UserNotFoundException(string email, string message, Exception innerException) : base(message, innerException)
        {
            Email = email;
        }
    }
}
