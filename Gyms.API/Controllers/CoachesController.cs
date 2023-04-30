using Gyms.API.Models.Entities;
using Gyms.API.Models.Requests;
using Gyms.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gyms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachesController : ControllerBase
    {
        private readonly CoachesService _coachesService;

        public CoachesController(CoachesService coachesService)
        {
            _coachesService = coachesService;
        }

        // GET: api/Coaches
        [HttpGet]
        public async Task<IEnumerable<Coach>> GetCoaches()
        {
            return await _coachesService.GetCoachesAsync();
        }

        // GET: api/Coaches/5
        [HttpGet("{id}")]
        public async Task<Coach> GetCoach(int id)
        {
          return await _coachesService.GetCoachAsync(id);
        }

        // PUT: api/Coaches/5
        [HttpPut("{id}")]
        public async Task<Coach> PutCoach(int id, CoachRequest coachRequest)
        {
            return await _coachesService.UpdateCoachAsync(id, coachRequest);
        }

        // POST: api/Coaches
        [HttpPost]
        public async Task<Coach> PostCoach(CoachRequest coachRequest)
        {
          return await _coachesService.AddCoachAsync(coachRequest);
        }

        // DELETE: api/Coaches/5
        [HttpDelete("{id}")]
        public async Task<Coach> DeleteCoach(int id)
        {
            return await _coachesService.DeleteCoachAsync(id);
        }
    }
}
