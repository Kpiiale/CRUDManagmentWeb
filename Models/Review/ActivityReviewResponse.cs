namespace CRUDManagmentWeb.Models.Review
{
    public class ActivityReviewsResponse
    {
        public int ActivityId { get; set; }
        public double AvgRating { get; set; }
        public int RatingCount { get; set; }
        public List<ReviewDto> Reviews { get; set; } = new();


    }
}
