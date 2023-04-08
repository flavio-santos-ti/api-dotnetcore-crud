using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;

namespace Api.Crud.Infra.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task RolbackAsync()
    {
        await Task.CompletedTask;
    }
}
