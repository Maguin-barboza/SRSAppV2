using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRSAppV2.API.DTOs;
using SRSAppV2.Domain.Entities;
using SRSAppV2.Domain.Interfaces.Repositories;
using SRSAppV2.Infra.Repositories;

namespace SRSAppV2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    //TODO: Verificar erro Error: SSL peer certificate or SSH remote key was not OK
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserDto userDTO)
    {
        try
        {
            User user = new User(new Guid(), userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.Password);
            await _repository.Add(user);

            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
