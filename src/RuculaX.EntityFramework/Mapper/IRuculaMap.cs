namespace RuculaX.EntityFramework;
public interface IRuculaMap
{
    public TTo MapObjetc<TTo,TFrom>(TFrom input);
}
