using Microsoft.EntityFrameworkCore;
using PaperWork.Api.Data;
using PaperWork.Api.Repositories;
using PaperWork.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// MySQL bağlantısı
var cs = builder.Configuration.GetConnectionString("paperwork");
builder.Services.AddDbContext<PaperWorkDbContext>(opt =>
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

builder.Services.AddScoped<IPaperWorkRepository, PaperWorkRepository>();
builder.Services.AddScoped<IPaperWorkService, PaperWorkService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PaperWork API v1");
    c.RoutePrefix = string.Empty; 
});

app.MapControllers();
app.Run();
