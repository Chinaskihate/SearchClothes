using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Authentication
{
    public enum RegistrationResult
    {
        Success,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }

    public interface IAuthenticationService
    {
        Task<User> Login(string username, string passwordHash);

        Task<RegistrationResult> Registration(string username, string email, string passwordHash);

        Task<User> Verificate(string username, string email, string passwordHash, Guid verificationCode);
    }
}
