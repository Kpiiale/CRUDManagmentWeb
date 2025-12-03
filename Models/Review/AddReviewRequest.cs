namespace CRUDManagmentWeb.Models.Review
{
    public class AddReviewRequest
    {
        public int ActivityId { get; set; }
        public byte Rating { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }

    }


}
