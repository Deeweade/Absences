using Vacations.Application.Interfaces.Services;
using Vacations.Infrastructure.Models.Mappings;
using Vacations.Domain.Interfaces.Repositories;
using Vacations.Infrastructure.Data.Contexts;
using Vacations.Application.Models.Mappings;
using Vacations.Application.Services;
using Vacations.Infrastructure.Data;
using Vacations.API.Middlewares;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

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

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme).AddNegotiate();

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
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Vacations.API").UseCompatibilityLevel(120)));


#endregion

#region DependenciesInjection

//services
builder.Services.AddScoped<IAbsenceService, AbsenceService>();
builder.Services.AddScoped<IPlanningProcessService, PlanningProcessService>();
builder.Services.AddScoped<IEmployeeStatusesService, EmployeeStatusesService>();

//data
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(InfrastructureMappingProfile), typeof(ApplicationMappingProfile));

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseCors(corsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

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
