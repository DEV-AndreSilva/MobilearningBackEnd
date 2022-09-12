using Microsoft.EntityFrameworkCore;
using MobilerningBackEnd.Models;

namespace MobilerningBackEnd.Repositories
{
    public class DataContext : DbContext
    {
        //definir qual vai ser a conexão com a base de dados
        public DataContext(DbContextOptions options): base(options)
        {

        }

        //referencia da classe para o EntityFramework
        public DbSet<Word>? Words {get;set;}
        public DbSet<User>? Users {get;set;}
    }
}