using System.Text.Json;
using RuculaX.Database;

namespace Ruculax.Database.Test;

[TestClass]
public class QueryFactoryTest
{
    [TestMethod]
    public async Task GetQueryPagedTwo_wayNextAndPrevious()
    {
        var queries = new QueriesDatabase();
        var connection = new QueryConnetion();
        var factoryQuery = new FactoryQuery<QueryConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            RowNumber = 2,
            Options = "{\"LastId\": 0}"
        };

        var pageOne = await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  JsonSerializer.Deserialize<List<User>>(pageOne.Data);

        Assert.AreEqual(usersPageOne[0].Name, "Reginaldo");
        Assert.AreEqual(usersPageOne[1].Name, "Luis");

        var options = JsonSerializer.Deserialize<UserQueryOptions>(pageOne.Options);
        
        var userOptions = new UserQueryOptions(options.LastId);

        var userPageTwo = new QueryConfigurationInput()
        {
            Name = nameof(User),
            RowNumber = 2,
            Options = JsonSerializer.Serialize(userOptions)
        };

        var pageTwo = await factoryQuery.QueryAsync(userPageTwo);
        var usersPageTwo = JsonSerializer.Deserialize<List<User>>(pageTwo.Data);

        Assert.AreEqual(usersPageTwo[0].Name, "Nathalia");
        Assert.AreEqual(usersPageTwo[1].Name, "Elizangela");


        var userPagePreviousOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Options = JsonSerializer.Serialize(userOptions),
            Next = false
        };

        var pagePrevious = await factoryQuery.QueryAsync(userPagePreviousOne);
        var usersPagePrevious = JsonSerializer.Deserialize<List<User>>(pagePrevious.Data);

        Assert.AreEqual(usersPagePrevious[0].Name, "Reginaldo");
        Assert.AreEqual(usersPagePrevious[1].Name, "Luis");

    }

}
