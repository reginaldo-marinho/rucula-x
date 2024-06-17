using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ruculax.Database.Common;
using RuculaX.Domain;


namespace RuculaX.EntityFramework;
public class RepositoryCudMApAsync<TEntity, TentityDto,TIdentity, TType, TMapper> : 
    RepositoryCudBaseAsync<TEntity,TIdentity,TType>,
    ICommandDtoAsync<TentityDto,TEntity,TIdentity>
        where TEntity : Entity<TType>
        where TentityDto : Entity<TType>
        where TMapper: IRuculaMap<TentityDto, TEntity>
{
    private TMapper Mapper;

    public RepositoryCudMApAsync(DbContext context, TMapper mapper) : base(context)
    {
        Mapper = mapper;
    }

    public async  Task AlterAsync(TentityDto inputDto)
    {   
        var input = this.Mapper.MapObjetc(inputDto);
        await this.AlterAsync(input);
    }

    public async Task AlterAsync(TentityDto inputDto, TIdentity identity)
    {
        var input = this.Mapper.MapObjetc(inputDto);
        await this.AlterAsync(input, identity);
    }

    public async Task AlterAsync(TentityDto inputDto, Expression<Func<TEntity, bool>> predicate)
    {
        var input = this.Mapper.MapObjetc(inputDto);
        await this.AlterAsync(input, predicate);   
    }
    public async Task DeleteAsync(TentityDto identityDto)
    {
        var input = this.Mapper.MapObjetc(identityDto);
        await this.DeleteAsync(input);      
    }

    public Task DeleteAsync(TentityDto inputDto, TIdentity identity)
    {
        throw new NotImplementedException();
    }

    public Task InsertAsync(TentityDto input)
    {
        throw new NotImplementedException();
    }
}
