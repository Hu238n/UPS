using System.ComponentModel.DataAnnotations;

namespace UPS.Core.Form
{
    public class UpdateUserForm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
    }
}