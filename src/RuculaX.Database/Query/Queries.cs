namespace RuculaX.Database.Query;

public interface IPagedQuery
{
    Type Get(string name);
}

public abstract class PagedQuery : IPagedQuery
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
