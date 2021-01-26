using System.ComponentModel.DataAnnotations;

namespace NET5.JWT.CustomUser.Models
{
    public class Role : BaseEntity
    {
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
    }
}