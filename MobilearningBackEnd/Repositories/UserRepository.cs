using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IUserRepository
    {
        User? Read(string Email, string Password);

        List<User>? ListUsers();

        User? Update(User user);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public UserRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public List<User>? ListUsers()
        {
            if (_context.Users != null)
            {
                var results = _context.Users.ToList();
                return results;
            }
            return null;
        }

        public User? Read(string Email, string Password)
        {
            if (_context.Users != null)
            {
                var userFind = _context.Users.SingleOrDefault(
                    user => user.email == Email && 
                    user.password == Password);
                    
                if (userFind != null)
                    return userFind;
            }


            return null;
        }

        public User? Update(User userPut)
        {
            Console.WriteLine("user id");
            Console.WriteLine(userPut.id);

            if(_context.Users!= null)
            {
                User? userNew = _context.Users.FirstOrDefault(userDatabase=> userDatabase.id == userPut.id);

                //recupera o usuário do banco de dados
                if(userNew != null)
                {
                    Console.WriteLine(userNew.id);
                    userNew.id = userNew.id;
                    userNew.address = userPut.address;
                    userNew.cpf = userPut.cpf;
                    userNew.email = userPut.email;
                    userNew.name = userPut.name;
                    userNew.password = userPut.password;
                    userNew.phone = userPut.phone;

                    _context.Entry(userNew).State = EntityState.Modified;
                    _context.SaveChanges();

                    return userNew;
                }
                return null;
                

            }
            else
            {
                return null;
            }
        }
    }
}