namespace CRUDManagmentWeb.Models.Payment
{
    public class CreateStripePaymentRequest
    {
        public long ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";

    }
}
