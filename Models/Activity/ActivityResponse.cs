namespace CRUDManagmentWeb.Models.Activity
{

    public record ActivityResponse(
        int Id,
        int CompanyId,
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
        bool? AllowWaitlist,
        decimal? AvgRating,
        int? RatingCount,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
