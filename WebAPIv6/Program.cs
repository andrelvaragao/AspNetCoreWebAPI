using Microsoft.EntityFrameworkCore;
using WebAPIv6.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
            builder.Services.AddDbContext<SmartContext>(
                context => context.UseSqlite(builder.Configuration.GetConnectionString("Default"))
                );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
  {
    c.ResolveConflictingActions (apiDescriptions => apiDescriptions.First ());
  });

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
