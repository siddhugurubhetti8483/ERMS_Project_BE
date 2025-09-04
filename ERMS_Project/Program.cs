using ERMS_Project.Contexts;
using ERMS_Project.Interfaces;
using ERMS_Project.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICountryRepository, CountriesRepository>();
builder.Services.AddScoped<IEmployeeAllocationRepository, EmployeeAllocationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
