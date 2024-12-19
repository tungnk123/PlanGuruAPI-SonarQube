using Application.Common.Interface.Persistence;
using Domain.Entities.WikiEntities;
using Domain.Entities.WikiService;
using Microsoft.AspNetCore.Mvc;
using PlanGuruAPI.DTOs.WikiDTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanGuruAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContributionsController : ControllerBase
    {
        private readonly IWikiRepository _wikiRepository;

        public ContributionsController(IWikiRepository wikiRepository)
        {
            _wikiRepository = wikiRepository;
        }

        [HttpPost("{wikiId}/contributions/{contributionId}/approve")]
        public async Task<IActionResult> ApproveContribution(Guid wikiId, Guid contributionId)
        {
            var result = await _wikiRepository.ApproveContributionAsync(wikiId, contributionId);
            if (!result)
            {
                return BadRequest("Failed to approve contribution");
            }

            var updatedWiki = await _wikiRepository.GetByIdAsync(wikiId);
            return Ok(updatedWiki);
        }

        [HttpGet("{wikiId}/pending-contributions")]
        public async Task<IActionResult> GetPendingContributions(Guid wikiId)
        {
            var pendingContributions = await _wikiRepository.GetPendingContributionsAsync(wikiId);
            return Ok(pendingContributions);
        }

        [HttpGet("{wikiId}/contributions/{contributionId}")]
        public async Task<IActionResult> GetOriginalAndContributionContent(Guid wikiId, Guid contributionId)
        {
            var originalContent = await _wikiRepository.GetOriginalContentAsync(wikiId);
            var contributionContent = await _wikiRepository.GetContributionContentAsync(contributionId);

            if (originalContent == null || contributionContent == null)
            {
                return NotFound();
            }

            return Ok(new { OriginalContent = originalContent, ContributionContent = contributionContent });
        }

        [HttpPost("{wikiId}/contributions/{contributionId}/reject")]
        public async Task<IActionResult> RejectContribution(Guid wikiId, Guid contributionId, [FromBody] string reason)
        {
            var result = await _wikiRepository.RejectContributionAsync(wikiId, contributionId, reason);
            if (!result)
            {
                return BadRequest("Failed to reject contribution");
            }

            return Ok("Contribution rejected successfully");
        }

        [HttpGet("{wikiId}/contribution-history")]
        public async Task<IActionResult> GetContributionHistory(Guid wikiId)
        {
            var contributionHistory = await _wikiRepository.GetContributionHistoryAsync(wikiId);
            return Ok(contributionHistory);
        }

        [HttpPost("{wikiId}/contributions")]
        public async Task<IActionResult> CreateContribution(Guid wikiId, [FromBody] CreateContributionRequest request)
        {
            var wiki = await _wikiRepository.GetByIdAsync(wikiId);
            if (wiki == null)
            {
                return NotFound("Wiki not found");
            }

            var contribution = new Contribution
            {
                WikiId = wikiId,
                ContentSections = request.ContentSections,
                ContributorId = request.ContributorId,
                Status = ContributionStatus.Pending
            };

            await _wikiRepository.AddContributionAsync(contribution);

            return Ok(contribution);
        }
    }

}
