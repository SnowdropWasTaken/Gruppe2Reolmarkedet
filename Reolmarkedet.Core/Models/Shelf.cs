namespace Reolmarkedet.Core.Models;

public class Shelf
{
    public int Id;
    public string ShelfName;
    public ShelfType ShelfType;
    public bool Status;

    public Shelf(string shelfName, ShelfType shelfType)
    {
        ShelfName = shelfName;
        ShelfType = shelfType;
    }
}