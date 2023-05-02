using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Club
{
    public class ClubDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IClubsService ClubsService { get; set; }

        [Inject]
        public IEventsService EventsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ClubResponse Club { get; set; }

        public OpeningHoursResponse OpeningHours { get; set; }

        public IEnumerable<EventResponse> ClubEvents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Club = await ClubsService.GetClub(Id);

            System.Diagnostics.Debug.WriteLine(Club.Name);

            OpeningHours = await ClubsService.GetClubOpeningHours(Id);
            ClubEvents = await EventsService.GetClubEvents(Id);
        }

        protected async Task DeleteClub()
        {
            await ClubsService.DeleteClub(Id);
            NavigationManager.NavigateTo("/clubs");
        }


    }
}
