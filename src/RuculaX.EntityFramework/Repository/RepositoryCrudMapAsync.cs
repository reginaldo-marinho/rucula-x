using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RuculaX.Database.Common.Crud;
using RuculaX.Domain;


namespace RuculaX.EntityFramework;
public abstract class RepositoryCudMApAsync<TEntity, TentityDto,TIdentity, TType, TMapper> : 
    RepositoryCrudBaseAsync<TEntity,TIdentity,TType>,
    ICrudDtoAsync<TentityDto,TEntity,TIdentity>
        where TEntity : Entity<TType>
        where TentityDto : Entity<TType>
        where TMapper: IRuculaMap
{
    private TMapper Mapper;

    public RepositoryCudMApAsync(DbContext context, TMapper mapper) : base(context)
    {
        Mapper = mapper;
    }

    public async  Task AlterAsync(TentityDto inputDto)
    {   
        var input = this.Mapper.MapObjetc<TEntity,TentityDto>(inputDto);
        await base.AlterAsync(input);
    }
    
    public async Task AlterAsync(TentityDto inputDto, Expression<Func<TEntity, bool>> predicate)
    {
        var input = this.Mapper.MapObjetc<TEntity,TentityDto>(inputDto);
        await base.AlterAsync(input, predicate);   
    }
    
    public async Task DeleteAsync(TentityDto identityDto)
    {
        var input = this.Mapper.MapObjetc<TEntity,TentityDto>(identityDto);
        await base.DeleteAsync(input);
    }

    public async Task DeleteAsync(TentityDto inputDto, Expression<Func<TEntity, bool>> predicate)
    {
        var input = this.Mapper.MapObjetc<TEntity,TentityDto>(inputDto);
        await base.DeleteAsync(input, predicate);
    }
    
    public  async Task InsertAsync(TentityDto identityDto)
    {
        var input = this.Mapper.MapObjetc<TEntity,TentityDto>(identityDto);
        await base.InsertAsync(input);   
    }

    public async Task<TentityDto> GetAsync(TEntity input, CancellationToken token)
    {
        var result = await base.GetAsync(input, token);

        var resultDto = this.Mapper.MapObjetc<TentityDto,TEntity>(result);

        return resultDto;
    }

    public async Task<TentityDto> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
    {
        var result = await base.GetAsync(predicate);
        
        var resultDto = this.Mapper.MapObjetc<TentityDto,TEntity>(result);

        return resultDto;
    }
}
