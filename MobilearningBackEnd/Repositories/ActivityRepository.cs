using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IActivityRepository
    {
        Activity? Read(int id);

        List<Activity>? listActivities();

        int Create(Activity atividade);

        void Delete(int id);
        void Update(int id, Activity word);
    }

    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public ActivityRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public int Create(Activity atividade)
        {
            if (_context.Activities != null)
            {
                var userFind = _context.Activities.SingleOrDefault(activity => activity.title == atividade.title);

                if (userFind == null)
                {
                    _context.Activities.Add(atividade);
                    _context.SaveChanges();

                    return 1;
                }
            }
            return 0;
        }

        public List<Activity>? listActivities()
        {
            if (_context.Activities != null)
            {
                var results = _context.Activities.ToList();
                return results;
            }
            return null;
        }

        public Activity? Read(int id)
        {
            if (_context.Activities != null)
            {
                var activityFind = _context.Activities.SingleOrDefault(activity => activity.id == id);
                if (activityFind != null)
                    return activityFind;
            }


            return null;
        }

        public void Delete(int id)
        {
                Console.WriteLine(id);
            //verificar se não existe usuarioAtividade vinculado a ativiade para permitir a exclusão
            if(_context.Activities != null)
            {
                 var activityFind = _context.Activities.FirstOrDefault(activityFind=>activityFind.id==id);
                 Console.WriteLine(activityFind);

                if(activityFind != null)
                {
                    _context.Entry(activityFind).State = EntityState.Deleted;
                    _context.SaveChanges();
                }    
            }
        }
        public void Update(int id, Activity activity)
        {
            if (_context.Activities != null)
            {
                var activityFind = _context.Activities.FirstOrDefault(activity => activity.id == id);

                if (activityFind != null)
                {
                    activityFind.introduction = activity.introduction;
                    activityFind.task = activity.task;
                    activityFind.process = activity.process;
                    activityFind.information = activity.information;
                    activityFind.avaliation = activity.avaliation;
                    activityFind.conclusion = activity.conclusion;
                    activityFind.references = activity.references;
                    activityFind.title = activity.title;
                    activityFind.subttitle = activity.subttitle;
                    activityFind.imageURL = activity.imageURL;

                    _context.Entry(activityFind).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}