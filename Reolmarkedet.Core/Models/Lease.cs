namespace Reolmarkedet.Core.Models;

public class Lease
{
    public int LeaseId;
    private DateTime _startDate;
    public DateTime StartDate
    {
        get { return _startDate; }
        set { _startDate = value; }
    }
    
    private decimal _price;

    public decimal Price
    {
        get => _price;
        set
        {
            if (value > 0)
            {
                _price = value;
            }
            else
            {
                throw new ArgumentException("Price must be greater than zero");
            }
        }
    }
    
    private DateTime? _terminationDate;

    public DateTime? TerminationDate
    {
        get => _terminationDate;
        set
        {
            if (!value.HasValue)
            {
                _terminationDate = null;
                return;
            }

            var requestDate = value.Value;

            // Opsigelsesfrist den 20.: anmodes før den 20. i måneden,
            // træder opsigelsen i kraft ved udgangen af indeværende måned.
            // Anmodes den 20. eller senere, udskydes den til udgangen af næste måned.
            int monthsAhead = requestDate.Day < 20 ? 1 : 2;

            _terminationDate = new DateTime(requestDate.Year, requestDate.Month, 1)
                .AddMonths(monthsAhead)
                .AddDays(-1);
        }

            // Awful nesting incoming
            //if (value.HasValue)
            //{
            //    if (value.Value.Month == DateTime.Now.Month)
            //    {
            //        if (value.Value.Day < 20)
            //        {
            //            // Last day of the month
            //            _cancellationDate = new DateTime(value.Value.Year, value.Value.Month,
            //                DateTime.DaysInMonth(value.Value.Year, value.Value.Month));
            //        }
            //        else
            //        {
            //            // Last day of next month
            //            _cancellationDate = new DateTime(value.Value.Year, value.Value.Month + 1,
            //                DateTime.DaysInMonth(value.Value.Year, value.Value.Month + 1));
            //        }
            //    }
            //    else
            //    {
            //        // Last day of the set month
            //        _cancellationDate = new DateTime(value.Value.Year, value.Value.Month,
            //            DateTime.DaysInMonth(value.Value.Year, value.Value.Month));
            //    }
            //}
            //else
            //{
            //    throw new ArgumentException("Cancellation date must be a date, to be set");
            //}
        //}
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

    public Lease(DateTime startDate, decimal price, Shelf shelf, Tenant tenant, DateTime? terminationDate = null)
    {
        _startDate = startDate;
        Price = price;
        _shelf = shelf;
        _tenant = tenant;
        if (terminationDate != null)
        {
            TerminationDate = terminationDate;
        }
    }
    
}