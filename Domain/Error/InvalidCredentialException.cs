using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Error
{
    public class InvalidCredentialException : Exception
    {
        public InvalidCredentialException() : base("Wrong email or password")
        {
            
        }
    }
}
