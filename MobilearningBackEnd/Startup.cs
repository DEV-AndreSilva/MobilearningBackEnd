using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MobilerningBackEnd.Repositories;

namespace MobilerningBackEnd
{
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
         var key = Encoding.ASCII.GetBytes(Configuration.GetSection("MySettings").GetSection("Key").Value);

        //adicionando serviço de autenticação
        services.AddAuthentication(options =>{
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata =false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters{
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });

        //adicionando opçao de banco de dados
        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDWords"));

        //adicionando o serviço que permite a manipulação do repositorio no controller
        services.AddTransient<IWordRepository, WordRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddRazorPages();
    }
 
    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
      
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.MapRazorPages();

        app.UseAuthentication();
        app.UseAuthorization();

        //endpoints da API serão os metodos dos Controllers
        app.UseEndpoints(endpoints =>endpoints.MapControllers());

        app.Run();
    }
}
}
