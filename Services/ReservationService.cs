using CRUDManagmentWeb.Models.Reservation;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CRUDManagmentWeb.Services
{
    public class ReservationService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Reservations";

        public ReservationService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }
        public async Task<ReservationDto?> CreateAsync(CreateReservationRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"POST reserva: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", $"Error al crear reserva: {response.StatusCode} - {content}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReservationDto>();
        }

        public async Task<List<ReservationResponse>> GetAllReservationsAsync(int page = 1, int pageSize = 20)
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.GetFromJsonAsync<PagedReservationResponse>(
                $"{BaseUrl}/all?page={page}&pageSize={pageSize}"
            );

            return response?.Items.ToList() ?? new List<ReservationResponse>();
        }

        public async Task<List<ReservationResponse>> GetByUserAsync(int userId, int page = 1, int pageSize = 20)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.GetFromJsonAsync<PagedReservationResponse>(
                $"{BaseUrl}/by-user/{userId}?page={page}&pageSize={pageSize}"
            );
            return response?.Items.ToList() ?? new List<ReservationResponse>();
        }

        public async Task<List<ReservationResponse>> GetByCompanyAsync(int companyId, int page = 1, int pageSize = 20)
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.GetFromJsonAsync<PagedReservationResponse>(
                $"{BaseUrl}/by-company/{companyId}?page={page}&pageSize={pageSize}"
            );

            return response?.Items.ToList() ?? new List<ReservationResponse>();
        }
        public async Task<ReservationResponse?> UpdateStatusAsync(int reservationId, bool isDone)
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.PutAsJsonAsync(
                $"{BaseUrl}/{reservationId}/status",
                isDone
            );

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"PUT status: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", $"Error al actualizar estado: {response.StatusCode} - {content}");
                return null;
            }

            return await response.Content.ReadFromJsonAsync<ReservationResponse>();
        }


    }
}