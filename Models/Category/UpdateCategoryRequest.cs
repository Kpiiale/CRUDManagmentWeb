using System.ComponentModel.DataAnnotations;

namespace CRUDManagmentWeb.Models.Category
{
    public class UpdateCategoryRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; } = string.Empty;
    }
}
