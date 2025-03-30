using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReceiptProcessorApi.Repositories;
using ReceiptProcessorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ReceiptContext>(opt =>
    opt.UseInMemoryDatabase("ReceiptList"));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
