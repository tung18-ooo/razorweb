using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS058_ASP.NET_Razor_09.Models
{
    //[Table("posts")]
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }
        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
