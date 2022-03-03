using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Domain.Models
{
    public class Verification : DomainObject
    {
        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public Guid Code { get; set; }

        public bool IsVerificated { get; set; }
    }
}
