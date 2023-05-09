using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gyms.UI.Pages.Club
{
    public class AddClubBase : ComponentBase
    {
        [Inject]
        public IClubsService ClubsService { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public ClubRequest ClubRequest { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ClubRequest = new ClubRequest();
        }

        public async Task AddClub()
        {
            var response = await ClubsService.AddClub(ClubRequest);
            if (response == null)
            {
                await JSRuntime.InvokeAsync<object>("alert", "Incorrect data");
            }
            Navigation.NavigateTo("/clubs");
        }
    }
}
