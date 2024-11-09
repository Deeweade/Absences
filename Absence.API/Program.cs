using Absence.Application.Interfaces.Services.NotificationSender;
using Absence.Application.Services.NotificationService;
using Absence.Infrastructure.Data.Repositories;
using Absence.Application.Interfaces.Services;
using Absence.Infrastructure.Models.Mappings;
using Absence.Domain.Interfaces.Repositories;
using Absence.Infrastructure.Data.Contexts;
using Absence.Application.Models.Mappings;
using Absence.Application.Models.Actions;
using Absence.Application.Models.Views;
using Absence.Application.Validators;
using Absence.Application.Services;
using Absence.Infrastructure.Data;
using Absence.API.Middlewares;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using FluentValidation;

#region EnvironmentConfiguring

var settingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Settings");

var builder = WebApplication.CreateBuilder();

var environmentName = builder.Environment.EnvironmentName;

var config = new ConfigurationBuilder()
    .SetBasePath(settingsPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string machineName = Environment.MachineName.ToLower();

var machineNames = config.GetSection("EnvironmentMachines").Get<Dictionary<string, string>>();

builder.Environment.EnvironmentName = machineNames.FirstOrDefault(x => x.Key.ToLower() == machineName.ToLower()).Value ?? "Development";

builder.Configuration
    .SetBasePath(settingsPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

#endregion

#region AuthenticationConfiguring

//builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAuthenticatedUser", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});

#endregion

#region ControllersConfiguring

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

#endregion

#region ContextsConfiguring

string connectionString = builder.Configuration.GetConnectionString("Absence");

builder.Services.AddDbContext<AbsenceDbContext>(options =>
    options.UseSqlServer(connectionString, 
        b => b.MigrationsAssembly("Absence.API").UseCompatibilityLevel(120)));

#endregion

#region DependenciesInjection

builder.Services.Configure<string>(builder.Configuration.GetSection("EnvironmentDomain"));

//services
builder.Services.AddScoped<INotificationBuilderFactory, NotificationBuilderFactory>();
builder.Services.AddScoped<INotificationSenderFacade, NotificationSenderFacade>();
builder.Services.AddScoped<IPlanningProcessService, PlanningProcessService>();
builder.Services.AddScoped<IEmailFormattingService, EmailFormattingService>();
builder.Services.AddScoped<IEmployeeStagesService, EmployeeStagesService>();
builder.Services.AddScoped<ISubstitutionsService, SubstitutionsService>();
builder.Services.AddScoped<IVacationDaysService, VacationDaysService>();
builder.Services.AddScoped<IWorkPeriodsService, WorkPeriodsService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<INotificationSender, EmailSender>();
builder.Services.AddScoped<IAbsenceService, AbsenceService>();

//data
builder.Services.AddScoped<IVacationDaysRepository, VacationDaysRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//validators
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddTransient<IValidator<RescheduleAbsenceView>, RescheduleAbsenceValidator>();
builder.Services.AddTransient<IValidator<AbsenceView>, AbsenceValidator<AbsenceView>>();
builder.Services.AddTransient<IValidator<CreateAbsenceView>, CreateAbsenceValidator>();
builder.Services.AddTransient<IValidator<UpdateAbsenceView>, UpdateAbsenceValidator>();

builder.Services.AddAutoMapper(typeof(InfrastructureMappingProfile), typeof(ApplicationMappingProfile));

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Absence API", Version = "v1" });
});

var corsPolicyName = "AllowCors";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

#region ApplicationSettingUp

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<DevAuthMiddleware>();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});
app.UseRouting();

app.UseCors(corsPolicyName);

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

#endregion

#region RunMigrations

//Запуск миграций при старте приложения
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<AbsenceDbContext>();
    dbContext.Database.Migrate();
}

#endregion

app.Run();