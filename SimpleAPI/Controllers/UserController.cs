using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository) {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> SearchAllUsers() {
        List<UserModel> user = await _userRepository.SearchAllUsers();
        return Ok(user);
    }
}
