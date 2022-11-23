using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface ITeacherRepository
    {
        Teacher? Read(string Email, string Password);

        List<Teacher>? ListTeachers();

        int Create(Teacher usuario);
    }

    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public TeacherRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public int Create(Teacher usuario)
        {
            if (_context.Teachers != null && _context.Users != null)
            {
                var userFind = _context.Users.SingleOrDefault(user => user.email == usuario.user!.email);
                if (userFind == null)
                {
                    //adiciona o usuário ao banco de dados
                    _context.Users.Add(usuario.user!);

                     //salva o usuário   
                    _context.SaveChanges();
                    //busca o usuario salvo
                    var userTeacher = _context.Users.SingleOrDefault(user => user.email == usuario.user!.email);

                    if(userTeacher != null)
                    {
                        //adiciona o registro de estudante ao banco de dados
                        _context.Teachers.Add(usuario);

                        _context.SaveChanges();

                        return userTeacher.id;
                    }
                }
                else
                {
                    return -1;
                }

            }
            return 0;

        }

        public List<Teacher>? ListTeachers()
        {
            if (_context.Teachers != null)
            {
                var results = _context.Teachers.ToList();
                return results;
            }
            return null;
        }

        public Teacher? Read(string Email, string Password)
        {
            if (_context.Teachers != null)
            {
                var userFind = _context.Teachers.SingleOrDefault(teacher => teacher.user!.email == Email && teacher.user.password == Password);
                if (userFind != null)
                    return userFind;
            }


            return null;
        }
    }
}