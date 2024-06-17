
using System.Linq.Expressions;

namespace RuculaX.Database.Common.Crud
{
   public interface ICrudDtoAsync<TEntityDto, TEntity, TIdentity>
    {
        Task InsertAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto);   
        Task AlterAsync(TEntityDto inputDto,TIdentity identity);  
        Task AlterAsync(TEntityDto inputDto,Expression<Func<TEntity, bool>> predicate);  
        Task DeleteAsync(TEntityDto inputDto);
        Task DeleteAsync(TEntityDto inputDto,TIdentity identity);   
    }
}