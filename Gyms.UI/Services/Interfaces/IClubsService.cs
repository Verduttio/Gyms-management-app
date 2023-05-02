﻿using Gyms.Models.Dtos.Responses;

namespace Gyms.UI.Services.Interfaces
{
    public interface IClubsService
    {
        Task<IEnumerable<ClubResponse>> GetClubs();
        Task<ClubResponse> GetClub(int id);
        Task<OpeningHoursResponse> GetClubOpeningHours(int clubId);
    }
}