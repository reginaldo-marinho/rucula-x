namespace RuculaX.EntityFramework;
public interface IRuculaMap<TFrom, Tto>
{
    public Tto MapObjetc(TFrom input);
}
