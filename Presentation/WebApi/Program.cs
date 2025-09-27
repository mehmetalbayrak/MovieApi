using Application.Features.CQRS.Handlers.Category;
using Application.Features.CQRS.Handlers.Movie;
using Application.Features.CQRS.Handlers.UserRegister;
using Application.Features.Mediator.Handlers.Tag;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Identity;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MovieContext>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<GetMovieQueryHandler>();
builder.Services.AddScoped<GetMovieByIdQueryHandler>();
builder.Services.AddScoped<CreateMovieCommandHandler>();
builder.Services.AddScoped<RemoveMovieCommandHandler>();
builder.Services.AddScoped<UpdateMovieCommandHandler>();



builder.Services.AddScoped<CreateUserRegisterCommandHandler>();
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<MovieContext>();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MyApi", Version = "v1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=> c.SwaggerEndpoint("/swagger/v1/swagger.json","v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
