using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Coach
{
    public class AddCoachBase : ComponentBase
    {
        [Inject]
        public ICoachesService CoachesService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public CoachRequest CoachRequest { get; set; }
        protected override void OnInitialized()
        {
            CoachRequest = new CoachRequest();
        }

        public async Task AddCoach()
        {
            await CoachesService.AddCoach(CoachRequest);
            NavigationManager.NavigateTo("/coaches");
        }
    }
}
