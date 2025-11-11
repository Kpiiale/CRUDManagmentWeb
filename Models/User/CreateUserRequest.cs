namespace CRUDManagmentWeb.Models.User
{
    public record CreateUserRequest(string Username, string Email, string Password, string Role = "User", bool IsActive = true);
}
