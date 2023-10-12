using SRSAppV2.Infra.Context;

namespace SRSAppV2.Infra.UnityOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly SRSAppContext _context;

    public UnitOfWork(SRSAppContext context)
    {
        _context = context;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}
