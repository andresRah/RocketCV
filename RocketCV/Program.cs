using RocketCV.Data.Repositories;
using RocketCV.Services;
using RocketCV.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fetch the connection string from the configuration (appsettings.json or other configuration sources)
var connectionString = builder.Configuration.GetConnectionString("MongoConnection");
var databaseName = builder.Configuration.GetConnectionString("DatabaseName");

// Register Repositories
builder.Services.AddSingleton<IJobPositionRepository, JobPositionRepository>(provider => new JobPositionRepository(connectionString!, databaseName!));

// Register Services
builder.Services.AddSingleton<IJobPositionServices, JobPositionServices>();

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
