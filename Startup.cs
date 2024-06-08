using GS.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método é chamado pelo runtime. Use este método para adicionar serviços ao contêiner.
    public void ConfigureServices(IServiceCollection services)
    {
        // Adicionando o DbContext com a string de conexão do Oracle
        services.AddDbContext<ApplicationDBContext>(options =>
            options.UseOracle(Configuration.GetConnectionString("DefaultConnection")));

        // Adicionando os serviços dos repositórios
        services.AddScoped<IRIOSRepository, RIOSRepository>();
        services.AddScoped<IOCEANOSRepository, OCEANOSRepository>();
        services.AddScoped<IREPRESASRepository, REPRESASRepository>();
        services.AddScoped<IMARESRepository, MARESRepository>();

        // Adicionando suporte a controladores
        services.AddControllers();

        // Configuração do Swagger (opcional)
        services.AddSwaggerGen();
    }

    // Este método é chamado pelo runtime. Use este método para configurar o pipeline de solicitação HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}