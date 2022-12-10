using Microsoft.AspNetCore.Mvc;

namespace RunnersBlogMVC.Services
{
    public interface IBaseService<T,TDto> where T : class?
    {
        Task<IActionResult> GetAllAsync(CancellationToken cancellationToken);

        Task<ActionResult<T>> GetByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<IActionResult> CreateAsync(TDto dataDto,
            CancellationToken cancellationToken);

        Task<ActionResult<T>> DeleteByIdAsync(Guid id,
            CancellationToken cancellationToken);

        Task<IActionResult> UpdateByIdAsync(Guid id, TDto dataToUpdateWith,
            CancellationToken cancellationToken);

        Task<IActionResult> MiddlePage(Guid id, 
            CancellationToken cancellationToken);
    }
}
