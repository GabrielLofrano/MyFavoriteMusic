using MyFavoriteMusic.Domain.Entities;

namespace MyFavoriteMusic.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid id);
        Task AddAsync (User user);
        Task UpdateAsync (User user);
        Task DeleteAsync (User user);
    }
}
