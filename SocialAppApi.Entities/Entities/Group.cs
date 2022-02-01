using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Entities
{
      public class Group
    {
        public int groupId {get; set; }
        public int createdBy {get; set; }
        public int updatedBy {get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string profile { get; set; }
        public string content { get; set; }

    }
}