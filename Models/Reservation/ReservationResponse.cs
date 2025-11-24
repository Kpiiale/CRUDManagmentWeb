namespace CRUDManagmentWeb.Models.Reservation
{
    public record ReservationResponse(
    long Id, int ActivityId, int UserId, int Quantity, decimal UnitPrice, decimal TotalAmount,
    string Status, DateTime ReservedAt, DateTime? ExpiresAt, string? CreatedBy
);
}
