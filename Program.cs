using TAPR_Disciplina.Models;
using TAPR_Disciplina.Services;
using Dapr;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepositoryDbContext>();
builder.Services.AddScoped<IProfessorService,ProfessorService>();
builder.Services.AddScoped<IDisciplinaService,DisciplinaService>();
builder.Services.AddScoped<ICursoService,CursoService>();


var app = builder.Build();

app.UseCloudEvents();

app.MapSubscribeHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
