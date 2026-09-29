namespace Reolmarkedet.Core.Models;

public class ShelfType
{
    public int Id;
    private string _name;

    public string Name
    {
        get =>  _name;
    }

    private int _shelfCount;

    public int ShelfCount
    {
        get => _shelfCount;
    }

    private bool _hasHangerRod;

    public bool HasHangerRod
    {
        get => _hasHangerRod;
    }

    public ShelfType(string name, int shelfCount, bool hasHangerRod)
    {
        _name = name;
        _shelfCount = shelfCount;
        _hasHangerRod = hasHangerRod;
    }
}