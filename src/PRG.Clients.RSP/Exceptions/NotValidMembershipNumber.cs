using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG.Clients.RSP.Exceptions
{
    public class NotValidMembershipNumber : Exception
    {
        public NotValidMembershipNumber() :
            base("The given membership number is not valid. It should of 16 digit length exactly.")
        {
        }

        public NotValidMembershipNumber(string message)
            : base(message)
        {

        }
    }
}
