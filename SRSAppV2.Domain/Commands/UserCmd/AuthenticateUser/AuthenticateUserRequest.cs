using MediatR;

namespace SRSAppV2.Domain.Commands.UserCmd.AuthenticateUser;

public class AuthenticateUserRequest: IRequest<Response>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
