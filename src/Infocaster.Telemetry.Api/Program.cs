using Infocaster.Telemetry.Api.Services;
using Infocaster.Telemetry.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITelemetryReportService, TelemetryReportService>();

// Add database context to the container.
builder.Services.AddDbContext<TelemetryContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("InfocasterTelemetry")));

var app = builder.Build();

// Configure the http request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();