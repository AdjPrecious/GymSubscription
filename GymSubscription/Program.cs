using Contract;
using GymSubscription.Extensions;
using Hangfire;
using NLog;
using PayStack.Net;
using Repository;
using Service;
using Service.Contracts;

var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
"/nlog.config"));
// Add services to the container.
builder.Services.ConfigureSwagger();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddJwtConfiguration(builder.Configuration);
builder.Services.AddEmailSetting(builder.Configuration);
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureHangfire(builder.Configuration);
builder.Services.AddHangfireServer();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();

builder.Services.AddControllers()

.AddApplicationPart(typeof(GymSubscription.Presentation.AssemblyReference).Assembly);




var app = builder.Build();

// Configure the HTTP request pipeline.


var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseSwagger();

app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Gym Subscription Api v1"));

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate<IJobService>("jobId", service => service.UpdateSubscription(), Cron.Daily);

app.MapControllers();

app.Run();
