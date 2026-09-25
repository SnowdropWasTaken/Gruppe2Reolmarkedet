namespace Reolmarkedet.Core.Models;

public class Lease
{
    private DateTime _startDate;
    
    private double _price;

    public double Price
    {
        get => _price;
        set
        {
            if (value != null && value > 0)
            {
                _price = value;
            }
            else
            {
                throw new ArgumentException("Price must be greater than zero");
            }
        }
    }

    private bool _status;

    public bool Status
    {
        get => _status;
        set => _status = value;
    }
    
    private DateTime? _cancellationDate;

    public DateTime? CancellationDate
    {
        get => _cancellationDate;
        set
        {
            if (value != null && value > DateTime.Now)
            {
                // CancelationDate the day it was cancelled or the day they dont have it anymore?
                _cancellationDate = value;
            }
            else
            {
                throw new ArgumentException("Cancellation date cant be before today");
            }
        }
    }
    
    private Shelf _shelf;

    public Shelf Shelf
    {
        get => _shelf;
    }

    public Lease(DateTime startDate, double price, bool status, Shelf shelf, DateTime? cancellationDate = null)
    {
        _startDate = startDate;
        Price = price;
        Status = status;
        _shelf = shelf;
        if (cancellationDate != null)
        {
            CancellationDate = cancellationDate;
        }
    }
    
}