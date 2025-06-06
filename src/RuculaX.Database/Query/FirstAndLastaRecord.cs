namespace RuculaX.Database.Query;

public class FirstAndLastRecordSnapshot<TRecordSnapshot>
{
    public TRecordSnapshot First { get; set; }
    public TRecordSnapshot Last { get; set; }
}
