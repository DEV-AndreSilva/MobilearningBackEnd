using System.ComponentModel.DataAnnotations;

namespace MobilerningBackEnd.Models
{
    public class Word
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }

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