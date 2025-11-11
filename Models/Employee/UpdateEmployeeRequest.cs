namespace CRUDManagmentWeb.Models.Employee
{
    public record UpdateEmployeeRequest(
    string Email,
    string Role,
    bool IsActive,
    string? Password
);
}
