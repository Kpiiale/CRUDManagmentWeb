using CRUDManagmentWeb.Models.Auth;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Text.Json;
using Microsoft.JSInterop;

namespace CRUDManagmentWeb.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
        private readonly JsonSerializerOptions _jsonOptions = new() { PropertyNameCaseInsensitive = true };

        public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        // URL base de la API
        private const string BaseUrl = "https://localhost:7162/api/Auth"; // cambia si el puerto es diferente

        // === LOGIN ===
        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/login", request);
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🔍 LOGIN -> {response.StatusCode}: {content}");

            if (!response.IsSuccessStatusCode)
            {
                // Mostrar mensaje de error real (opcional)
                await _jsRuntime.InvokeVoidAsync("alert", $"Error del servidor: {response.StatusCode}\n{content}");
                return null;
            }

            var auth = await response.Content.ReadFromJsonAsync<AuthResponse>(_jsonOptions);
            if (auth is not null)
            {
                await SaveAuthData(auth);
            }

            return auth;
        }


        // === REGISTRO ===
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/register", request);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"🔍 Backend dice: {response.StatusCode} - {content}");

            if (!response.IsSuccessStatusCode)
            {
                // Puedes mostrar el mensaje devuelto por el backend
                await _jsRuntime.InvokeVoidAsync("alert", $"Error del servidor: {content}");
                return false;
            }

            return true;
        }

        // === GUARDAR TOKEN Y DATOS DEL USUARIO ===
        private async Task SaveAuthData(AuthResponse auth)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "authToken", auth.Token);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "username", auth.Username);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "role", auth.Role);
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "userId", auth.Id.ToString());
        }

        public async Task<AuthResponse?> GetCurrentUserAsync()
        {
            var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");
            if (string.IsNullOrWhiteSpace(token))
                return null;

            return new AuthResponse(
                Id: int.Parse(await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "userId") ?? "0"),
                Username: await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "username") ?? "",
                Role: await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "role") ?? "",
                Token: token
            );
        }

        public async Task LogoutAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.clear");
        }
    }
}