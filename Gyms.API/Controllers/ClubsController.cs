using Microsoft.AspNetCore.Mvc;
using Gyms.API.Models.Entities;
using Gyms.API.Services;
using Gyms.API.Models.DTOs;

namespace Gyms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly ClubsService _clubsService;

        public ClubsController(ClubsService clubsService)
        {
            _clubsService = clubsService;
        }

        // GET: api/Clubs
        [HttpGet]
        public async Task<IEnumerable<Club>> GetClubs()
        {
          return await _clubsService.GetClubsAsync();
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<Club> GetClub(int id)
        {
          return await _clubsService.GetClubAsync(id);
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public async Task<Club> PutClub(int id, ClubRequest clubRequest)
        {
            return await _clubsService.UpdateClubAsync(id, clubRequest);
        }

        // POST: api/Clubs
        [HttpPost]
        public async Task<Club> PostClub(ClubRequest clubRequest)
        {
          return await _clubsService.AddClubAsync(clubRequest);
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<Club> DeleteClub(int id)
        {
            return await _clubsService.DeleteClubAsync(id);
        }

    }
}
