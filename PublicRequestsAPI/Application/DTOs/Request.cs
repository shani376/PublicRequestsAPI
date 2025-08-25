using System.ComponentModel.DataAnnotations;

namespace PublicRequestsAPI.Application.DTOs
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 

        public string Subject { get; set; } 
        public string Content { get; set; } 
        public DateTime CreateDate { get; set; } 
    }
}