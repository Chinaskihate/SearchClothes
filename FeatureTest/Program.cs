using SearchClothes.Application.Services.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Threading.Tasks;

namespace FeatureTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CodeSender sender = new CodeSender();
            var verification = new Verification()
            {
                Email = "markwantsapi@gmail.com",
                Code = Guid.NewGuid()
            };
            await sender.SendCode(verification);
        }
    }
}
