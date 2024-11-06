using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Error
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException() : base("This email is already sign up")
        {
            
        }
    }
}
