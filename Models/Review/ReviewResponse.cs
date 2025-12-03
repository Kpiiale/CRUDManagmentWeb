namespace CRUDManagmentWeb.Models.Review
{
    public class ReviewResponse
    {
        public long Id { get; set; }           
        public int UserId { get; set; }      
        public int ActivityId { get; set; }    
        public byte Rating { get; set; }       
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }


}
