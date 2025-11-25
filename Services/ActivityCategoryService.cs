using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace CRUDManagmentWeb.Services
{
    public class ActivityCategoryService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/activities";

        public ActivityCategoryService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }

        // Asignar categoría a una actividad
        public async Task<bool> AddCategoryAsync(int activityId, int categoryId)
        {
            await SetAuthHeaderAsync();
            var req = new { CategoryId = categoryId };
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/{activityId}/categories", req);
            return response.IsSuccessStatusCode;
        }

        // Eliminar categoría de una actividad
        public async Task<bool> RemoveCategoryAsync(int activityId, int categoryId)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{activityId}/categories/{categoryId}");
            return response.IsSuccessStatusCode;
        }
    }
}
