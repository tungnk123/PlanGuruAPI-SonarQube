using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.WikiService
{
    public class ContentSection
    {
        // auto increment id
        public int Id { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public List<string> ImageUrls { get; set; } = new();
    }
}

