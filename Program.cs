using ProjetoTesteLar.Persistence;
using ProjetoTesteLar.Repositories;
using ProjetoTesteLar.Repositories.Intefaces;

namespace ProjetoTesteLar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<PessoasDbContext>();
            builder.Services.AddSingleton<TelefonesDbContext>();
            builder.Services.AddSingleton<EnderecosDbContext>();
            builder.Services.AddSingleton<PessoaEnderecoDbContext>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
            builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            builder.Services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();

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