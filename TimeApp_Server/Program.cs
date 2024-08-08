
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TimeApp_Server.Data;
using TimeApp_Server.Interfaces;
using TimeApp_Server.Managers;
using TimeApp_Server.Repositories;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPostsRepository, PostsRepository>();
builder.Services.AddScoped<PostsManager>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
//self-code

builder.Services.AddDbContext<TimingsDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


//Enable CORS

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//using CORS
app.UseCors(myAllowSpecificOrigins);


app.UseAuthorization();

app.MapControllers();

app.Run();


