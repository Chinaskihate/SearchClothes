using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(SearchClothesDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
