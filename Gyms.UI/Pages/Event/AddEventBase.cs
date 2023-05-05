using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Event
{
    public class AddEventBase : ComponentBase
    {
        [Inject]
        public IEventsService EventsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }    

        public EventRequest EventRequest { get; set; }

        protected override void OnInitialized()
        {
            EventRequest = new EventRequest();
        }

        protected async Task AddEvent()
        {
            await EventsService.AddEvent(EventRequest);
            NavigationManager.NavigateTo("/events");
        }
    }
}
