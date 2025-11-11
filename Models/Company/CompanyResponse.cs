namespace CRUDManagmentWeb.Models.Company
{
    public record CompanyResponse(int Id, string Name, string? Description, int OwnerUserId, decimal AvgRating, int RatingCount, bool IsActive, DateTime CreatedAt, DateTime? UpdatedAt, string? CreatedBy, string? UpdatedBy);
}
