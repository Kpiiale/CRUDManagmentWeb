namespace CRUDManagmentWeb.Models.User
{
    public record ChangePasswordRequest(string CurrentPassword, string NewPassword);
}
