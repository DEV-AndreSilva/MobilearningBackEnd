using System.ComponentModel.DataAnnotations;

namespace MobilerningBackEnd.Models.ViewModels
{
    public class UserLogin
    {
        [Required]
        public string? email {get;set;}
        [Required]
        public string? password { get; set; }

    }
}