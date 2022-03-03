using Microsoft.AspNet.Identity;
using SearchClothes.Application.Common.Exceptions;
using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserService _userService;
        private IVerificationService _verificationService;
        private IPasswordHasher _passwordHasher;
        private ICodeSender _codeSender;

        public AuthenticationService(IUserService userService, IVerificationService verificationService,
            IPasswordHasher passwordHasher, ICodeSender codeSender)
        {
            _userService = userService;
            _verificationService = verificationService;
            _passwordHasher = passwordHasher;
            _codeSender = codeSender;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = await _userService.GetByEmail(email);
            if (user == null)
            {
                throw new UserNotFoundException(email);
            }
            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(user.PasswordHash, password);
            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }
            return user;
        }

        public async Task<RegistrationResult> Registration(string username, string email, string password)
        {
            var verification = await _verificationService.GetByUsername(username);
            if (verification != null)
            {
                return RegistrationResult.UsernameAlreadyExists;
            }
            verification = await _verificationService.GetByEmail(username);
            if (verification != null)
            {
                return RegistrationResult.EmailAlreadyExists;
            }
            var newUser = new Verification()
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = _passwordHasher.HashPassword(password),
                Code = Guid.NewGuid()
            };
            await _verificationService.Create(newUser);
            var res = await _codeSender.SendCode(newUser);
            if (res == CodeSendingResult.ServerError)
            {
                return RegistrationResult.ServerError;
            }
            if (res == CodeSendingResult.InvalidEmail)
            {
                return RegistrationResult.InvalidEmail;
            }
            return RegistrationResult.Success;
        }

        public async Task<User> Verificate(string email, Guid verificationCode)
        {
            var verification = await _verificationService.GetByEmail(email);
            if (verification == null)
            {
                throw new UserNotFoundException(email);
            }
            if (verification.Code != verificationCode)
            {
                throw new InvalidVerificationCode(email, verificationCode);
            }
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Username = verification.Username,
                PasswordHash = verification.PasswordHash,
                Email = verification.Email,
                Token = Guid.NewGuid(),
                CreatedPosts = new List<Post>(),
                RatedPosts = new List<Post>()
            };
            await _userService.Create(user);
            return user;
        }
    }
}
