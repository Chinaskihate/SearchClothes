using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Exceptions
{
    public class InvalidVerificationCode : Exception
    {
        public string Email { get; set; }
        public Guid Code { get; set; }

        public InvalidVerificationCode(string email, Guid code, string message) : base(message)
        {
            Email = email;
            Code = code;
        }

        public InvalidVerificationCode(string email, Guid code, string message, Exception innerException) : base(message, innerException)
        {
            Email = email;
            Code = code;
        }

        public InvalidVerificationCode(string email, Guid code)
        {
            Email = email;
            Code = code;
        }
    }
}
