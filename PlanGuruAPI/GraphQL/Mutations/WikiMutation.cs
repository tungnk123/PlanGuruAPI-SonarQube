using Application.Common.Interface.Persistence;
using Domain.Entities.WikiService;
using GraphQL;
using GraphQL.Types;
using PlanGuruAPI.DTOs.WikiDTOs;
using PlanGuruAPI.GraphQL.Types;

namespace PlanGuruAPI.GraphQL.Mutations
{
    public class WikiMutation : ObjectGraphType
    {
        public WikiMutation(IWikiRepository wikiRepository)
        {
            #region CreateWiki
            //FieldAsync<WikiType>(
            //    "createWiki",
            //    arguments: new QueryArguments(
            //        new QueryArgument<NonNullGraphType<CreateWikiArticleRequestType>> { Name = "wiki" }
            //    ),
            //    resolve: async context =>
            //    {
            //        var wikiInput = context.GetArgument<CreateWikiArticleRequest>("wiki");
            //        var wiki = new Wiki
            //        {
            //            Title = wikiInput.Title,
            //            Description = wikiInput.Description,
            //            ThumbnailImageUrl = wikiInput.ThumbnailImageUrl,
            //            ContentSections = wikiInput.ContentSections.Select(cs => new ContentSection
            //            {
            //                SectionName = cs.SectionName,
            //                Content = cs.Content,
            //                ImageUrls = cs.ImageUrls.ToList()
            //            }).ToList()
            //        };
            //        await wikiRepository.AddWikiAsync(wiki);
            //        return wiki;
            //    });
            #endregion

            FieldAsync<WikiType>(
                "updateWiki",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<UpdateWikiArticleRequestType>> { Name = "wiki" }
                ),
                resolve: async context =>
                {
                    try
                    {
                        var idInput = context.GetArgument<string>("id"); // Lấy giá trị dưới dạng chuỗi
                        Console.WriteLine($"Received id: {idInput}");

                        // Kiểm tra nếu `idInput` là một GUID hợp lệ trước khi chuyển đổi
                        if (!Guid.TryParse(idInput, out var id))
                        {
                            throw new FormatException($"Invalid GUID format: {idInput}");
                        }

                        var wikiInput = context.GetArgument<UpdateWikiArticleRequest>("wiki");
                        var existingWiki = await wikiRepository.GetByIdAsync(id);

                        if (existingWiki == null)
                        {
                            context.Errors.Add(new ExecutionError("Wiki not found"));
                            return null;
                        }

                        existingWiki.Title = wikiInput.Title;
                        existingWiki.Description = wikiInput.Description;
                        existingWiki.ThumbnailImageUrl = wikiInput.ThumbnailImageUrl;
                        existingWiki.ContentSections = wikiInput.ContentSections.Select(cs => new ContentSection
                        {
                            SectionName = cs.SectionName,
                            Content = cs.Content,
                            ImageUrls = cs.ImageUrls.ToList()
                        }).ToList();

                        await wikiRepository.UpdateWikiAsync(existingWiki, wikiInput.ProductIds);
                        return existingWiki;

                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FormatException: {ex.Message}");
                        context.Errors.Add(new ExecutionError($"Invalid GUID format: {ex.Message}"));
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception: {ex.Message}");
                        context.Errors.Add(new ExecutionError($"An error occurred: {ex.Message}"));
                        return null;
                    }
                });
        }
    }
}
