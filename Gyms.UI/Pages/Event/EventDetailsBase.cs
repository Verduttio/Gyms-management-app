using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Event
{
    public class EventDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IEventsService EventsService { get; set; }

        [Inject]
        public IReservationsService ReservationsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EventResponse Event { get; set; }
        public IEnumerable<ReservationResponse> EventReservations { get; set; }  

        protected override async Task OnInitializedAsync()
        {
            Event = await EventsService.GetEvent(Id);
            EventReservations = await ReservationsService.GetEventReservations(Id);
        }

        protected async Task DeleteEvent()
        {
            await EventsService.DeleteEvent(Event.Id);
            NavigationManager.NavigateTo("/events");
        }

    }
}
