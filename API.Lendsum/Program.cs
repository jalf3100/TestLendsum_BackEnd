//-----------------------------------------------------------------------
// <copyright file = "Program.cs" company="Lendsum">
//     Copyright(c) Lendsum.All rights reserved.
// </copyright>
// <author>Jorge López</author>
//-----------------------------------------------------------------------
using Application.Lendsum.Extensions;
using Infrestructure.Lendsum.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddInjectionInfrestructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowOriginPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();