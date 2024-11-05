using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostDevote
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }  
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }      
    }
}
