using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gyms.UI.Pages.Event
{
    public class AddEventBase : ComponentBase
    {
        [Inject]
        public IEventsService EventsService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public EventRequest EventRequest { get; set; }

        protected override void OnInitialized()
        {
            EventRequest = new EventRequest();
        }

        protected async Task AddEvent()
        {
            var response = await EventsService.AddEvent(EventRequest);
            if(response == null)
            {
                await JSRuntime.InvokeAsync<object>("alert", "Incorrect data");
            }
            NavigationManager.NavigateTo("/events");
        }
    }
}
