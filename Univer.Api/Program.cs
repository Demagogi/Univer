using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Univer.Application.Lecturers.Commands;
using Univer.Application.Mappers;
using Univer.Domain.Interfaces;
using Univer.Infrastructure.Database;
using Univer.Infrastructure.Repositories;
using Univer.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LecturerDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(CreateLecturerCommand))));
builder.Services.AddAutoMapper(config => config.AddProfile(typeof(MappingProfiles)), Assembly.GetAssembly(typeof(MappingProfiles)));

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
