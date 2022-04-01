using IComp.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace IComp.Areas.ViewModels
{
    public class AdminRegisterViewModel
    {
        [Required]
        [StringLength(maximumLength: 25)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public AdminRoles AdminRoles { get; set; }
        [Required]
        [StringLength(maximumLength: 25)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
