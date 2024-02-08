using System.Globalization;

namespace SimpleAPI;

public interface IUserRepository
{
    Task<List<UserModel>> SearchAllUsers();
    Task<UserModel> SearchUserById(int id);
    Task<UserModel> Add(UserModel user);
    Task<UserModel> Update(UserModel user);
    Task<UserModel> Delete(int id);
}
