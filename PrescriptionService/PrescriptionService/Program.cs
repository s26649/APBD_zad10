using Microsoft.EntityFrameworkCore;
using PrescriptionService.Entities;
using PrescriptionService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PrescriptionsDbContext>(options =>
{
    string connString = builder.Configuration.GetConnectionString("DbConnString");
    options.UseSqlServer(connString);
});
builder.Services.AddScoped<IPrescriptionService, PrescriptionService.Services.PrescriptionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();