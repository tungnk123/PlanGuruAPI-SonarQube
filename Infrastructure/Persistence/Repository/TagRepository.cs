using Application.Common.Interface.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly string _fileName = "tags.json";
        private readonly string _filePath;

        public TagRepository()
        {
            _filePath = Path.Combine(Directory.GetCurrentDirectory(), _fileName);
        }

        public async Task<List<string>> GetTagsAsync()
        {
            if (!File.Exists(_filePath))
            {
                return new List<string>();
            }

            var jsonContent = await File.ReadAllTextAsync(_filePath);
            Console.WriteLine($"JSON Content: {jsonContent}"); // Log the JSON content for debugging

            try
            {
                var tagData = JsonConvert.DeserializeObject<TagData>(jsonContent);
                return tagData?.Tags ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return new List<string>();
            }
        }
    }

    public class TagData
    {
        public List<string> Tags { get; set; } = new List<string>();
    }
}
