using API;
using EmployeeBase.API;
using EmployeeBase.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmloyeeBaseContext>(op
    => op.UseSqlServer("Server=SIMO\\SQLEXPRESS;Database=Employee.DB;Trusted_Connection=True"));
builder.Services.AddAutoMapper(typeof(ApiMapper).Assembly, typeof(DataMapper).Assembly);
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
