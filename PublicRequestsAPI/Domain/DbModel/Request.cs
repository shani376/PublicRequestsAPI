using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PublicRequestsAPI.Domain.DbModel
{
    [Table("Requests")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; } 

        [Column(TypeName = "varchar(200)")]
        public string Subject { get; set; } 
        
        [Column(TypeName = "varchar(1000)")]
        public string Content { get; set; } 
        
        [Column(TypeName = "DateTime")]
        public DateTime CreateDate { get; set; }
    }
}
