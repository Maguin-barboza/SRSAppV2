using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSAppV2.API.DTOs;
using SRSAppV2.Domain.Commands.UserCmd.AddUser;
using SRSAppV2.Domain.Commands.UserCmd.AuthenticateUser;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Infra.Repositories;
using SRSAppV2.Infra.UnityOfWork;

namespace SRSAppV2.API.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IMediator mediator, IUnitOfWork unityOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unityOfWork;
    }

    [HttpGet]
    [Route("api/User/Hello")]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }

    [HttpPost]
    [Route("api/User/Add")]
    public async Task<IActionResult> Post(AddUserRequest request)
    {
        try
        {
            var response = await _mediator.Send(request, CancellationToken.None);

            if(response.Notifications.Any())
            {
                return BadRequest(response.Notifications);
            }

            _unitOfWork.SaveChanges();
            return Ok(response.Data);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("api/User/Auth")]
    public async Task<IActionResult> Authenticate(AuthenticateUserRequest request)
    {
        try
        {
            var response = await _mediator.Send(request, CancellationToken.None);

            if (response.Notifications.Any())
            {
                return BadRequest(response.Notifications);
            }

            return Ok(response.Data);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
