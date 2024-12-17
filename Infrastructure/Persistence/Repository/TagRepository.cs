using Application.Common.Interface.Persistence;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly List<string> _tags;
        private readonly List<string> _filters;

        public TagRepository()
        {
            // Hardcoded list of tags
            _tags = new List<string>
                {
                    "plants",
                    "flowers",
                    "guides",
                    "diseases",
                    "qna",
                    "diy"
                };

            // Hardcoded list of filters
            _filters = new List<string>
                {
                    "trending",
                    "upvote",
                    "time"
                };
        }

        public Task<List<string>> GetTagsAsync()
        {
            return Task.FromResult(_tags);
        }

        public Task<List<string>> GetFiltersAsync()
        {
            return Task.FromResult(_filters);
        }
    }
}
