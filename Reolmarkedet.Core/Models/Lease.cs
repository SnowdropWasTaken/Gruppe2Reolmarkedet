namespace Reolmarkedet.Core.Models;

public class Lease
{
    public int Id;
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
    
    private DateTime? _cancellationDate;

    public DateTime? CancellationDate
    {
        get => _cancellationDate;
        set
        {
            // Awful nesting incoming
            if (value.HasValue)
            {
                if (value.Value.Month == DateTime.Now.Month)
                {
                    if (value.Value.Day < 20)
                    {
                        // Last day of the month
                        _cancellationDate = new DateTime(value.Value.Year, value.Value.Month,
                            DateTime.DaysInMonth(value.Value.Year, value.Value.Month));
                    }
                    else
                    {
                        // Last day of next month
                        _cancellationDate = new DateTime(value.Value.Year, value.Value.Month + 1,
                            DateTime.DaysInMonth(value.Value.Year, value.Value.Month + 1));
                    }
                }
                else
                {
                    // Last day of the set month
                    _cancellationDate = new DateTime(value.Value.Year, value.Value.Month,
                        DateTime.DaysInMonth(value.Value.Year, value.Value.Month));
                }
            }
            else
            {
                throw new ArgumentException("Cancellation date must be a date, to be set");
            }
        }
    }
    
    private Shelf _shelf;

    public Shelf Shelf
    {
        get => _shelf;
    }

    private Tenant _tenant;

    public Tenant Tenant
    {
        get => _tenant;
    }

    public Lease(DateTime startDate, double price, Shelf shelf, Tenant tenant, DateTime? cancellationDate = null)
    {
        _startDate = startDate;
        Price = price;
        _shelf = shelf;
        _tenant = tenant;
        if (cancellationDate != null)
        {
            CancellationDate = cancellationDate;
        }
    }
    
}