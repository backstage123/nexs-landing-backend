using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProviderUserAccount
    {
        public string ProviderName { get; private set; }
        
        public string UserName { get; private set; }
        
        public string? FullName { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime Created { get; set; }

        //public string? NativeUserName { get; set; }

        //This constructor is needed for EF Core to work
        private ProviderUserAccount() { }

        private ProviderUserAccount(string username, string providername)
        {
            ProviderName = providername;
            UserName = username;
            Created = DateTime.Now;
        }

        public static ProviderUserAccount Create(string username, string providername)
        {
            return new ProviderUserAccount(username, providername);
        }
    }
}
