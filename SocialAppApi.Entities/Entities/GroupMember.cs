using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Entities
{
      public class GroupMember
    {
        public int groupMemberId {get; set; }
        public int roleId {get; set; }
        public string status {get; set; }
        public DateTime createdAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string notes { get; set; }

    }
}