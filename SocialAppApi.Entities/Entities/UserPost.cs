using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Entities
{
      public class UserPost
    {
        public int UserPostId {get; set; }
        public int senderId {get; set; }
        public string message {get; set; }
        public DateTime createdAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}