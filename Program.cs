using Microsoft.EntityFrameworkCore;
using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories;
using ProjetoTesteLar.Repositories.Intefaces;
using System.Text.Json.Serialization;

namespace ProjetoTesteLar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddSingleton<PessoasDbContext>();
            //builder.Services.AddDbContext<PessoasDbContext>(t => t.UseInMemoryDatabase("dbTesteLar"));
            //builder.Services.AddSingleton<TelefonesDbContext>();
            //builder.Services.AddDbContext<TelefonesDbContext>(t => t.UseInMemoryDatabase("dbTesteLar"));
            //builder.Services.AddSingleton<EnderecosDbContext>();
            //builder.Services.AddDbContext<EnderecosDbContext>(t => t.UseInMemoryDatabase("dbTesteLar"));
            //builder.Services.AddSingleton<PessoaEnderecosDbContext>();
            builder.Services.AddDbContext<TesteLarDbContext>(t => t.UseInMemoryDatabase("dbTesteLar"));


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
            builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();

            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



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