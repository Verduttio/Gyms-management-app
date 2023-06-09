﻿using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Coach
{
    public class CoachDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public ICoachesService CoachesService { get; set; }
        
        [Inject]
        public IEventsService EventsService { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public CoachResponse Coach { get; set; }
        public IEnumerable<EventResponse> Events { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Coach = await CoachesService.GetCoach(Id);
            Events = await EventsService.GetCoachEvents(Id);
        }

        protected async Task DeleteCoach()
        {
            await CoachesService.DeleteCoach(Id);
            NavigationManager.NavigateTo("/coaches");
        }
    }
}
