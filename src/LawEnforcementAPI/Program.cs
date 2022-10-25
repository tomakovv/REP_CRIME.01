using LawEnforcement.Application;
using LawEnforcement.Application.LawEnforcement.Messaging.Receive;
using LawEnforcement.Application.LawEnforcement.Messaging.Send;
using LawEnforcement.Persistence;
using Microsoft.EntityFrameworkCore;
using REP_CRIME._01.Common.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("secrets/appsettings.secrets.json").AddEnvironmentVariables();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddTransient<ICrimeEventAssignmentResultSender, CrimeEventAssignmentResultSender>();
builder.Services.AddHostedService<CrimeEventReceiver>();
builder.Services.AddTransient<ExceptionHandlerMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<LawEnforcementContext>();
    context.Database.Migrate();
}
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();