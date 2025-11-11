using System.ComponentModel.DataAnnotations;

namespace CRUDManagmentWeb.Models.Auth
{
    public class LoginRequest
    {
        public string UsernameOrEmail { get; init; }
        public string Password { get; init; }
    }

}
