using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Services
{
    public interface IBaseService<T,TDto> where T : class?
    {
        Task<ActionResult> GetAllAsync(CancellationToken cancellationToken);

        Task<ActionResult<T>> GetByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<ActionResult> CreateAsync(TDto dataDto,
            CancellationToken cancellationToken);

        Task<ActionResult<T>> DeleteByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<ActionResult> UpdateByIdAsync(Guid id, TDto dataToUpdateWith,
            CancellationToken cancellationToken);

        Task<ActionResult> MiddlePage(Guid id, 
            CancellationToken cancellationToken);
    }
}
