using App.Repository.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Repository.Interceptors;

public class AuditDbContextInterceptors : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var context = eventData.Context!.ChangeTracker.Entries();

        foreach (var entry in context.ToList())
        {
            if(entry.Entity is not IAuditEntity auditEntity) continue;
            if(entry.State is not (EntityState.Added or EntityState.Deleted or EntityState.Modified)) continue;
            if(entry.State is EntityState.Added) AddBehavior(eventData.Context, auditEntity);
            if(entry.State is EntityState.Modified) UpdateBehavior(eventData.Context, auditEntity);
            if(entry.State is EntityState.Deleted) DeleteBehavior(eventData.Context, auditEntity);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }



    private void AddBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.CreatedAt = DateTime.Now;
        context.Entry(auditEntity).Property(x => x.UpdatedAt).IsModified = false;
        context.Entry(auditEntity).Property(x => x.DeletedAt).IsModified = false;
    }

    private void UpdateBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.UpdatedAt = DateTime.Now;
        context.Entry(auditEntity).Property(x => x.DeletedAt).IsModified = false;
        context.Entry(auditEntity).Property(x => x.CreatedAt).IsModified = false;
    }

    private void DeleteBehavior(DbContext context, IAuditEntity auditEntity)
    {
        auditEntity.DeletedAt = DateTime.Now;
        context.Entry(auditEntity).Property(x => x.CreatedAt).IsModified = false;
        context.Entry(auditEntity).Property(x => x.UpdatedAt).IsModified = false;
    } 
}