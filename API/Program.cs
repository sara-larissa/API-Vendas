using API.Context;
using API.Repository;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<VendasContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
        builder.Services.AddScoped<VendedorRepository>();
        builder.Services.AddScoped<ClienteRepository>();
        builder.Services.AddScoped<PedidoRepository>();
        builder.Services.AddScoped<ItemPedidoRepository>();
        builder.Services.AddScoped<ServicoRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

      builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
      {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
      }));

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

        app.UseCors("corsapp");

        app.Run();
    }
}