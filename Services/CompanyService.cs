using CRUDManagmentWeb.Models.Company;
using CRUDManagmentWeb.Models.User;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CRUDManagmentWeb.Services
{
    public class CompanyService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Companies";

        public CompanyService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }

        public async Task<List<CompanyDto>?> GetAllAsync()
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.GetFromJsonAsync<PagedCompaniesResponse<CompanyDto>>(BaseUrl);
            return response?.Items ?? new List<CompanyDto>();
        }

        public async Task<CompanyDto?> GetByIdAsync(int id)
        {
            await SetAuthHeaderAsync();
            return await _httpClient.GetFromJsonAsync<CompanyDto>($"{BaseUrl}/{id}");
        }

        public async Task<bool> CreateAsync(CreateCompanyRequest request)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, UpdateCompanyRequest request)
        {
            await SetAuthHeaderAsync();

            var method = new HttpMethod("PATCH");
            var url = $"{BaseUrl}/{id}";
            var json = JsonContent.Create(request);
            var httpRequest = new HttpRequestMessage(method, url) { Content = json };

            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔄 PATCH empresa: {response.StatusCode} - {content}");

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
