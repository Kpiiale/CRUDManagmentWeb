using CRUDManagmentWeb.Models.Payment;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CRUDManagmentWeb.Services
{
    public class PaymentService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://beeapp-api-afefhphxaaf0hsfn.chilecentral-01.azurewebsites.net/api/Payments";

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string?> CreateIntentAsync(long reservationId, decimal amount, string currency)
        {
            var req = new CreateStripePaymentRequest
            {
                ReservationId = reservationId,
                Amount = amount,
                Currency = currency
            };

            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/create-intent", req);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<CreateIntentResponse>();
            return result?.ClientSecret;
        }
        public async Task<string?> CreateCheckoutSessionAsync(long reservationId)
        {
            var req = new CheckoutRequest
            {
                ReservationId = reservationId
            };

            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/create-checkout-session", req);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>();
            return result?.Url;
        }

        public async Task<string?> StartCheckoutAsync(long reservationId)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/checkout", reservationId);

            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<CheckoutResponse>();
            return result?.Url;
        }
    }


   
}