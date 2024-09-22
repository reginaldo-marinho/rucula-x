using System.Linq.Expressions;
using RuculaX.Database.Common.Crud;

namespace RuculaX.EntityFramework.Test;

public class MapperCrudRepository : RepositoryCrudMApAsync<User, UserDTo, string>
{
    public MapperCrudRepository(RepositoryCrudBaseAsync<User, string> repository) : base(repository)
    {
    }
    public override async Task AlterAsync(UserDTo inputDto)
    {
        User user = new()
        {
            Id = inputDto.Id
        };
        await this.Repository.AlterAsync(user, new AlterMapUser(inputDto));
    }

    public override async Task AlterAsync(UserDTo inputDto, Expression<Func<User, bool>> predicate)
    {
        User user = new()
        {
            Id = inputDto.Id
        };
        await Repository.AlterAsync(user,predicate);
    }

    public async override Task DeleteAsync(UserDTo inputDto)
    {
        User user = new()
        {
            Id = inputDto.Id
        };

        await Repository.DeleteAsync(user);
    }

    public override async Task DeleteAsync(UserDTo inputDto, Expression<Func<User, bool>> predicate)
    {
        User user = new()
        {
            Id = inputDto.Id
        };
        await Repository.AlterAsync(user,predicate);    
    }

    public override async Task<UserDTo> GetAsync(User input, CancellationToken token = default)
    {
        var result = await Repository.GetAsync(input, null,  token); 
        return new UserDTo
        {
            Id = result.Id
        };
    }

    public override async Task<UserDTo> GetAsync(Expression<Func<User, bool>> predicate, CancellationToken token = default)
    {
        var result = await Repository.GetAsync(predicate, null, token); 
        return new UserDTo
        {
            Id = result.Id
        };
    }

    public async override Task InsertAsync(UserDTo inputDto)
    {
        User user = new()
        {
            Id = inputDto.Id
        };
        await Repository.InsertAsync(user);
    }
}


public class AlterMapUser : IAlterMap<User>
{
    UserDTo _inputDto;
    public AlterMapUser(UserDTo inputDto)
    {
        _inputDto = inputDto;
    }
    public User Map(User entity)
    {
        entity.Id = _inputDto.Id;
    return entity;
    }
}