using API_ERP.Class;
using Microsoft.OpenApi.Models;

namespace API_ERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.            
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API ERP Paye ton Kawa.",
                    Contact = new OpenApiContact
                    {
                        Name = "PayeTonKawa",
                        Email = "PayeTonKawa@gmail.com"
                    }
                });
                string xmlPath = Path.Combine(AppContext.BaseDirectory, "Swagger.xml");
                c.IncludeXmlComments(xmlPath);
            });
            //initialisation du service ProductApiService
            builder.Services.AddSingleton<IERPApiService>(new ERPApiService());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}