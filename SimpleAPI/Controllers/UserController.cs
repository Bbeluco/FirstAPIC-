using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;

    public UserController(IUserRepository userRepository) 
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<UserModel>>> SearchAllUsers() 
    {
        List<UserModel> user = await _userRepository.SearchAllUsers();
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> SearchUserById(int id) 
    {
        UserModel user = await _userRepository.SearchUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<UserModel>> AddUser([FromBody] UserModel user) 
    {
        UserModel newUser = await _userRepository.Add(user);
        return Ok(newUser);
    }

    [HttpPut]
    public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel user) 
    {
        UserModel updatedUser = await _userRepository.Update(user);

        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id) 
    {
        await _userRepository.Delete(id);
        return Ok();
    }
}
