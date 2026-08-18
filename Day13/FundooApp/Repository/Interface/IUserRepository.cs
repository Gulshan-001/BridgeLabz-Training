using Models.Entity;

namespace Repository.Interface;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);

    Task<User> AddUserAsync(User user);
}