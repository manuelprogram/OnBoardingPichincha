using Microsoft.EntityFrameworkCore;
using CreditCar.Entity.Models;
using CreditCar.Repository.Context;

using CreditCar.Domain.Interfaces;
using CreditCar.Infrastructure.Services;
using CreditCar.Repository.DataAccess.Interfaces;
using CreditCar.Repository.DataAccess;
using CreditCar.Repository.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CreditcarContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<ISqlDataContext, CreditcarContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IBaseDomain<,>), typeof(BaseService<,>));
builder.Services.AddScoped<IMarcaVehiculoDomain, MarcaVehiculoService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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
