using KeepNote3.Entities;
namespace KeepNote3.IRepo
{
    public interface IUserRepository
    {
        bool RegisterUser(User user);
        bool UpdateUser(User user);
        User GetUserById(string userId);
        bool ValidateUser(string userId, string password);
        bool DeleteUser(string userId);

    }
}
