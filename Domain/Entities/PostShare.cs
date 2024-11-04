using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostShare
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }    
    }
}
