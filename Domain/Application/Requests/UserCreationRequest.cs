using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class UserCreationRequest
    {
        public string UserName { get; set; }

        public string ProviderName { get; set; }
    }
}
