using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface ITeacherRepository
    {
        Teacher? Read(string Email, string Password);

        List<Teacher>? ListTeachers();

        int Create(Teacher usuario);

        int Update(Teacher usuario);
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

                    if (userTeacher != null)
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

        public int Update(Teacher usuario)
        {
          
            if (_context.Teachers != null)
            {
                if (usuario.user != null)
                {
                    var userTeacher = _context.Teachers.SingleOrDefault(Teacher => Teacher.user!.id == usuario.user.id);

                    if (userTeacher != null && _context.Users != null)
                    {
                        userTeacher.user = _context.Users.SingleOrDefault(User => User.id == usuario.user.id);

                        if (userTeacher.user != null)
                        {
                            userTeacher.graduation = usuario.graduation;
                            userTeacher.user.name = usuario.user.name;
                            userTeacher.user.address = usuario.user.address;
                            userTeacher.user.cpf = usuario.user.cpf;
                            userTeacher.user.phone = usuario.user.phone;
                            userTeacher.user.password = usuario.user.password;

                            _context.Entry(userTeacher).State = EntityState.Modified;
                            _context.SaveChanges();

                            return 1;
                        }


                    }
                }

            }
            return 0;
        }
    }
}