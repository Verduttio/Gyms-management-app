using Gyms.API.Models.Entities;
using Gyms.API.Models.Requests;
using Gyms.API.Repositories.Interfaces;

namespace Gyms.API.Services
{
    public class CoachesService
    {
        private readonly ICoachesRepository _coachesRepository;

        public CoachesService(ICoachesRepository coachesRepository)
        {
            _coachesRepository = coachesRepository;
        }

        public async Task<IEnumerable<Coach>> GetCoachesAsync()
        {
            return await _coachesRepository.GetCoachesAsync();
        }

        public async Task<Coach> GetCoachAsync(int id)
        {
            return await _coachesRepository.GetCoachAsync(id);
        }

        public async Task<Coach> AddCoachAsync(CoachRequest coachRequest)
        {
            Coach coach = new Coach(coachRequest);
            return await _coachesRepository.AddCoachAsync(coach);
        }

        public async Task<Coach> UpdateCoachAsync(int id, CoachRequest coachRequest)
        {
            Coach coach = await GetCoachAsync(id);
            if(coach == null)
            {
                return null;
            }

            coach.FirstName = coachRequest.FirstName;
            coach.LastName = coachRequest.LastName;
            coach.YearOfBirth = coachRequest.YearOfBirth;

            return await _coachesRepository.UpdateCoachAsync(coach);
        }

        public async Task<Coach> DeleteCoachAsync(int id)
        {
            return await _coachesRepository.DeleteCoachAsync(id);
        }






    }
}
