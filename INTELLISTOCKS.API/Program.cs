// Program.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.REPOSITORY;
using INTELLISTOCKS.REPOSITORY.events;
using INTELLISTOCKS.REPOSITORY.repository;
using INTELLISTOCKS.MODELS.user;
using INTELLISTOCKS.REPOSITORY.user;
using INTELLISTOCKS.SERVICES;

var builder = WebApplication.CreateBuilder(args);

// Usei para usar o ENUM como string
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = builder.Configuration.GetSection("Swagger:Title").Value,
        Description = builder.Configuration.GetSection("Swagger:Description").Value,
        Contact = new OpenApiContact
        {
            Name = builder.Configuration.GetSection("Swagger:Contact:Name").Value,
            Email = builder.Configuration.GetSection("Swagger:Contact:Email").Value,
            Url = new Uri(builder.Configuration.GetSection("Swagger:Contact:Url").Value)
        },
        License = new OpenApiLicense
        {
            Name = builder.Configuration.GetSection("Swagger:License:Name").Value,
            Url = new Uri(builder.Configuration.GetSection("Swagger:License:Url").Value)
        }
    });
});

builder.Services.AddDbContext<FIAPDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("FIAPDatabase"));
});

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IEventRepository, EventsRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddHttpClient<EmailService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();