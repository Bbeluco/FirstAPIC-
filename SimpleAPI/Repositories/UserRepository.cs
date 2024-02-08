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

    public async Task<UserModel> Add(UserModel user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }

    public async Task<UserModel> Delete(int id)
    {
        UserModel user = await SearchUserById(id);
        _dbContext.Remove(user);
        _dbContext.SaveChanges();

        return user;
    }

    public async Task<UserModel> Update(UserModel user)
    {
        UserModel userModel = await SearchUserById(user.Id);
        userModel.Name = user.Name;
        userModel.Email = user.Email;

        _dbContext.Users.Update(userModel);
        _dbContext.SaveChanges();

        return userModel;
    }
}
