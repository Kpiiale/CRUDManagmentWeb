namespace CRUDManagmentWeb.Models.Employee
{
    public record CreateEmployeeRequest(
    string Username,
    string Email,
    string Password,
    string? RoleInCompany
);
}
