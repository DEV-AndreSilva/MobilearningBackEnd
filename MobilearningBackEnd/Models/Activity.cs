using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MobilerningBackEnd.Models.ViewModels;

namespace MobilerningBackEnd.Models
{
    public class Activity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int? idTeacher {get; set;}
        [Required]
        public string?  introduction { get; set; }
        [Required]
        public string? task { get; set; }
        [Required]
        public string?  process { get; set; }
        [Required]
        public List<string>? information {get; set;}
        
        [Required]
        public string?  evaluation { get; set; }

        [Required]
        public string?  conclusion { get; set; }

        [Required]
        public List<string>? references {get; set;}

        [Required]
        public string?  title { get; set; }

        [Required]
        public string?  subtitle { get; set; }

        [Required]
        public string?  imageURL { get; set; }

        public virtual Teacher? user {get;set;}

        public virtual List<UserActivityResumeView>? usersActivity {get; set;}


    }
}