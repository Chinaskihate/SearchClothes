using System;

namespace SearchClothes.Application.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string email, Guid id, Guid token)
        {
            Email = email;
            Id = id;
            Token = token;
        }

        public string Email { get; set; }

        public Guid Id { get; set; }

        public Guid Token { get; set; }


    }
}
