using System.ComponentModel.DataAnnotations;

namespace MobilerningBackEnd.Models.ViewModels
{
    public class UserActivityView
    {
        [Required]
        public int idUser { get; set; }
        [Required]
        public int idActivity { get; set; }

        [Required]
        public string? currentStage { get; set; }

        [Required]
        public string? Progress { get; set; }

        public UserActivityView(int iduser, int idactivity, string currentstage, string progress)
        {
            this.idUser = iduser;
            this.idActivity = idactivity;
            this.currentStage = currentstage;
            this.Progress = progress;
        }
    }
}