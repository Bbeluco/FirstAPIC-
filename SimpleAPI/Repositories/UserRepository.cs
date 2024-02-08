using Microsoft.EntityFrameworkCore;

namespace SimpleAPI;

public class UserRepository : IUserRepository
{
    private SystemTaskContext _dbContext;

    public UserRepository(SystemTaskContext systemTaskContext) {
        _dbContext = systemTaskContext;
    }

    public async Task<List<UserModel>> SearchAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<UserModel> SearchUserById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<UserModel> Add()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Delete()
    {
        throw new NotImplementedException();
    }

    public Task<UserModel> Update()
    {
        throw new NotImplementedException();
    }
}
