using Microsoft.EntityFrameworkCore;
using PaperWork.Api.Data;
using PaperWork.Api.Repositories;
using PaperWork.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// MySQL bağlantısı
var cs = builder.Configuration.GetConnectionString("PaperWorkDb");
builder.Services.AddDbContext<PaperWorkDbContext>(opt =>
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs))); 

builder.Services.AddScoped<IPaperWorkRepository, PaperWorkRepository>();
builder.Services.AddScoped<IPaperWorkService, PaperWorkService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();