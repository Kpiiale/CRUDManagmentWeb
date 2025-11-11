using System.ComponentModel.DataAnnotations;

public class EmployeeFormModel
{
    [Required(ErrorMessage = "El usuario es obligatorio")]
    public string Username { get; set; } = "";

    [Required(ErrorMessage = "El correo es obligatorio")]
    [EmailAddress(ErrorMessage = "Correo inválido")]
    public string Email { get; set; } = "";

    public string Password { get; set; } = "";

    [Required(ErrorMessage = "El rol en la empresa es obligatorio")]
    public string RoleInCompany { get; set; } = "";

    public bool IsActive { get; set; } = true;
}