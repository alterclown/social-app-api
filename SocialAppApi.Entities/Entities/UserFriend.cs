using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Entities
{
      public class UserFriend
    {
        public int UserFriendId {get; set; }
        public string FirstName {get; set; }
        public string LastName {get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Text { get; set; }
        public int UserId {get; set; }

    }
}