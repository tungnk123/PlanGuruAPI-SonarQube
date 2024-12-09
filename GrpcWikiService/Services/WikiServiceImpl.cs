using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interface.Persistence;
using Domain.Entities;
using Domain.Entities.WikiService;
using Grpc.Core;

namespace BonsaiForum.Grpc
{
    public class WikiServiceImpl : WikiService.WikiServiceBase
    {
        private readonly IWikiRepository _wikiRepository;
        private readonly IProductRepository _productRepository;

        public WikiServiceImpl(IWikiRepository wikiRepository, IProductRepository productRepository)
        {
            _wikiRepository = wikiRepository;
            _productRepository = productRepository;
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

            // Fetch products by IDs
            var attachedProducts = await _productRepository.GetProductsByIdsAsync(request.ProductIds);

            // Create a new Wiki instance
            var wiki = new Wiki
            {
                Title = request.Title,
                Description = request.Description,
                ThumbnailImageUrl = request.ThumbnailImageUrl,
                ContentSections = combinedSections,
                AttachedProducts = attachedProducts,
                Status = WikiStatus.Pending,
                AuthorId = Guid.Parse(request.AuthorId),
                Contributors = new List<User> { new User { UserId = Guid.Parse(request.AuthorId) } }.Concat(request.Contributors.Select(c => new User { UserId = Guid.Parse(c) })).ToList(),
                Upvotes = request.Upvotes,
                Downvotes = request.Downvotes
            };

            // Save to the database
            bool isSaved = await SaveWikiArticleToDatabaseAsync(wiki);

            // Return response
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
    }
}
