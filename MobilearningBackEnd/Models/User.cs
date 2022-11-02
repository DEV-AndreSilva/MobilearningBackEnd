using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? address { get; set; }
        [Required]
        public string? cpf { get; set; }
        [Required]
        public string? phone { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? type { get; set; }
    }
}