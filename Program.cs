using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using JashariDenisLB_295_V2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Konfigurieren der In-Memory-Datenbank
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("GameDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
