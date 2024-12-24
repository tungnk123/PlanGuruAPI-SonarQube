using Domain.Entities.ECommerce;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostImage
    {
        [Key]
        public int Id { get; set; }
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        public string Image { get; set; }
    }
}
