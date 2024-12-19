using AutoMapper;
using Domain.Entities;
using GraphQL.Validation.Complexity;
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
            var listMembership = await _context.Memeberships.ToListAsync();
            return Ok(listMembership);  
        }
        [HttpPost]
        public async Task<IActionResult> CreateMembership(MembershipCreateDTO membershipCreateDTO)
        {
            var newMembership = _mapper.Map<Membership>(membershipCreateDTO);
            newMembership.Id = Guid.NewGuid();  
            newMembership.CreatedAt = DateTime.Now; 
            await _context.Memeberships.AddAsync(newMembership);    
            await _context.SaveChangesAsync();  
            return Ok(newMembership);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMembership(MembershipUpdateDTO membership)
        {
            var existMembership = await _context.Memeberships.FindAsync(membership.Id);
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
            var existMembership = await _context.Memeberships.FindAsync(id);
            if (existMembership == null)
            {
                return BadRequest("This membership is not exist");
            }
            _context.Memeberships.Remove(existMembership);    
            await _context.SaveChangesAsync();      
            return Ok("Deleted successfully");
        }
    }
}
