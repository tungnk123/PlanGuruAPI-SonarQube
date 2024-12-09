using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.WikiService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace BonsaiForum.Grpc
{
    public class WikiServiceImpl : WikiService.WikiServiceBase
    {
        private readonly IWikiRepository _wikiRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public WikiServiceImpl(IWikiRepository wikiRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _wikiRepository = wikiRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public override async Task<CreateWikiArticleResponse> CreateWikiArticle(CreateWikiArticleRequest request, ServerCallContext context)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return new CreateWikiArticleResponse
                {
                    Success = false,
                    Message = "Title is required."
                };
            }

            // Initialize default sections
            var defaultSections = new List<Domain.Entities.WikiService.ContentSection>
                        {
                            new() { SectionName = "Season", Content = "", ImageUrls = { } },
                            new() { SectionName = "Height", Content = "", ImageUrls = { } },
                            new() { SectionName = "Interesting Information", Content = "", ImageUrls = { } },
                            new() { SectionName = "Care Instructions", Content = "", ImageUrls = { } },
                        };

            // Combine default sections with provided sections
            var combinedSections = defaultSections;
            combinedSections.AddRange(request.ContentSections.Select(cs => new Domain.Entities.WikiService.ContentSection
            {
                SectionName = cs.SectionName,
                Content = cs.Content,
                ImageUrls = cs.ImageUrls.ToList()
            }));

            var attachedProducts = await _productRepository.GetProductsByIdsAsync(request.ProductIds);

            var wiki = new Wiki
            {
                Title = request.Title,
                Description = request.Description,
                ThumbnailImageUrl = request.ThumbnailImageUrl,
                ContentSections = combinedSections,
                AttachedProducts = attachedProducts,
                Status = WikiStatus.Pending,
                AuthorId = Guid.Parse(request.AuthorId),
                Contributors = new List<User> { new() { UserId = Guid.Parse(request.AuthorId) } },
                Upvotes = 0,
                Downvotes = 0
            };

            bool isSaved = await SaveWikiArticleToDatabaseAsync(wiki);

            return new CreateWikiArticleResponse
            {
                Success = isSaved,
                Message = isSaved ? "Wiki article created successfully." : "Failed to create the wiki article.",
                ArticleId = isSaved ? wiki.Id.ToString() : string.Empty
            };
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

        public override async Task<GetSampleCreateWikiArticleRequestResponse> GetSampleCreateWikiArticleRequest(Empty request, ServerCallContext context)
        {
            // Get a real user ID
            var author = await _userRepository.GetFirstUserAsync();
            if (author == null)
            {
                throw new Exception("No users found in the database.");
            }

            // Get real product IDs
            var products = await _productRepository.GetFirstNProductsAsync(2);
            if (products.Count < 2)
            {
                throw new Exception("Not enough products found in the database.");
            }

            var sampleRequest = new CreateWikiArticleRequest
            {
                Title = "Sample Wiki Article",
                Description = "This is a sample description for the wiki article.",
                ThumbnailImageUrl = "sample-thumbnail.png",
                AuthorId = author.UserId.ToString(),
                ContentSections =
                    {
                        new ContentSection { SectionName = "Sample Section 1", Content = "Sample content for section 1", ImageUrls = { "image1.png" } },
                        new ContentSection { SectionName = "Sample Section 2", Content = "Sample content for section 2", ImageUrls = { "image2.png" } }
                    },
                ProductIds = { products[0].Id.ToString(), products[1].Id.ToString() }
            };

            var jsonString = JsonSerializer.Serialize(sampleRequest);

            return new GetSampleCreateWikiArticleRequestResponse
            {
                JsonString = jsonString
            };
        }
    }
}
