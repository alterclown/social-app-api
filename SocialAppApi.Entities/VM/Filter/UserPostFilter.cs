using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.VM.Filter
{
    public class UserPostFilterByID
    {
        public int UserPostId { get; set; }
    }

    public class UserPostFilter
    {
        public string Message { get; set; }
    }
}
