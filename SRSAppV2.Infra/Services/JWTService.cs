using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Interfaces.Services;

namespace SRSAppV2.Infra.Services;

public class JWTService : IJWTService
{
    public Task<string> GetToken(User user)
    {
        throw new NotImplementedException();
    }
}
