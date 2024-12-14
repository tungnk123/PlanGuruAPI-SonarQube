using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.WikiService;
using Microsoft.AspNetCore.Mvc;
using PlanGuruAPI.DTOs.WikiDTOs;

namespace PlanGuruAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WikiController : ControllerBase
    {
        private readonly IWikiRepository _wikiRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public WikiController(IWikiRepository wikiRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _wikiRepository = wikiRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        [HttpPost("CreateWikiArticle")]
        public async Task<IActionResult> CreateWikiArticle([FromBody] CreateWikiArticleRequest request)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return BadRequest(new CreateWikiArticleResponse
                {
                    Success = false,
                    Message = "Title is required."
                });
            }

            // Initialize default sections
            var defaultSections = new List<ContentSection>
                            {
                                new() { SectionName = "Season", Content = "", ImageUrls = { } },
                                new() { SectionName = "Height", Content = "", ImageUrls = { } },
                                new() { SectionName = "Interesting Information", Content = "", ImageUrls = { } },
                                new() { SectionName = "Care Instructions", Content = "", ImageUrls = { } },
                            };

            // Combine default sections with provided sections
            var combinedSections = defaultSections;
            combinedSections.AddRange(request.ContentSections.Select(cs => new ContentSection
            {
                SectionName = cs.SectionName,
                Content = cs.Content,
                ImageUrls = cs.ImageUrls.ToList()
            }));

            var attachedProducts = await _productRepository.GetProductsByIdsAsync(request.ProductIds);
            var author = await _userRepository.GetByIdAsync(Guid.Parse(request.AuthorId));

            if (author == null)
            {
                return BadRequest(new CreateWikiArticleResponse
                {
                    Success = false,
                    Message = "Author not found."
                });
            }

            var wiki = new Wiki
            {
                Title = request.Title,
                Description = request.Description,
                ThumbnailImageUrl = request.ThumbnailImageUrl,
                ContentSections = combinedSections,
                AttachedProducts = attachedProducts,
                Status = WikiStatus.Pending,
                AuthorId = Guid.Parse(request.AuthorId),
                Contributors = new List<User> { author },
                Upvotes = 0,
                Downvotes = 0
            };

            bool isSaved = await SaveWikiArticleToDatabaseAsync(wiki);

            if (!isSaved)
            {
                return BadRequest(new CreateWikiArticleResponse
                {
                    Success = false,
                    Message = "Failed to insert the wiki article into database"
                });
            }

            return Ok(new CreateWikiArticleResponse
            {
                Success = isSaved,
                Message = "Wiki article created successfully.",
                ArticleId = wiki.Id.ToString()
            });
        }

        private async Task<bool> SaveWikiArticleToDatabaseAsync(Wiki wiki)
        {
            try
            {
                await _wikiRepository.AddWikiAsync(wiki);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // get sample request for CreateWikiArticle
        [HttpGet("GetSampleCreateWikiArticleRequest")]
        public async Task<IActionResult> GetSampleCreateWikiArticleRequest()
        {
            var author = await _userRepository.GetFirstUserAsync();
            if (author == null)
            {
                return BadRequest("No users found in the database.");
            }
            var products = await _productRepository.GetFirstNProductsAsync(2);
            if (products.Count < 2)
            {
                return BadRequest("Not enough products found in the database.");
            }
            var sampleRequest = new CreateWikiArticleRequest
            {
                Title = "Sample Wiki Article",
                Description = "This is a sample description for the wiki article.",
                ThumbnailImageUrl = "sample-thumbnail.png",
                AuthorId = author.UserId.ToString(),
                ContentSections = new List<ContentSectionRequest>
                {
                    new() { SectionName = "Season", Content = "Spring", ImageUrls = { "spring-image.png" } },
                    new() { SectionName = "Height", Content = "10-20 feet", ImageUrls = { "height-image.png" } },
                    new() { SectionName = "Interesting Information", Content = "Interesting information about the plant.", ImageUrls = { "interesting-image.png" } },
                    new() { SectionName = "Care Instructions", Content = "Care instructions for the plant.", ImageUrls = { "care-image.png" } }
                },
                ProductIds = products.Select(p => p.Id.ToString()).ToList()
            };
            return Ok(sampleRequest);
        }
    }
}
