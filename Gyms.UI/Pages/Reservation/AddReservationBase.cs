using Gyms.Models.Dtos.Requests;
using Gyms.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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

        [Inject]
        public IJSRuntime JSRuntime { get; set; }   

        public ReservationRequest ReservationRequest { get; set; } = new ReservationRequest();

        protected override void OnInitialized()
        {
            ReservationRequest = new ReservationRequest();
            ReservationRequest.EventId = Id;
        }

        public async Task AddReservation()
        {
            var response = await ReservationService.AddReservation(ReservationRequest);
            if (response == null)
            {
                await JSRuntime.InvokeAsync<object>("alert", "Incorrect data");
            }
            NavigationManager.NavigateTo($"/events/{Id}");
        }
    }
}
