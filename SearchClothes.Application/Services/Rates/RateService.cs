using SearchClothes.Application.Interfaces.DataServices;
using SearchClothes.Application.Interfaces.Rates;
using SearchClothes.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SearchClothes.Application.Services.Rates
{
    public class RateService : IRateService
    {
        private readonly IRateDataService _rateDataService;

        public RateService(IRateDataService rateDataService)
        {
            _rateDataService = rateDataService;
        }

        public async Task<bool> RatePost(User user, Post post, int rate)
        {
            if (user.Id == post.CreatorId)
            {
                return false;
            }
            if (rate < 0 || rate > 5)
            {
                return false;
            }
            var prevRate = (await _rateDataService.GetByUserId(user.Id))
                                                  .FirstOrDefault(r => r.PostId == post.Id);
            if (prevRate == null)
            {
                var rateModel = new Rate()
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    PostId = post.Id,
                    Value = rate
                };
                rateModel = await _rateDataService.Create(rateModel);
            }
            else
            {
                prevRate.Value = rate;
                prevRate = await _rateDataService.Update(prevRate.Id, prevRate);
            }
            return true;
        }
    }
}
