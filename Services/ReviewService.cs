using CRUDManagmentWeb.Models.Review;
using CRUDManagmentWeb.Services;
using Microsoft.JSInterop;
using System.Net.Http;

public class ReviewService : ApiServiceBase
{
    private const string BaseUrl = "https://localhost:7162/api/activities";

    public ReviewService(HttpClient httpClient, IJSRuntime jsRuntime)
        : base(httpClient, jsRuntime)
    {
    }

    public async Task<ActivityReviewsResponse?> GetByActivityAsync(int activityId)
    {
        return await _httpClient.GetFromJsonAsync<ActivityReviewsResponse>(
            $"{BaseUrl}/{activityId}/reviews"
        );
    }

    public async Task<ReviewDto?> AddAsync(int activityId, AddReviewRequest request)
    {
        await SetAuthHeaderAsync(); 

        var response = await _httpClient.PostAsJsonAsync(
            $"{BaseUrl}/{activityId}/reviews", request);

        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"POST review: {response.StatusCode} - {content}");

        if (!response.IsSuccessStatusCode)
        {
            await _jsRuntime.InvokeVoidAsync("alert",
                $"Error al crear reseña: {response.StatusCode} - {content}");
            return null;
        }

        return await response.Content.ReadFromJsonAsync<ReviewDto>();
    }

    public async Task<bool> DeleteAsync(int reviewId)
    {
        await SetAuthHeaderAsync(); 

        var response = await _httpClient.DeleteAsync(
            $"{BaseUrl}/reviews/{reviewId}"
        );

        return response.IsSuccessStatusCode;
    }
}
