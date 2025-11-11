namespace CRUDManagmentWeb.Models.User
{
    public record UserResponse(int Id, string Username, string Email, string Role, bool IsActive, DateTime CreatedAt, DateTime? UpdatedAt, string? CreatedBy, string? UpdatedBy);
}
