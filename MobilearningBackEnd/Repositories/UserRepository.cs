using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IUserRepository
    {
        User? Read(string Email, string Password);

        List<User>? ListUsers();
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
                var userFind = _context.Users.SingleOrDefault(user => user.email == Email && user.password == Password);
                if (userFind != null)
                    return userFind;
            }


            return null;
        }
    }
}