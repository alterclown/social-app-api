using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Entities.Common
{
    public class ResponseMessage
    {
        public ResponseMessage()
        {
            Pagination = new Pagination();
        }

        // Response related
        public object ResponseObj { get; set; }
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public bool IsUserMessage { get; set; }

        // Pagination
        public Pagination Pagination { get; set; }
    }
}
