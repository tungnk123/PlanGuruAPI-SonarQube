using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatImageAndVideo
    {
        public int Id { get; set; }
        public Guid ChatMessageId { get; set; }
        public virtual ChatMessage ChatMessage { get; set; }            
        public string ImageLink { get; set; }
        public string VideoLink { get; set; }       
    }
}
