using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IStudentRepository
    {
        Student? Read(string Email, string Password);

        List<Student>? ListStudents();

        int Create(Student usuario);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public StudentRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public int Create(Student usuario)
        {
            if (_context.Students != null && _context.Users != null)
            {
                var userFind = _context.Users.SingleOrDefault(user => user.email == usuario.user!.email);
                if (userFind == null)
                {
                   //adiciona o usuário ao banco de dados
                    _context.Users.Add(usuario.user!);
                    //adiciona o registro de estudante ao banco de dados
                    _context.Students.Add(usuario);

                    _context.SaveChanges();

                    return 1;
                }
            }
            return 0;
        }

        public List<Student>? ListStudents()
        {
            if (_context.Students != null)
            {
                var results = _context.Students.ToList();
                return results;
            }
            return null;
        }

        public Student? Read(string Email, string Password)
        {
            if (_context.Students != null)
            {
                var userFind = _context.Students.SingleOrDefault(student => student.user!.email == Email && student.user.password == Password);
                if (userFind != null)
                    return userFind;
            }
            
            return null;
        }
    }
}