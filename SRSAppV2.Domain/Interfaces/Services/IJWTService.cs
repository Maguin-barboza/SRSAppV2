using SRSAppV2.Domain.Entities;

namespace SRSAppV2.Domain.Interfaces.Services;

public interface IJWTService
{
    Task<string> GetToken(User user);
}
