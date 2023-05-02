using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Gyms.UI.Pages.Reservation
{
    public class AddReservationBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        public IReservationsService ReservationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ReservationRequest ReservationRequest { get; set; } = new ReservationRequest();

        protected override void OnInitialized()
        {
            ReservationRequest = new ReservationRequest();
            ReservationRequest.EventId = Id;
        }

        public async Task AddReservation()
        {
            await ReservationService.AddReservation(ReservationRequest);
            NavigationManager.NavigateTo($"/events/{Id}");
        }
    }
}
