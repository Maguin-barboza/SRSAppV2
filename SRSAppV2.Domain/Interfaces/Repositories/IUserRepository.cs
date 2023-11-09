using SRSAppV2.Domain.Entities;

namespace SRSAppV2.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    bool Exists(Func<User, bool> where);
    Task<User> GetById(Guid Id);
    Task<User> GetByEmail(string Email);
    Task Add(User user);
}
