using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int IdUser {get; set;}        

        [Required]
        public string? nivel {get; set;}

        public virtual User? user {get;set;}
    }
}