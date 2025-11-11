namespace CRUDManagmentWeb.Models.Activity
{
    public record CreateActivityRequest(
     string Title,
     string? Description,
     string? LocationText,
     decimal? Latitude,
     decimal? Longitude,
     DateTime? StartAt,
     DateTime? EndAt,
     int? Capacity,
     decimal? Price,
     string? Currency,
     string? Status,
     bool? AllowWaitlist
 );
}
