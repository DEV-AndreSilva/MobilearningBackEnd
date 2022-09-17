using System.ComponentModel.DataAnnotations;

namespace MobilerningBackEnd.Models.ViewModels
{
    public class UserLogin
    {
        [Required]
        public string Email {get;set;}
        [Required]
        public string Password { get; set; }

        public UserLogin(string email,string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}