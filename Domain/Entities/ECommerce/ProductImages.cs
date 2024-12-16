using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ECommerce
{
    public class ProductImages
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public string Image { get; set; }
    }
}
