using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ECommerce
{
    public class Order : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }  
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }      
    }
}
