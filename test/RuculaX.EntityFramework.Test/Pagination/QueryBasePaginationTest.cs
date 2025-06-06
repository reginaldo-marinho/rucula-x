using System.Text.Json;
using RuculaX.Database.Query;

namespace RuculaX.EntityFramework.Test.Pagination;

[TestClass]
public class QueryBasePaginationTest
{
    TestContext ctx;
    public QueryBasePaginationTest()
    {
        ctx = DbInMemory.CreateContextTest();
        ctx.AddRange(UsersData.GetUsersToPagination());
        ctx.SaveChanges();
    }

    [TestMethod]
    public async Task QueryContainTestAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Contain,
            Options = JsonSerializer.Serialize(firstAndLast),
            Text = "R"
        };

        var queryPagination = new PaginationUser(ctx);
        var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 4);
        Assert.AreEqual(users[0].Name, "Renato");
        Assert.AreEqual(users[3].Name, "Raquel");
    }

    [TestMethod]
    public async Task QueryFirstTestAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.First,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 2,

        };

        var queryPagination = new PaginationUser(ctx);
        var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);
        var users = result.Data;

        Assert.AreEqual(users.Count, 2);
        Assert.AreEqual(users[0].Id, "001");
        Assert.AreEqual(users[1].Id, "002");
    }
    
    [TestMethod]
    public async Task QueryFirstTesssssstAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.First,
            Options = "{}",
            RowNumber = 2,

        };

        var queryPagination = new PaginationUser(ctx);
        var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 2);
        Assert.AreEqual(users[0].Id, "001");
        Assert.AreEqual(users[1].Id, "002");
    }

    [TestMethod]
    public async Task QueryFirstTestWithTextAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.First,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 3,
            Text = "ca"

        };

        var queryPagination = new PaginationUser(ctx);
                var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 3);
        Assert.AreEqual(users[0].Name, "Lucas");
        Assert.AreEqual(users[1].Name, "Bianca");
        Assert.AreEqual(users[2].Name, "Ricardo");
    }

    [TestMethod]
    public async Task QueryLastTestAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Last,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 2,

        };

        var queryPagination = new PaginationUser(ctx);
        var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 2);
        Assert.AreEqual(users[0].Id, "456");
        Assert.AreEqual(users[1].Id, "789");
    }

    [TestMethod]
    public async Task QueryLastTestWithTextAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>();

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Last,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 3,
            Text = "ia"

        };

        var queryPagination = new PaginationUser(ctx);
                var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 3);
        Assert.AreEqual(users[0].Id, "014");
        Assert.AreEqual(users[1].Id, "017");
        Assert.AreEqual(users[2].Id, "789");
    }

    [TestMethod]
    public async Task QueryNextTestAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>()
        {
            First = new UserRecordSnapshot() { Id = "004" },
            Last = new UserRecordSnapshot() { Id = "005" }
        };

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Next,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 3,

        };

        var queryPagination = new PaginationUser(ctx);
        var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 3);
        Assert.AreEqual(users[0].Id, "006");
        Assert.AreEqual(users[1].Id, "007");
        Assert.AreEqual(users[2].Id, "008");

        var snapshot = JsonSerializer.Deserialize<FirstAndLastRecordSnapshot<UserRecordSnapshot>>(result.Options);

        var input2 = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Next,
            Options = JsonSerializer.Serialize(snapshot),
            RowNumber = 3

        };

        var queryPagination2 = new PaginationUser(ctx);
        var result2 = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input2);

        var users2 = result2.Data;

        Assert.AreEqual(users2[0].Id, "009");
        Assert.AreEqual(users2[1].Id, "010");
        Assert.AreEqual(users2[2].Id, "011");
    }

    [TestMethod]
    public async Task QueryNextTestWithTextAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>()
        {
            First = new UserRecordSnapshot() { Id = "004" },
            Last = new UserRecordSnapshot() { Id = "005" }
        };

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Next,
            Options = JsonSerializer.Serialize(firstAndLast),
            Text = "na",
            RowNumber = 3
        };

        var queryPagination = new PaginationUser(ctx);
                var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 3);
        Assert.AreEqual(users[0].Id, "006");
        Assert.AreEqual(users[1].Id, "011");
        Assert.AreEqual(users[2].Id, "015");
    }
    
    [TestMethod]
    public async Task QueryPreviousTestAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>()
        {
            First = new UserRecordSnapshot() { Id = "014" },
            Last = new UserRecordSnapshot() { Id = "015" }
        };

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Previous,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 3,

        };

        var queryPagination = new PaginationUser(ctx);
                var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 3);
        Assert.AreEqual(users[0].Id, "011");
        Assert.AreEqual(users[1].Id, "012");
        Assert.AreEqual(users[2].Id, "013");

        var snapshot = JsonSerializer.Deserialize<FirstAndLastRecordSnapshot<UserRecordSnapshot>>(result.Options);

        var input2 = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Previous,
            Options = JsonSerializer.Serialize(snapshot),
            RowNumber = 3

        };

        var queryPagination2 = new PaginationUser(ctx);
        var result2 = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input2);

        var users2 = result2.Data;
        
        Assert.AreEqual(users2[0].Id, "008");
        Assert.AreEqual(users2[1].Id, "009");
        Assert.AreEqual(users2[2].Id, "010");
    }

    [TestMethod]
    public async Task QueryPreviousTestWithTextAsync()
    {
        var firstAndLast = new FirstAndLastRecordSnapshot<UserRecordSnapshot>()
        {
            First = new UserRecordSnapshot() {  Id = "019"},
            Last =  new UserRecordSnapshot() {  Id = "020"}
        };

        var input = new QueryConfigurationInput()
        {
            Name = nameof(PaginationUser),
            Page = (byte)OptionPagination.Previous,
            Options = JsonSerializer.Serialize(firstAndLast),
            RowNumber = 3,
            Text = "li"
        };

        var queryPagination = new PaginationUser(ctx);
                var result = (QueryConfigurationOutput<UserResultDto>)await queryPagination.QueryAsync(input);

        var users = result.Data;

        Assert.AreEqual(users.Count, 2);
        Assert.AreEqual(users[0].Id, "006");
        Assert.AreEqual(users[1].Id, "007");
    }
}
