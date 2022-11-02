using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class Word
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int userId { get; set; }

        [Required]
        public string portugueseWord { get; set; } = "";
        [Required]
        public string englishWord { get; set; } = "";
        [Required]
        public string portugueseDefinition { get; set; } = "";
        [Required]
        public string englishDefinition { get; set; } = "";

    }
}