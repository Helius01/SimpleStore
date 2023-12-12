using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using SimpleShop.src.Api.Data;
using SimpleShop.src.Api.Data.Seed;
using SimpleShop.src.Api.Extensions;
using SimpleShop.src.Api.Models.Validators;
using SimpleShop.src.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/**********
 * FLUENT *
 **********/
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductRequestValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/************
 * DATABASE *
 ************/
var postgresConnectionString = builder.Configuration.GetConnectionString("PostgreSQL");
builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(postgresConnectionString ?? throw new ArgumentNullException(postgresConnectionString)));

/***********
 * CACHING *
 ***********/
builder.Services.AddMemoryCache();

/************
 * SERVICES *
 ************/
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

/***************
 * AUTO MAPPER *
 ***************/
builder.Services.AddAutoMapper();

var app = builder.Build();


//TODO:Move to function
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
var seeder = new DataSeeder(context);
seeder.SeedUsers().GetAwaiter().GetResult();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
