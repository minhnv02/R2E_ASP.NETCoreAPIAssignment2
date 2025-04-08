using Rookies_ASP.NETCoreAPI_2.API.Dtos;
using Rookies_ASP.NETCoreAPI_2.API.Middlewares;
using Rookies_ASP.NETCoreAPI_2.API.Services;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.Repositories;

namespace Rookies_ASP.NETCoreAPI_2.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
            builder.Services.AddSingleton<IPersonService, PersonService>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.UseErrorHandlingMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}
