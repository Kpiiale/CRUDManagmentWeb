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



        public async Task<bool> CreateAsync(CreateActivityRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
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

            var method = new HttpMethod("PATCH");
            var url = $"{BaseUrl}/{id}";
            var json = JsonContent.Create(request);
            var httpRequest = new HttpRequestMessage(method, url) { Content = json };

            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔄 PATCH actividad: {response.StatusCode} - {content}");

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task AddCategoryAsync(int activityId, int categoryId)
        {
            await SetAuthHeaderAsync();
            var req = new { CategoryId = categoryId };
            await _httpClient.PostAsJsonAsync($"{BaseUrl}/{activityId}/categories", req);
        }

    }
}
