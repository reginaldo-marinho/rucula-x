
using System.Linq.Expressions;

namespace RuculaX.Database.Common.Crud
{
   public interface ICrudDtoAsync<TEntityDto, TEntity, TIdentity>
    {
        Task InsertAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
        Task DeleteAsync(TEntityDto inputDto);
        Task DeleteAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
        Task<TEntityDto> GetAsync(TEntity input, CancellationToken token);  
        Task<TEntityDto> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token);       

    }
}