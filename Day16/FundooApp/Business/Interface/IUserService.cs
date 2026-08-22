using Models.DTO;

namespace Business.Interface;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterRequestDTO request);

    Task<AuthResponseDTO?> LoginUserAsync(LoginRequestDTO request);
}