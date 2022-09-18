using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public interface IUserRepository
    {
        User? Read(string Email, string Password);

        List<User>? listUsers ();

        void Create (User usuario);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;


        public UserRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration =configuration;
        }
        public void Create(User usuario)
        {
            if(_context.Users != null)
            {
                usuario.Id = Guid.NewGuid();

                _context.Users.Add(usuario);
                _context.SaveChanges();
            }
        }

        public List<User>? listUsers()
        {
            if(_context.Users != null)
            {
                var results = _context.Users.ToList();
                return results;
            }
            return null;
        }

        public User? Read(string Email, string Password)
        {
            if(_context.Users != null)
            {
               var userFind = _context.Users.SingleOrDefault(user=>user.Email==Email && user.Password==Password);
               if(userFind != null)
               return userFind;
            }
            

            return null;
        }
    }
}