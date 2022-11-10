using System.ComponentModel.DataAnnotations;

namespace MobilerningBackEnd.Models.ViewModels
{
    public class UserActivityResumeView
    {
        public int idUserActivity {get;set;}
        public int idUser {get;set;}
        public string? name {get;set;}

    }
}