namespace CRUDManagmentWeb.Models.Reservation
{
    public class ReservationDto
    {
        public long Id { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string? CreatedBy { get; set; }


    }
}
