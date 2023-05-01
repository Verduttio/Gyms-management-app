using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages
{
    public class ClubsBase : ComponentBase
    {
        [Inject]
        public IClubsService ClubsService { get; set; }

        public IEnumerable<ClubResponse> Clubs { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Clubs = await ClubsService.GetClubs();
        }
    }
}
