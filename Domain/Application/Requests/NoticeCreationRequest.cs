using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class NoticeCreationRequest
    {
        public string Title { get; set; }

        public string Content { get; set; } = "";

        public string AuthorName { get; set; }

        public bool Publish { get; set; } = false;
    }
}
