namespace Reolmarkedet.Core.Models;

public class Shelf
{
    public int ID;
    public string ShelfName;
    public ShelfType ShelfType;
    public bool Status = false;

    public Shelf(string shelfName, ShelfType shelfType)
    {
        ShelfName = shelfName;
        ShelfType = shelfType;
    }
}