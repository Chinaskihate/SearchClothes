using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(Guid postId)
        {
            PostId = postId;
        }

        public PostNotFoundException(Guid postId, string message) : base(message)
        {
            PostId = postId;
        }

        public PostNotFoundException(Guid postId, string message, Exception innerException) : base(message, innerException)
        {
            PostId = postId;
        }

        public Guid PostId { get; set; }
    }
}
