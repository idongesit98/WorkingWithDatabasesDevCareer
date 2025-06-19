// See https://aka.ms/new-console-template for more information
using Book_Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//Adding services to the container
builder.Services.AddDbContext<LibraryContext>(options => 
options.UseMySql(builder.Configuration.GetConnectionString("LibraryConnection"),
ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("LibraryConnection")))
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//configuring Http request pipelines
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
