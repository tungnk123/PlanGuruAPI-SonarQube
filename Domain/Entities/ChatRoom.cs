using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ChatRoom
    {
        public Guid ChatRoomId { get; set; }
        public Guid User1Id { get; set; }
        public virtual User User1 { get; set; }      
        public Guid User2Id { get; set; }
        public virtual User User2 { get; set; }         
        public DateTime CreatedAt { get; set; }
        public ICollection<ChatMessage> ChatMessages { get; set; }          
    }
}
