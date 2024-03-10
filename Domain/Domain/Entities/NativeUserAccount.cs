using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static Domain.ValueObjects.ValueObjects;

namespace Domain.Entities
{
    public class NativeUserAccount
    {
        public string UserName { get; init; }

        public string? FullName { get; set; }

        public DateTime? Created { get; set; }

        public string? Designation { get; set; }

        public bool? IsAdmin { get; set; }

        public List<ProviderUserAccount>? ProviderUserAccounts { get; set; }

        //private NativeUserAccount(string username)
        //{
        //    UserName = username;
        //    //this.FullName = fullname;
        //    Created = DateTime.Now;
        //}

        //public static NativeUserAccount Create(string username)
        //{
        //    //return new NativeUserAccount(username);
        //    NativeUserAccount account = new NativeUserAccount();
        //    account.Created = DateTime.Now;
        //    account.UserName = username; 
        //}
    }

    //public record UserId(string id);    
}
