using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken);

        Task<T> GetByIdAsync(string id,
            CancellationToken cancellationToken);

        Task<ActionResult> CreateAsync(T data,
            CancellationToken cancellationToken);

        Task DeleteByIdAsync(string id,
            CancellationToken cancellationToken);

        Task UpdateAsync(T data,
            CancellationToken cancellationToken);
    }
}
