using Microsoft.EntityFrameworkCore;
using PC28084.U20211c201.Prueba.Capbase.Platform.Paperwork.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration.Extensions;
using PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;

namespace PC28084.U20211c201.Prueba.Capbase.Platform.Shared.Infrastructure.Persistence.EntityFrameworkCore.Configuration;

/// <summary>
///     Application database context for the Capbase Platform
/// </summary>
/// <param name="options">
///     The options for the database context
/// </param>
/// <remarks>
///     Author: Gerardo Palacin
/// </remarks>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Apply audit timestamp interceptor for all IAuditableEntity implementations
        builder.AddInterceptors(new AuditableEntityInterceptor());
        base.OnConfiguring(builder);
    }

    /// <summary>
    ///     On creating the database model
    /// </summary>
    /// <remarks>
    ///     This method is used to create the database model for the application.
    ///     Author: Gerardo Palacin
    /// </remarks>
    /// <param name="builder">
    ///     The model builder for the database context
    /// </param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Paperwork Context
        builder.ApplyPaperworkConfiguration();

        // General Naming Convention for the database objects
        builder.UseSnakeCaseNamingConvention();
    }
}
