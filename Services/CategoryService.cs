using CRUDManagmentWeb.Models.Category;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CRUDManagmentWeb.Services
{
    public class CategoryService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Categories";

        public CategoryService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }
        public async Task<List<CategoryDto>> GetAllAsync()
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.GetFromJsonAsync<List<CategoryDto>>(BaseUrl);
            return response ?? new List<CategoryDto>();
        }

        public async Task<bool> CreateAsync(CreateCategoryRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/{id}", request);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"❌ Error al actualizar: {response.StatusCode} - {error}");
            }

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
