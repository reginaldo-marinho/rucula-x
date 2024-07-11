using System.Text.Json;
using RuculaX.Database;

namespace Ruculax.Database.Test;

public class UserQuery : IQuery
{
    QueryTestConnetion _connetion;
    public UserQuery(QueryTestConnetion connetion)
    {
        _connetion = connetion;
    }
    public async Task<IQueryConfigurationOutput> QueryAsync(IQueryConfigurationInput config)
    {
        var optionsInput = JsonSerializer.Deserialize<UserQueryOptions>(config.Options);
 
        List<User> users = null;

        if(config.Next)
        {
            users = (
                from user in _connetion.Users
                where user.Id > optionsInput?.LastId
                orderby user.Id ascending
                select user).Take(3).ToList();
        }

        if(config.Next is false)
        {
            users = (
                from user in _connetion.Users
                where user.Id <= optionsInput?.LastId
                orderby user.Id descending 
                select user).Take(3).ToList();
        }

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
