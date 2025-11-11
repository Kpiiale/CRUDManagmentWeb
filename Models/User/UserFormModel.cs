namespace CRUDManagmentWeb.Models.User
{
    public class UserFormModel
    {
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "User";
        public string Password { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}
