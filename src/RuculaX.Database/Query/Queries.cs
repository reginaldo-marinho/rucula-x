namespace RuculaX.Database;

public interface IQueries
{
    Type Get(string name);
}

public abstract class Queries : IQueries
{
    private List<KeyValuePair<string,Type>> grids = new ();
    
    protected void Set(string name, Type type)
    {
        grids.Add(new KeyValuePair<string, Type>(name,type));
    }
    public Type Get(string name)
    {
        var grid = grids.First(c=> c.Key == name);
        return grid.Value;
    }
}
