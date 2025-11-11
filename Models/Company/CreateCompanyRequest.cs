namespace CRUDManagmentWeb.Models.Company
{
    public record CreateCompanyRequest(string Name, string? Description, int OwnerUserId);
}
