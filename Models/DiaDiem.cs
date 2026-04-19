using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelProject.Models
{
    [Table("tblDiaDiem")]
    public class DiaDiem
    {
        [Key]
        [Column("DiaDiemID")]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Column("TenDiaDiem")]
        [Display(Name = "Destination Name")]
        public string TenDiaDiem { get; set; } = string.Empty;

        [Column("MoTa")]
        [Display(Name = "Description")]
        public string? MoTa { get; set; }

        [StringLength(300)]
        [Column("DiaChi")]
        [Display(Name = "Address")]
        public string? DiaChi { get; set; }

        [StringLength(100)]
        [Column("KhuVuc")]
        [Display(Name = "Region")]
        public string? KhuVuc { get; set; }

        [StringLength(100)]
        [Column("LoaiHinh")]
        [Display(Name = "Category")]
        public string? LoaiHinh { get; set; }

        [StringLength(500)]
        [Column("HinhAnh")]
        [Display(Name = "Image URL")]
        public string? HinhAnh { get; set; }

        [Column("LuotXem")]
        [Display(Name = "Views")]
        public int LuotXem { get; set; }

        [Column("CreatedDate")]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
