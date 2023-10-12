using MediatR;

namespace SRSAppV2.Domain.Commands.UserCmd.AddUser;

public class AddUserRequest: IRequest<Response>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
