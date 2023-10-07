using SRSAppV2.Domain.Entities;

namespace SRSAppV2.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task Add(User user);
}
