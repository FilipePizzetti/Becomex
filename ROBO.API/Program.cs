using ROBO.Domain.Entities;
using ROBO.Domain.Interface;
using ROBO.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<Robo>();
builder.Services.AddSingleton<IRoboService, RoboServiceRico>();

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
app.MapDefaultControllerRoute();

app.Run();
