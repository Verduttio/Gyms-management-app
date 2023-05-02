using Gyms.Models.Dtos.Responses;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages
{
    public class CoachesBase : ComponentBase
    {
        [Inject]
        public ICoachesService CoachesService { get; set; }
        public IEnumerable<CoachResponse> Coaches { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Coaches = await CoachesService.GetCoaches();
        }

    }
}
