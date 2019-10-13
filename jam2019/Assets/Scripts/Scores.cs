using SQLite4Unity3d;

[Table("Scores")]
public class Scores
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public string score { get; set; }
}
