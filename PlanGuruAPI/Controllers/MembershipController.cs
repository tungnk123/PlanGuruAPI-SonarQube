using AutoMapper;
using Domain.Entities;
using GraphQL.Validation.Complexity;
using GraphQL.Validation.Rules;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanGuruAPI.DTOs.Membership;

namespace PlanGuruAPI.Controllers
{
    [Route("api/membership")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly PlanGuruDBContext _context;
        private readonly IMapper _mapper;

        public MembershipController(PlanGuruDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listMembership = await _context.Memberships.OrderByDescending(p => p.CreatedAt).ToListAsync();
            return Ok(listMembership);
        }
        [HttpGet("membershipHistory")]
        public async Task<IActionResult> GetMembershipHistory()
        {
            var listMembershipHistory = await _context.MembershipsHistory.Include(p => p.User).OrderByDescending(p => p.CreatedAt).ToListAsync();
            var listMembershipReadDTO = new List<MembershipHistoryReadDTO>();
            foreach (var membershipHistory in listMembershipHistory)
            {
                var membershipReadDTO = new MembershipHistoryReadDTO()
                {
                    UserId = membershipHistory.UserId,
                    Email = membershipHistory.User.Email,
                    Name = membershipHistory.User.Name,
                    BoughtAt = membershipHistory.CreatedAt,
                    PackageName = membershipHistory.PackageName,
                    PackagePrice = membershipHistory.PackagePrice
                };
                listMembershipReadDTO.Add(membershipReadDTO);
            }
            return Ok(listMembershipReadDTO);
        }
        [HttpGet("{membershipId}")]
        public async Task<IActionResult> GetById(Guid membershipId)
        {
            var membership = await _context.Memberships.FindAsync(membershipId);       
            if (membership == null)
            {
                return NotFound("Can't find this membership");
            }
            return Ok(membership);      
        }
        [HttpPost]
        public async Task<IActionResult> CreateMembership(MembershipCreateDTO membershipCreateDTO)
        {
            var newMembership = _mapper.Map<Membership>(membershipCreateDTO);
            newMembership.Id = Guid.NewGuid();  
            newMembership.CreatedAt = DateTime.Now; 
            await _context.Memberships.AddAsync(newMembership);    
            await _context.SaveChangesAsync();  
            return Ok(newMembership);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMembership(MembershipUpdateDTO membership)
        {
            var existMembership = await _context.Memberships.FindAsync(membership.Id);
            if (existMembership == null)
            {
                return BadRequest("This membership is not exist");
            }
            existMembership.Name = membership.Name;
            existMembership.Description = membership.Description;   
            existMembership.Price = membership.Price;
            existMembership.LastModifiedAt = DateTime.Now;  
            await _context.SaveChangesAsync();
            return Ok(existMembership);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMembership(Guid id)
        {
            var existMembership = await _context.Memberships.FindAsync(id);
            if (existMembership == null)
            {
                return BadRequest("This membership is not exist");
            }
            _context.Memberships.Remove(existMembership);    
            await _context.SaveChangesAsync();      
            return Ok("Deleted successfully");
        }
    }
}
