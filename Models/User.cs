using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelProject.Models
{
    [Table("tblUsers")]
    public class User
    {
        [Key]
        [Column("UserID")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten dang nhap")]
        [StringLength(50)]
        [Display(Name = "Ten dang nhap")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap mat khau")]
        [StringLength(100)]
        [Display(Name = "Mat khau")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap ho ten")]
        [StringLength(100)]
        [Display(Name = "Ho ten")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap email")]
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui long nhap so dien thoai")]
        [Phone]
        [StringLength(20)]
        [Display(Name = "So dien thoai")]
        [Column("Phone")]
        public string PhoneNumber { get; set; } = string.Empty;

        [NotMapped]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Ngay tao")]
        [DataType(DataType.Date)]
        [Column("CreatedDate")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string Role { get; set; } = "User";

        public bool Status { get; set; } = true;
    }
}
