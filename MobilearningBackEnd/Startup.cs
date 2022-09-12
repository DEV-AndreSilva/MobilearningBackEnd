using Microsoft.EntityFrameworkCore;
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

        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("BDWords"));

        //adicionando o serviço que permite a manipulação do repositorio no controller
        services.AddTransient<IWordRepository, WordRepository>();

        services.AddRazorPages();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
      
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();

        //endpoints da API serão os metodos dos Controllers
        app.UseEndpoints(endpoints =>endpoints.MapControllers());

        app.Run();
    }
}
}
