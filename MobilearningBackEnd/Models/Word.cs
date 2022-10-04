using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserId { get; set; }

        [Required]
        public string PortugueseWord { get; set; } = "";
        [Required]
        public string EnglishWord { get; set; } = "";
        [Required]
        public string PortugueseDefinition { get; set; } = "";
        [Required]
        public string EnglishDefinition { get; set; } = "";

    }
}