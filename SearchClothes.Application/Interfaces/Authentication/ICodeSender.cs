using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Authentication
{
    public enum CodeSendingResult
    {
        Success,
        InvalidEmail,
        ServerError
    }

    public interface ICodeSender
    {
        public Task<CodeSendingResult> SendCode(Verification verification);
    }
}
