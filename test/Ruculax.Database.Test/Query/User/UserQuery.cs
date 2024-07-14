using System.Text.Json;
using RuculaX.Database.Query;


namespace Ruculax.Database.Test;

public class UserQuery : PaginationAsync, IQuery
{
    QueryConnetion _connetion;
    public UserQuery(QueryConnetion connetion)
    {
        _connetion = connetion;
    }
    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        var output = await QueryAsync(config.Page,config);
        return output;
    }

    protected async override Task<IQueryConfigurationOutput> FirstAsync(IQueryConfigurationInput config)
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

        var output = new QueryConfigurationOutput()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = JsonSerializer.Serialize(users)
        };

        return output;
    }

    protected async override Task<IQueryConfigurationOutput> LastAsync(IQueryConfigurationInput config)
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

        var output = new QueryConfigurationOutput()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = JsonSerializer.Serialize(users)
        };

        return output;   
        
    }

    protected override async Task<IQueryConfigurationOutput> NextAsync(IQueryConfigurationInput config)
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

        var output = new QueryConfigurationOutput()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = JsonSerializer.Serialize(users)
        };

        return output;

    }

    protected async override Task<IQueryConfigurationOutput> PreviousAsync(IQueryConfigurationInput config)
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

        var output = new QueryConfigurationOutput()
        {
            Name = nameof(User),
            Description = "Teste de paginação para usuários",
            Options = JsonSerializer.Serialize(optionsOutput),
            Data = JsonSerializer.Serialize(users)
        };

        return output;
    }
}
