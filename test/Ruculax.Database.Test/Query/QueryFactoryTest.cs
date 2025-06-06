using System.Text.Json;
using RuculaX.Database.Query;

namespace Ruculax.Database.Test;

[TestClass]
public class QueryFactoryTest
{
    [TestMethod]
    public async Task GetQueryPagedTwo_wayNextAndPreviousAsync()
    {
        var queries = new QueriesDatabase();
        var connection = new QueryConnetion();
        var factoryQuery = new FactoryQuery<QueryConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Page = (byte)OptionPagination.Next, 
            RowNumber = 2,
            Options = "{\"LastId\": 0}"
        };

        var pageOne = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  pageOne.Data;

        Assert.AreEqual(usersPageOne[0].Name, "Reginaldo");
        Assert.AreEqual(usersPageOne[1].Name, "Luis");

        var options = JsonSerializer.Deserialize<UserQueryOptions>(pageOne.Options);
        
        var userOptions = new UserQueryOptions(options.LastId);

        var userPageTwo = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Page = (byte)OptionPagination.Next, 
            RowNumber = 2,
            Options = JsonSerializer.Serialize(userOptions)
        };

        var pageTwo = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPageTwo);
        var usersPageTwo = pageTwo.Data;

        Assert.AreEqual(usersPageTwo[0].Name, "Nathalia");
        Assert.AreEqual(usersPageTwo[1].Name, "Elizangela");


        var userPagePreviousOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Options = JsonSerializer.Serialize(userOptions),
            Page = (byte)OptionPagination.Previous, 
            
        };

        var pagePrevious = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPagePreviousOne);
        var usersPagePrevious = pagePrevious.Data;

        Assert.AreEqual(usersPagePrevious[0].Name, "Reginaldo");
        Assert.AreEqual(usersPagePrevious[1].Name, "Luis");

    }

    [TestMethod]
    public async Task GetQueryPagedFirstAsync()
    {
        var queries = new QueriesDatabase();
        var connection = new QueryConnetion();
        var factoryQuery = new FactoryQuery<QueryConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Page = (byte)OptionPagination.First, 
            RowNumber = 2
        };

        var pageFirst = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  pageFirst.Data;

        Assert.AreEqual(usersPageOne[0].Name, "Reginaldo");
        Assert.AreEqual(usersPageOne[1].Name, "Luis");
    }
    
    [TestMethod]
    public async Task GetQueryPagedLastAsync()
    {
        var queries = new QueriesDatabase();
        var connection = new QueryConnetion();
        var factoryQuery = new FactoryQuery<QueryConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Page = (byte)OptionPagination.Last, 
            RowNumber = 2
        };

        var pageFirst = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  pageFirst.Data;

        Assert.AreEqual(usersPageOne[0].Name, "Ronald");
        Assert.AreEqual(usersPageOne[1].Name, "Raquel");
    }


    [TestMethod]
    public async Task ContainAsync()
    {
        var queries = new QueriesDatabase();
        var connection = new QueryConnetion();
        var factoryQuery = new FactoryQuery<QueryConnetion>(connection,queries);
        
        var userPageOne = new QueryConfigurationInput()
        {
            Name = nameof(User),
            Page = (byte)OptionPagination.Contain, 
            RowNumber = 2,
            Text = "ald" 
        };

        var pageFirst = (QueryConfigurationOutput<User>)await factoryQuery.QueryAsync(userPageOne);
        var usersPageOne =  pageFirst.Data;

        Assert.AreEqual(usersPageOne[0].Name, "Reginaldo");
        Assert.AreEqual(usersPageOne[1].Name, "Ronald");
    }


}
