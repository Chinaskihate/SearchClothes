using SearchClothes.Application.Interfaces.Authentication;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Authentication
{
    public class CodeSender : ICodeSender
    {
        public Task<CodeSendingResult> SendCode(Verification verification)
        {
            throw new NotImplementedException();
        }
    }
}
