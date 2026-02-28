using GMS.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using GMS.Helpers.Services;
using GMS.Helpers.Auth;
using GMS.Services;

// PostgreSQL/Npgsql: accept DateTime with Kind=Local or Unspecified (treat as UTC when writing)
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Load .env from project directory (keeps secrets out of appsettings and git)
DotNetEnv.Env.TraversePath().Load();

var connectionString = BuildPostgresConnectionString();
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

if (string.IsNullOrWhiteSpace(connectionString))
    connectionString = config.GetConnectionString("db1");
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException(
        "Database connection not configured. Set DB_MODE=local or DB_MODE=supabase and the corresponding DB_* vars in .env (see .env.example), or ConnectionStrings:db1 in appsettings.json.");

var dbMode = Environment.GetEnvironmentVariable("DB_MODE")?.Trim().ToLowerInvariant();
var deployEnv = Environment.GetEnvironmentVariable("ENVIRONMENT")?.Trim().ToLowerInvariant();
Console.WriteLine($"Database mode: {(dbMode == "supabase" ? "Supabase" : "Local PostgreSQL")}");
Console.WriteLine($"Environment: {(deployEnv == "production" ? "Production (Render)" : "Local")}");

// Render sets PORT; use it so the app listens on the correct port.
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => x.OperationFilter<AutorizacijaSwaggerHeader>());
builder.Services.AddTransient<MyAuthService>();
builder.Services.AddTransient<MyActionLogService>();
builder.Services.AddTransient<MyEmailSenderService>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.UseStaticFiles();

var frontendUrl = Environment.GetEnvironmentVariable("FRONTEND_URL")?.Trim();
if (deployEnv == "production" && !string.IsNullOrWhiteSpace(frontendUrl))
{
    app.UseCors(policy => policy
        .WithOrigins(frontendUrl)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
}
else
{
    app.UseCors(options => options
        .SetIsOriginAllowed(x => _ = true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply pending migrations on startup (e.g. on Render)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var pending = db.Database.GetPendingMigrations().Any();
    if (pending)
    {
        Console.WriteLine("Pending migrations detected. Applying migrations...");
        db.Database.Migrate();
        Console.WriteLine("Migrations applied successfully.");
    }
}

app.Run();

static string? BuildPostgresConnectionString()
{
    var mode = Environment.GetEnvironmentVariable("DB_MODE")?.Trim().ToLowerInvariant();
    string? host, port, name, user, password;

    if (mode == "supabase")
    {
        host = Environment.GetEnvironmentVariable("DB_SUPABASE_HOST");
        port = Environment.GetEnvironmentVariable("DB_SUPABASE_PORT");
        name = Environment.GetEnvironmentVariable("DB_SUPABASE_NAME");
        user = Environment.GetEnvironmentVariable("DB_SUPABASE_USER");
        password = Environment.GetEnvironmentVariable("DB_SUPABASE_PASSWORD");
    }
    else
    {
        host = Environment.GetEnvironmentVariable("DB_HOST");
        port = Environment.GetEnvironmentVariable("DB_PORT");
        name = Environment.GetEnvironmentVariable("DB_NAME");
        user = Environment.GetEnvironmentVariable("DB_USER");
        password = Environment.GetEnvironmentVariable("DB_PASSWORD");
    }

    if (string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
        return null;
    port = string.IsNullOrWhiteSpace(port) ? "5432" : port;
    return $"Host={host};Port={port};Database={name};Username={user};Password={password}";
}
