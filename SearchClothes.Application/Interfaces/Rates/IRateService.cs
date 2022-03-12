using SearchClothes.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SearchClothes.Application.Interfaces.Rates
{
    public interface IRateService
    {
        public Task<bool> RatePost(User user, Post post, int rate);
    }
}
