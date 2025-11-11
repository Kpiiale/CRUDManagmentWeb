using CRUDManagmentWeb.Models.Activity;
using CRUDManagmentWeb.Models.User;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CRUDManagmentWeb.Services
{
    public class ActivityService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Activities";

        public ActivityService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }

        public async Task<List<ActivityDto>> GetAllAsync(int companyId)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.GetFromJsonAsync<PagedActivitiesResponse<ActivityDto>>($"{BaseUrl}?companyId={companyId}");
            return response?.Items ?? new List<ActivityDto>();
        }



        public async Task<bool> CreateAsync(int companyId, CreateActivityRequest request)
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}?companyId={companyId}", request);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"📤 POST actividad: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", $"❌ Error al crear actividad: {response.StatusCode} - {content}");
                return false;
            }

            return true;
        }
        public async Task<bool> UpdateAsync(int id, UpdateActivityRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", request);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
