﻿using Microsoft.AspNetCore.Mvc;
using Gyms.API.Models.Entities;
using Gyms.API.Services;
using Gyms.Models.Dtos.Requests;
using Gyms.Models.Dtos.Responses;

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
        public async Task<IEnumerable<ClubResponse>> GetClubs()
        {
            IEnumerable<Club> clubs = await _clubsService.GetClubsAsync();
            IEnumerable<ClubResponse> clubResponses = clubs.Select(c => c.GetClubResponseObject()).ToList();

            return clubResponses;
        }

        // GET: api/Clubs/5
        [HttpGet("{id}")]
        public async Task<ClubResponse> GetClub(int id)
        {
            Club club = await _clubsService.GetClubAsync(id);
            return club.GetClubResponseObject();
        }

        // PUT: api/Clubs/5
        [HttpPut("{id}")]
        public async Task<ClubResponse> PutClub(int id, ClubRequest clubRequest)
        {
            Club club = await _clubsService.UpdateClubAsync(id, clubRequest);
            return club.GetClubResponseObject();
        }

        // POST: api/Clubs
        [HttpPost]
        public async Task<ClubResponse> PostClub(ClubRequest clubRequest)
        {
            Club club = await _clubsService.AddClubAsync(clubRequest);
            return club.GetClubResponseObject();
        }

        // DELETE: api/Clubs/5
        [HttpDelete("{id}")]
        public async Task<ClubResponse> DeleteClub(int id)
        {
            Club club = await _clubsService.DeleteClubAsync(id);
            return club.GetClubResponseObject();
        }

        // GET: api/Clubs/5/OpeningHours
        [HttpGet("{id}/OpeningHours")]
        public async Task<OpeningHoursResponse> GetClubOpeningHours(int id)
        {
            OpeningHours openingHours = await _clubsService.GetOpeningHoursAsync(id);
            return openingHours.GetOpeningHoursResponseObject();
        }

    }
}
