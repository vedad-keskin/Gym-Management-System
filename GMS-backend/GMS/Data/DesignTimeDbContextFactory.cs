using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace GMS.Data
{
    /// <summary>
    /// Used by EF Core tools (e.g. dotnet ef migrations add) at design time.
    /// Loads .env and builds PostgreSQL connection string.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DotNetEnv.Env.TraversePath().Load();

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

            port = string.IsNullOrWhiteSpace(port) ? "5432" : port;
            var connectionString = string.IsNullOrWhiteSpace(host) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password)
                ? "Host=localhost;Port=5432;Database=GMS_db;Username=postgres;Password=postgres"
                : $"Host={host};Port={port};Database={name};Username={user};Password={password}";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
