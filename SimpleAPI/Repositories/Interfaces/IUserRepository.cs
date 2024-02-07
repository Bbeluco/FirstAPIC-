namespace SimpleAPI;

public interface IUserRepository
{
    Task<List<UserModel>> SearchAllUsers();
    Task<UserModel> SearchUserById(int id);
    // Task<UserModel> Add();
    // Task<UserModel> Update();
    // Task<UserModel> Delete();
}
