using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class UserActivity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int idUser {get; set;}

        [Required]
        public int idActivity {get;set;}

        [Required]
        public string? currentStage { get; set; }

        [Required]
        public double? progress { get; set; }
        [Required]
        public DateTime? startDate { get; set; } 

        [Required]
        public DateTime? endDate { get; set; }
        
        public virtual User? user {get; set;}

        public virtual Activity? activity {get; set;}

    }
}