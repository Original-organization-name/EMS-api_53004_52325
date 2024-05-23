namespace EMS.Data.Models;

public class TerminalDatePeriod : DatePeriod
{
    public new DateTime End
    {
        get => (DateTime)base.End!;
        set => base.End = value;
    }

    public TerminalDatePeriod(DateTime start, DateTime end) : base(start, end)
    {
    }
}