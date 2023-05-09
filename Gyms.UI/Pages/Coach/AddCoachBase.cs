using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Gyms.UI.Pages.Coach
{
    public class AddCoachBase : ComponentBase
    {
        [Inject]
        public ICoachesService CoachesService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public CoachRequest CoachRequest { get; set; }
        protected override void OnInitialized()
        {
            CoachRequest = new CoachRequest();
        }

        public async Task AddCoach()
        {
            var response = await CoachesService.AddCoach(CoachRequest);
            if (response == null)
            {
                await JSRuntime.InvokeAsync<object>("alert", "Incorrect data");
            }
            NavigationManager.NavigateTo("/coaches");
        }
    }
}
