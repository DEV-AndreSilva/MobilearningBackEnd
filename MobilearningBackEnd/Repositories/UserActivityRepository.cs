using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;
using MobilerningBackEnd.Models.ViewModels;

namespace MobilerningBackEnd.Repositories
{
    public interface IUserActivityRepository
    {
        UserActivity? Read(int id);
        int Create(UserActivityView atividade);

        void Delete(int id);
        void Update(int id, UserActivityView userActivity);

        List<UserActivity>? ListUserActivities(int idUser);

        List<UserView>? ListUsersFromActivity(int idActivity);
    }

    public class UserActivityRepository : IUserActivityRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public UserActivityRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public int Create(UserActivityView useractivity)
        {
            if (_context.UserActivities != null)
            {
                if (_context.Activities != null && _context.Users != null)
                {
                    var activityFind = _context.Activities.SingleOrDefault(activity => activity.id == useractivity.idActivity);
                    var userFind = _context.Users.SingleOrDefault(users => users.id == useractivity.idUser);

                    if (activityFind != null && userFind != null)
                    {
                        //verificar se a atividade ja foi vinculada ao usuário
                        var usuarioAtividadeJaCriado = _context.UserActivities.FirstOrDefault(userActivity => userActivity.idActivity == activityFind.id && userActivity.idUser == userFind.id);

                        if (usuarioAtividadeJaCriado == null)
                        {
                            UserActivity usuarioAtividade = new UserActivity();
                            usuarioAtividade.idActivity = activityFind.id;
                            usuarioAtividade.idUser = userFind.id;
                            usuarioAtividade.currentStage = useractivity.currentStage;
                            usuarioAtividade.progress = Convert.ToDouble(useractivity.progress);
                            usuarioAtividade.startDate = DateTime.Now.ToUniversalTime();
                            usuarioAtividade.endDate = DateTime.Now.AddDays(-1).ToUniversalTime();

                            _context.UserActivities.Add(usuarioAtividade);
                            _context.SaveChanges();

                            return 1;
                        }

                    }

                }


            }
            return 0;
        }

        public UserActivity? Read(int id)
        {
            if (_context.UserActivities != null)
            {
                var userActivityFind = _context.UserActivities.SingleOrDefault(UserActivity => UserActivity.id == id);

                if (userActivityFind != null)
                {
                    if (_context.Users != null && _context.Activities != null)
                    {
                        userActivityFind.activity = _context.Activities.FirstOrDefault(activity => activity.id == userActivityFind.idActivity);
                        userActivityFind.user = _context.Users.FirstOrDefault(user => user.id == userActivityFind.idUser);
                    }

                    return userActivityFind;
                }

            }


            return null;
        }

        public void Delete(int id)
        {
            Console.WriteLine(id);
            //verificar se não existe usuarioAtividade vinculado a ativiade para permitir a exclusão
            if (_context.UserActivities != null)
            {
                var userActivityFind = _context.UserActivities.FirstOrDefault(userActivities => userActivities.id == id);
                Console.WriteLine(userActivityFind);

                if (userActivityFind != null)
                {
                    _context.Entry(userActivityFind).State = EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
        }
        public void Update(int id, UserActivityView useractivity)
        {

            if (_context.UserActivities != null)
            {
                if (_context.Activities != null && _context.Users != null)
                {
                    var userActivityFind = _context.UserActivities.FirstOrDefault(userActivity => userActivity.id == id);
                    var activityFind = _context.Activities.SingleOrDefault(activity => activity.id == useractivity.idActivity);
                    var userFind = _context.Users.SingleOrDefault(users => users.id == useractivity.idUser);

                    if (activityFind != null && userFind != null && userActivityFind != null)
                    {
                        userActivityFind.activity = activityFind;
                        userActivityFind.user = userFind;
                        userActivityFind.currentStage = useractivity.currentStage;
                        userActivityFind.progress = Convert.ToDouble(useractivity.progress);

                        if (useractivity.progress == "100")
                            userActivityFind.endDate = null;

                        _context.Entry(userActivityFind).State = EntityState.Modified;
                        _context.SaveChanges();
                    }

                }

            }
        }

        public List<UserActivity>? ListUserActivities(int idUser)
        {
            if (_context.UserActivities != null)
            {
                if (_context.Activities != null && _context.Users != null)
                {
                    var results = _context.UserActivities.Where(userActivity => userActivity.idUser == idUser).ToList();

                    List<UserActivity> ListaCompleta = new List<UserActivity>();
                    foreach (UserActivity usuarioAtividade in results)
                    {
                        var usuarioAtiviadeTrans = new UserActivity();
                        usuarioAtiviadeTrans.id = usuarioAtividade.id;
                        usuarioAtiviadeTrans.idUser = usuarioAtividade.idUser;
                        usuarioAtiviadeTrans.idActivity = usuarioAtividade.idActivity;
                        usuarioAtiviadeTrans.currentStage = usuarioAtividade.currentStage;
                        usuarioAtiviadeTrans.progress = usuarioAtividade.progress;
                        usuarioAtiviadeTrans.startDate = usuarioAtividade.startDate;
                        usuarioAtiviadeTrans.endDate = usuarioAtividade.endDate;
                        usuarioAtiviadeTrans.user = _context.Users.FirstOrDefault(user => user.id == usuarioAtividade.idUser);
                        usuarioAtiviadeTrans.activity = _context.Activities.FirstOrDefault(activity => activity.id == usuarioAtividade.idActivity);

                        ListaCompleta.Add(usuarioAtiviadeTrans);
                    }


                    return ListaCompleta;

                }


            }
            return null;
        }


        public List<UserView>? ListUsersFromActivity(int idActivity)
        {
            List<UserView> users = new List<UserView>();
            
             if (_context.UserActivities != null && _context.Users != null)
             {
                var results = _context.UserActivities.Where(userActivity => userActivity.idActivity == idActivity).ToList();

                foreach(UserActivity userActivity in results)
                {

                    UserView userObject = new UserView();
                    User? user = _context.Users.FirstOrDefault(user => user.id == userActivity.idUser);

                    if(user != null)
                    {
                        userObject.idUser = user.id;
                        userObject.name = user.name;

                        users.Add(userObject);
                    }
                    

                }
             }

            return users;

        }
    }
}