using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NET5.JWT.CustomUser.Models
{
    public class User : BaseEntity
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Required")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        [Display(Name = "Roles")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }

    public class UserRole : BaseEntity
    {

        [Required(ErrorMessage = "Required")]
        [Display(Name = "User")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}