using FlashSaleApi.Data;
using FlashSaleApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MemStore>();
builder.Services.AddSingleton<SaleSvc>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
