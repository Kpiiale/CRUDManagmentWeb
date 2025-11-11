namespace CRUDManagmentWeb.Models.Employee
{
    public record EmployeeResponse(
    int Id,
    string Username,
    string Email,
    string Role,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    string? CreatedBy,
    string? UpdatedBy,
    string? RoleInCompany,
    int CompanyId
);
}
