namespace CRUDManagmentWeb.Models.Activity
{
    public class ActivityFormModel
    {
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public string? LocationText { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime StartAt { get; set; } = DateTime.Today;
        public DateTime EndAt { get; set; } = DateTime.Today.AddDays(1);
        public int? Capacity { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? Status { get; set; }
        public bool AllowWaitlist { get; set; } = false; 
    }
}
