
using System.Linq.Expressions;

namespace RuculaX.Database.Common.Crud
{
    /// <summary>
    /// Contract for a CRUD repository for Dto
    /// </summary>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
   public interface ICrudDtoAsync<TEntityDto, TEntity>
    {
        Task InsertAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
        Task DeleteAsync(TEntityDto inputDto);
        Task DeleteAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
        Task<TEntityDto> GetAsync(TEntity input, CancellationToken token = default);  
        Task<TEntityDto> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default);       

    }
}