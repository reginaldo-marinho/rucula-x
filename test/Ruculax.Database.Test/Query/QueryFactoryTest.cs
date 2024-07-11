using System.Text.Json;
using RuculaX.Database;

namespace Ruculax.Database.Test;

[TestClass]
public class QueryFactoryTest
{
    [TestMethod]
    public async Task QueryAsync()
    {
        var queries = new QueriesDatabaseTest();
        var connection  = new QueryTestConnetion();
        var factoryQuery = new FactoryQuery<QueryTestConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Options = "{\"LastId\": 0}"
        };

        var pageOne = await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  JsonSerializer.Deserialize<List<User>>(pageOne.Data);

        var options = JsonSerializer.Deserialize<UserQueryOptions>(pageOne.Options);
        
        var userOptions = new UserQueryOptions(options.LastId);

        var userPageTwo = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Options = JsonSerializer.Serialize(userOptions)
        };

        var pageTwo = await factoryQuery.QueryAsync(userPageTwo);
        var usersPageTwo = JsonSerializer.Deserialize<List<User>>(pageTwo.Data);


        var userPagePreviousOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Options = JsonSerializer.Serialize(userOptions),
            Next = false
        };

        var pagePrevious = await factoryQuery.QueryAsync(userPagePreviousOne);
        var usersPagePrevious = JsonSerializer.Deserialize<List<User>>(pageTwo.Data);



    }

}
