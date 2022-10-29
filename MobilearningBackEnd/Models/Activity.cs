using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string?  introduction { get; set; }
        [Required]
        public string? task { get; set; }
        [Required]
        public string?  process { get; set; }
        [Required]
        public List<string>? information {get; set;}
        
        [Required]
        public string?  avaliation { get; set; }

        [Required]
        public string?  conslusion { get; set; }

        [Required]
        public List<string>? references {get; set;}

        [Required]
        public string?  title { get; set; }

        [Required]
        public string?  subttitle { get; set; }

        [Required]
        public string?  imageURL { get; set; }


    }
}