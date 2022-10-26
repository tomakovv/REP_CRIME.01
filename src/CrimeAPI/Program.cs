using Crime.Application;
using Crime.Persistence;
using REP_CRIME._01.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("secrets/appsettings.secrets.json").AddEnvironmentVariables(prefix: "CRIME_");
builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<ExceptionHandlerMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();