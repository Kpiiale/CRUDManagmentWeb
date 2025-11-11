
using System.Net.Http.Json;
using CRUDManagmentWeb.Models.User;
using Microsoft.JSInterop;

namespace CRUDManagmentWeb.Services
{
    public class UserService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Users";

        public UserService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }

        public async Task<List<UserDto>?> GetAllAsync()
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.GetFromJsonAsync<PagedResponse<UserDto>>($"{BaseUrl}");
            return response?.Items;
        }


        public async Task<UserDto?> GetByIdAsync(int id)
        {
            await SetAuthHeaderAsync();
            return await _httpClient.GetFromJsonAsync<UserDto>($"{BaseUrl}/{id}");
        }

        public async Task<bool> CreateAsync(CreateUserRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserRequest request)
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
