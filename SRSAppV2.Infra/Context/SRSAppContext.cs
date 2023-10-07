using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Infra.Context.Maps;

namespace SRSAppV2.Infra.Context;

public class SRSAppContext : DbContext
{
    public SRSAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<Notification>();

        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
