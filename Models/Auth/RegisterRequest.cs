using System.ComponentModel.DataAnnotations;

namespace CRUDManagmentWeb.Models.Auth
{
    public record RegisterRequest(string Username, string Email, string Password, string? CreatedBy = null);

}
