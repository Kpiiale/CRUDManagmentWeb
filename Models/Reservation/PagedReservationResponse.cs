namespace CRUDManagmentWeb.Models.Reservation
{
    public class PagedReservationResponse
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public IEnumerable<ReservationResponse> Items { get; set; } = new List<ReservationResponse>();
    }
}
