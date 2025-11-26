namespace CRUDManagmentWeb.Models.Payment
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long ReservationId { get; set; }
        public string Provider { get; set; } = "Stripe";
        public string ProviderTxnId { get; set; } = null!;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "USD";
        public string Status { get; set; } = "Pending";
        public DateTime? PaidAt { get; set; }
        public string? RawPayload { get; set; }

        
    }
}
