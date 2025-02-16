using App.Repository.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Repository.Interceptors;

public class AuditDbContextInterceptors : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var context = eventData.Context;
        if (context is null) return base.SavingChangesAsync(eventData, result, cancellationToken);

        foreach (var entry in context.ChangeTracker.Entries<IAuditEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    AddBehavior(entry);
                    break;
                
                case EntityState.Modified:
                    UpdateBehavior(entry);
                    break;
                
                case EntityState.Deleted:
                    DeleteBehavior(entry);
                    break;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }



    private void AddBehavior(EntityEntry<IAuditEntity> entry)
    {
        entry.Entity.CreatedAt = DateTime.UtcNow;
        entry.Entity.UpdatedAt = DateTime.UtcNow;
        entry.Property(x => x.DeletedAt).IsModified = false;
    }

    private void UpdateBehavior(EntityEntry<IAuditEntity> entry)
    {
        entry.Entity.UpdatedAt = DateTime.UtcNow;
        entry.Property(x => x.CreatedAt).IsModified = false;
        entry.Property(x => x.DeletedAt).IsModified = false;
    }

    private void DeleteBehavior(EntityEntry<IAuditEntity> entry)
    {
        entry.Entity.DeletedAt = DateTime.Now;
        entry.State = EntityState.Modified;
        entry.Property(x => x.CreatedAt).IsModified = false;
        entry.Property(x => x.UpdatedAt).IsModified = false;
    } 
}