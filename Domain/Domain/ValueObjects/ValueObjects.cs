using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class ValueObjects
    {
        public record Name(string FirstName, string LastName);

    }
}
