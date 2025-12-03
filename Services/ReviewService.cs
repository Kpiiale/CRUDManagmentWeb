using CRUDManagmentWeb.Models.Review;

namespace CRUDManagmentWeb.Services
{
    public class ReviewService
    {
        private readonly HttpClient _http;

        public ReviewService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ActivityReviewsResponse?> GetByActivityAsync(int activityId)
        {
            return await _http.GetFromJsonAsync<ActivityReviewsResponse>(
                $"api/activities/{activityId}/reviews");
        }
        public async Task<ReviewDto?> AddAsync(int activityId, AddReviewRequest request)
        {
            var response = await _http.PostAsJsonAsync(
                $"api/activities/{activityId}/reviews", request);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<ReviewDto>();
        }

        public async Task<bool> DeleteAsync(int reviewId)
        {
            var response = await _http.DeleteAsync($"api/activities/reviews/{reviewId}");
            return response.IsSuccessStatusCode;
        }
    }
}