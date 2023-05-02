using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Club
{
    public class AddClubBase : ComponentBase
    {
        [Inject]
        public IClubsService ClubsService { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        public ClubRequest ClubRequest { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ClubRequest = new ClubRequest();
        }

        public async Task AddClub()
        {
            await ClubsService.AddClub(ClubRequest);
            Navigation.NavigateTo("/clubs");
        }
    }
}
