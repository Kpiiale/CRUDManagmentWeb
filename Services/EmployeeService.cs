using CRUDManagmentWeb.Models.Employee;
using CRUDManagmentWeb.Models.User;
using Microsoft.JSInterop;
using System.Net.Http.Json;

namespace CRUDManagmentWeb.Services
{
    public class EmployeeService : ApiServiceBase
    {
        private const string BaseUrl = "https://localhost:7162/api/Employees";

        public EmployeeService(HttpClient httpClient, IJSRuntime jsRuntime)
            : base(httpClient, jsRuntime) { }

        public async Task<List<EmployeeDto>> GetAllAsync(int companyId)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.GetFromJsonAsync<PagedResponse<EmployeeDto>>($"{BaseUrl}?companyId={companyId}");
            return response?.Items ?? new List<EmployeeDto>();
        }

        public async Task<bool> CreateAsync(int companyId, CreateEmployeeRequest request)
        {
            await SetAuthHeaderAsync();

            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}?companyId={companyId}", request);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔍 Backend dice: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", $"❌ Error al crear empleado: {content}");
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateEmployeeRequest request)
        {
            await SetAuthHeaderAsync();

            var method = new HttpMethod("PATCH");
            var url = $"{BaseUrl}/{id}";
            var json = JsonContent.Create(request);
            var httpRequest = new HttpRequestMessage(method, url) { Content = json };

            var response = await _httpClient.SendAsync(httpRequest);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔄 PATCH empleado: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", $"❌ Error al actualizar empleado: {response.StatusCode} - {content}");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await SetAuthHeaderAsync();
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}