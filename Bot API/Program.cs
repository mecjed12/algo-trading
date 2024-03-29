using Bot_API.DataContext;
using Bot_API.EfCore;
using Bot_API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EF_DataContext>(
                 o => o.UseNpgsql(builder.Configuration.GetConnectionString("postgres"))
                 );

builder.Services.AddScoped<IHistoricalDataService, HistoricalDataService>();

builder.Services.AddScoped<IEF_DataContext, EF_DataContext>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
