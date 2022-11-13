using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IActivityRepository
    {
        Activity? Read(int id);

        List<Activity>? ListActivities(int id);

        int Create(Activity atividade);

        void Delete(int id, int idTeacher);
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
                var activityFind = _context.Activities.SingleOrDefault(activity => activity.title == atividade.title && activity.idTeacher == atividade.idTeacher);

                if (activityFind == null)
                {
                    _context.Activities.Add(atividade);
                    _context.SaveChanges();
                }
                else
                return 0;

                var activityCreate = _context.Activities.SingleOrDefault(activity => activity.title == atividade.title && activity.idTeacher == atividade.idTeacher);
                
                if(activityCreate != null)
                {   Console.WriteLine("id atividade criada");
                    Console.WriteLine(activityCreate.id);
                    return activityCreate.id;
                }
            }
            return 0;
        }

        public List<Activity>? ListActivities(int idTeacher)
        {
            Console.WriteLine(idTeacher);
            if (_context.Activities != null)
            {
                var results = _context.Activities.Where(activity=> activity.idTeacher == idTeacher).ToList();
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

        public void Delete(int id, int idTeacher)
        {
            Console.WriteLine(id);
            Console.WriteLine(idTeacher);
            //verificar se não existe usuarioAtividade vinculado a ativiade para permitir a exclusão
            if(_context.Activities != null)
            {
                 var activityFind = _context.Activities.FirstOrDefault(activityFind=>activityFind.id==id && activityFind.idTeacher == idTeacher);
                 Console.WriteLine(activityFind);

                if(activityFind != null)
                {
                    _context.Entry(activityFind).State = EntityState.Deleted;
                    _context.SaveChanges();
                }    
            }
        }
        public void Update(int id, Activity activityModel)
        {
            Console.WriteLine(id);
            Console.WriteLine(activityModel.idTeacher);

            if (_context.Activities != null)
            {
                var activityFind = _context.Activities.FirstOrDefault(activity => activity.id == id && activity.idTeacher ==activityModel.idTeacher);

                if (activityFind != null)
                {
                    activityFind.introduction = activityModel.introduction;
                    activityFind.task = activityModel.task;
                    activityFind.process = activityModel.process;
                    activityFind.information = activityModel.information;
                    activityFind.evaluation = activityModel.evaluation;
                    activityFind.conclusion = activityModel.conclusion;
                    activityFind.references = activityModel.references;
                    activityFind.title = activityModel.title;
                    activityFind.subtitle = activityModel.subtitle;
                    activityFind.imageURL = activityModel.imageURL;

                    _context.Entry(activityFind).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }
    }
}