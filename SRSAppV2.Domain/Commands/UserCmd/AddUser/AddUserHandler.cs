using MediatR;
using prmToolkit.NotificationPattern;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Interfaces.Repositories;

namespace SRSAppV2.Domain.Commands.UserCmd.AddUser;

public class AddUserHandler : Notifiable, IRequestHandler<AddUserRequest, Response>
{
    private readonly IUserRepository _repository;
    private readonly IMediator _mediator;

    public AddUserHandler(IUserRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<Response> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            this.AddNotification("User", "Usuário deve ser informado");
            return new Response(this);
        }

        if(_repository.Exists(x => x.Email == request.Email))
        {
            this.AddNotification("User", "Usuário já existe");
            return new Response(this);
        }

        User user = new User(new Guid(), request.FirstName, request.LastName, request.Email, request.Password);

        if (user.IsInvalid())
        {
            return new Response(this);
        }

        await _repository.Add(user);
        
        Response response = new Response(this, user);
        await _mediator.Publish(new AddUserNotification(user));
        return response;
    }
}
