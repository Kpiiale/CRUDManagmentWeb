namespace CRUDManagmentWeb.Models.Company
{
    public class CompanyFormModel
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int OwnerUserId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
