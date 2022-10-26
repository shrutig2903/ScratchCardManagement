using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScratchCardManagement.Context;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
       builder => builder
           .AllowAnyMethod()
           .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true) // allow any origin
   .AllowCredentials()); // allow credentials
});
builder.Services.AddDbContext<ScratchCardDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnection")));
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
