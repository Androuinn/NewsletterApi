using System.ComponentModel.DataAnnotations;

namespace NewsletterApi.Domain.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
    }

}
