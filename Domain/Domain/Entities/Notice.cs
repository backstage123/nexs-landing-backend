using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Notice
    {
        public int Id { get; private set; }

        public string Title { get; private set; }

        public string? Content { get; set; }

        public DateTime Created { get; private set; }

        public DateTime? Updated { get; set; }

        public string AuthorName { get; set; }

        private Notice() { }

        private Notice(string title, string authorname)
        {
            Title = title;         
            AuthorName = authorname;
            Created = DateTime.Now;
            Updated = Created;
        }

        public static Notice Create(string title, string authorname)
        {
            return new Notice(title, authorname);
        }
    }
}
