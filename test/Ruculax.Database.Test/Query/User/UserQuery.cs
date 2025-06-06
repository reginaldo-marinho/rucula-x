using System.Text.Json;
using RuculaX.Database.Query;


namespace Ruculax.Database.Test;

public class UserQuery : PaginationAsync<User>, IQuery
{
    QueryConnetion _connetion;
    public UserQuery(QueryConnetion connetion)
    {
        _connetion = connetion;
    }
    public async Task<QueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        var output = await QueryAsync(config.Page,config);
        return output;
    }

    protected async override Task<QueryConfigurationOutput<User>> FirstAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);

        var users = await Task.Run(() =>(
                from user in _connetion.Users
                select user)    
                .Take(config.RowNumber)
                .OrderBy(user => user.Id)
                .ThenBy(user => user.Name)
                .ToList());

        var lastUser = users?.Last();
        
        var optionsOutput = new UserQueryOptions(lastUser.Id);

        var output = new QueryConfigurationOutput<User>()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = users
        };

        return output;
    }

    protected async override Task<QueryConfigurationOutput<User>> LastAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);

         var users = await Task.Run(() =>(
                from user in _connetion.Users
                orderby user.Id descending 
                select user)
                
            .Take(config.RowNumber)
            .OrderBy(user => user.Id)
            .ToList());

        var lastUser = users?.Last();
        
        var optionsOutput = new UserQueryOptions(lastUser.Id);

        var output = new QueryConfigurationOutput<User>()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = users
        };

        return output;   
        
    }

    protected override async Task<QueryConfigurationOutput<User>> NextAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);

        var users = await Task.Run(() => (
                from user in _connetion.Users
                where user.Id > optionsInput?.LastId
                orderby user.Id ascending
                select user)
                .Take(config.RowNumber)
                .ToList());

        var lastUser = users?.Last();
        
        var optionsOutput = new UserQueryOptions(lastUser.Id);

        var output = new QueryConfigurationOutput<User>()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = users
        };

        return output;

    }

    protected async override Task<QueryConfigurationOutput<User>> PreviousAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);

        var users = await Task.Run(() =>(
                from user in _connetion.Users
                where user.Id <= optionsInput?.LastId
                orderby user.Id descending 
                select user)
                
            .Take(config.RowNumber)
            .OrderBy(user => user.Id)
            .ToList());

        var lastUser = users?.Last();
        
        var optionsOutput = new UserQueryOptions(lastUser.Id);

        var output = new QueryConfigurationOutput<User>()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = users
        };

        return output;
    }

    protected async override Task<QueryConfigurationOutput<User>> ContainAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);

        var users = await Task.Run(() => (
            from user in _connetion.Users
            where user.Name.Contains(config.Text)
            orderby user.Id ascending
            select user)
            .Take(config.RowNumber)
            .ToList());

        var lastUser = users?.Last();
        
        var optionsOutput = new UserQueryOptions(lastUser.Id);

        var output = new QueryConfigurationOutput<User>()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = users
        };

        return output;
    }

}
