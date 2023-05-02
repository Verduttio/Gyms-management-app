using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages
{
    public class EventsBase : ComponentBase
    {
        [Inject]
        public IEventsService EventsService { get; set; }
        public IEnumerable<EventResponse> Events { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Events = await EventsService.GetEvents();
        }

    }
}
