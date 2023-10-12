using Microsoft.EntityFrameworkCore;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Infra.Context;

namespace SRSAppV2.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly SRSAppContext _context;

    public UserRepository(SRSAppContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public bool Exists(Func<User, bool> where)
    {
        return _context.Set<User>().Any(where);
    }

    public async Task<User> GetById(Guid Id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
    }
}
