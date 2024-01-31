using Finshark.Models;

namespace Finshark.Interfaces
{
    public interface ICommectRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
    }
}
