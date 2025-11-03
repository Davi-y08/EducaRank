using EducaRank.Domain.Interfaces;
using EducaRank.Infrastructure.Data;
using EducaRank.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<LegadoEscolaDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("LegadoConnection")));

builder.Services.AddScoped<IAlunoService, AlunoRepo>();
builder.Services.AddScoped<IProfessorService, ProfessorRepo>();
builder.Services.AddScoped<IAvaliacoesService, AvaliacaoRepo>();
builder.Services.AddScoped<IEscolaIntegrationService, EscolaRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
