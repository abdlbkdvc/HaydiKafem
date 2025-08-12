using HaydiKafem.Application.Interfaces;
using HaydiKafem.Application.Mapping;
using HaydiKafem.Application.Services.ColdDrinkServices;
using HaydiKafem.Application.Services.DesertServices;
using HaydiKafem.Application.Services.FoodServices;
using HaydiKafem.Application.Services.HotDrinkServices;
using HaydiKafem.Application.Services.IceCreamServices;
using HaydiKafem.Persistence.Context;
using HaydiKafem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext URL
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services and Repository Pattern
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IIceCreamService, IceCreamService>();
builder.Services.AddScoped<IDesertService, DesertService>();
builder.Services.AddScoped<IColdDrinkService, ColdDrinkService>();
builder.Services.AddScoped<IHotDrinkService, HotDrinkService>();
//AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<GeneralMapping>();
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
