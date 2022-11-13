using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MobilerningBackEnd.Models.ViewModels
{
    [Keyless][NotMapped]
    public class UserActivityResumeView
    {
        public int idUserActivity {get;set;}
        public int idUser {get;set;}
        public string? name {get;set;}

    }
}