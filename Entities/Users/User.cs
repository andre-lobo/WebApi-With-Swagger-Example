using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Users
{
    [Table("users")]
    public class User
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "error_user_name_required")]
        [MaxLength(50, ErrorMessage = "error_user_name_maxlenght_50")]
        [MinLength(3, ErrorMessage = "error_user_name_minlenght_3")]
        [StringLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Name { get; set; }

        [Required(ErrorMessage = "error_user_email_required")]
        [MaxLength(100, ErrorMessage = "error_user_email_maxlenght_100")]
        [MinLength(6, ErrorMessage = "error_user_email_minlenght_6")]
        [EmailAddress(ErrorMessage = "error_user_email_invalid")]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [Required(ErrorMessage = "error_user_password_required")]
        [MaxLength(100, ErrorMessage = "error_user_password_maxlenght_100")]
        [MinLength(8, ErrorMessage = "error_user_password_minlenght_8")]
        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        [Required]        
        public bool IsActive { get; set; }
    }
}
