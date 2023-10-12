using MediatR;
using SRSAppV2.Domain.Entities;

namespace SRSAppV2.Domain.Commands.UserCmd.AddUser;

public class AddUserNotification: INotification
{
    public User User { get; private set; }

    public AddUserNotification(User user)
    {
        User = user;
    }
}
