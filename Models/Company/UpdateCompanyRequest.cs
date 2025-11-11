namespace CRUDManagmentWeb.Models.Company
{
    public record UpdateCompanyRequest(string? Name, string? Description, bool? IsActive);
}
