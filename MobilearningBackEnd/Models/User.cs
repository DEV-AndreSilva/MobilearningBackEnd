using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string?  Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string?  Password { get; set; }
    }
}