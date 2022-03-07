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
        UsernameAlreadyExists,
        InvalidEmail,
        ServerError
    }

    public interface IAuthenticationService
    {
        Task<User> Login(string email, string password);

        Task<RegistrationResult> Registration(string username, string email, string password);

        Task<User> Verificate(string email, Guid verificationCode);

        Task<User> GetByToken(Guid token);
    }
}
