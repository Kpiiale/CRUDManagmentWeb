namespace CRUDManagmentWeb.Models.User
{
    public record UpdateUserRequest(string? Email, string? Role, string? Password, bool? IsActive);
}
