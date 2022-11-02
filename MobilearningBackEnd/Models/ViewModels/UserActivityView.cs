using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobilerningBackEnd.Models.ViewModels
{
    public class UserActivityView
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public int idUser { get; set; }

        [Required]
        public int idActivity { get; set; }

        [Required]
        public string? currentStage { get; set; }

        [Required]
        public string? progress { get; set; }

        public UserActivityView(int idUser, int idActivity, string currentStage, string progress)
        {
            this.idUser = idUser;
            this.idActivity = idActivity;
            this.currentStage = currentStage;
            this.progress = progress;
        }
    }
}