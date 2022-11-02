using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Services
{
    public interface IBaseService<T,TDto> where T : class
    {
        Task<ActionResult> GetAllAsync(CancellationToken cancellationToken);

        Task<ActionResult<T>> GetByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<ActionResult> CreateAsync(TDto dataDto,
            CancellationToken cancellationToken);

        Task<ActionResult<T>> DeleteByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<ActionResult> UpdateAsync(Guid id, TDto dataToUpdateWith,
            CancellationToken cancellationToken);

        Task<ActionResult> DeleteMiddlePage(Guid id, 
            CancellationToken cancellationToken);
    }
}
