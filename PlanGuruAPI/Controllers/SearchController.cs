using Application.Common.Interface.Persistence;
using Application.PlantPosts.Common.GetPlantPosts;
using Application.PlantPosts.Query.GetPlantPosts;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.WikiService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PlanGuruAPI.DTOs.PlantPostDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanGuruAPI.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IPlantPostRepository _postRepository;
        private readonly IWikiRepository _wikiRepository;

        public SearchController(IMapper mapper, IMemoryCache cache, IPlantPostRepository postRepository, IWikiRepository wikiRepository)
        {
            _mapper = mapper;
            _cache = cache;
            _postRepository = postRepository;
            _wikiRepository = wikiRepository;
        }

        [HttpGet("plantposts")]
        public async Task<IActionResult> SearchPlantPosts([FromQuery] string query, [FromQuery] int limit = 10, [FromQuery] int page = 1)
        {
            try
            {
                var cacheKey = $"SearchPlantPosts_{query}_{limit}_{page}";
                if (!_cache.TryGetValue(cacheKey, out List<PlantPostDto>? cachedPosts))
                {
                    var allPosts = await _postRepository.GetUnApprovedPost();
                    var filteredPosts = allPosts
                        .Where(p => p.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || p.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                        .Skip((page - 1) * limit)
                        .Take(limit)
                        .ToList();

                    cachedPosts = _mapper.Map<List<PlantPostDto>>(filteredPosts);

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5))
                        .SetSize(1);

                    _cache.Set(cacheKey, cachedPosts, cacheEntryOptions);
                }

                return Ok(cachedPosts);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("wikis")]
        public async Task<IActionResult> SearchWikiTitles([FromQuery] string query)
        {
            var allWikis = await _wikiRepository.GetAllAsync();
            var filteredWikis = allWikis
                .Where(w => w.Title.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Select(w => new { w.Id, w.Title, w.ThumbnailImageUrl })
                .ToList();

            return Ok(filteredWikis);
        }
    }
}
