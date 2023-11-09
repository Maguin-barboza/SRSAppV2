using MediatR;
using prmToolkit.NotificationPattern;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Extensions;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Domain.Interfaces.Services;

namespace SRSAppV2.Domain.Commands.UserCmd.AuthenticateUser;

public class AuthenticateUserHandler : Notifiable, IRequestHandler<AuthenticateUserRequest, Response>
{
    private readonly IUserRepository _repository;
    private readonly IJWTService _jwtService;

    public AuthenticateUserHandler(IUserRepository repository, IJWTService jwtService)
    {
        _repository = repository;
        _jwtService = jwtService;
    }

    public async Task<Response> Handle(AuthenticateUserRequest request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            this.AddNotification("Authenticate", "Necessário informar Email e Password");
            return new Response(this);
        }

        User user = await _repository.GetByEmail(request.Email);

        if(user is null)
        {
            this.AddNotification("Authenticate", "Usuário incorreto ou não está cadastrado.");
            return new Response(this);
        }

        if(user.Password != request.Password.ConvertToMD5())
        {
            this.AddNotification("Authenticate", "Senha incorreta.");
        }

        string token = await _jwtService.GetToken(user);
        Response response = new Response(this, token);

        return response;
    }
}
