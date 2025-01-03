namespace EMS.Domain.Models;

public class DatePeriod
{
    private DateTime? _end;
    public DateTime Start { get; set; }

    public DateTime? End
    {
        get => _end;
        set
        {
            if (value != null & value < Start)
            {
                throw new ArgumentOutOfRangeException("End date cannot be less than start date.");
            }
            _end = value;
        }
    }

    public DatePeriod(DateTime start)
    {
        Start = start;
    }
    
    public DatePeriod(DateTime start, DateTime? end)
    {
        Start = start;
        End = end;
    }
}