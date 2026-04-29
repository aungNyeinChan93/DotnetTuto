using DotnetTuto.consoleApp1.Services;
using DotnetTuto.Database;
using DotnetTuto.Domain.Extension;
using DotnetTuto.webApi1.ActionFilters.Users;
using DotnetTuto.webApi1.Helpers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddDomain();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<EffortlessService>();
builder.Services.AddScoped<ResponseHelper>();
builder.Services.AddScoped<UserListActionFilter>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
