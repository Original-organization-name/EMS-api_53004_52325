using EMS.Domain.Shared;

namespace EMS.Domain.Extensions;

public static class DateTimeExtensions
{
    public static Status GetStatus(this DateTime value)
    {
        if(DateTime.Now > value)
        {
            return Status.Ended;
        }

        if(DateTime.Now.AddDays(14) >= value){
            return Status.Ending;
        }

        return Status.Ended;
    }
    
    public static Status GetStatus(this DateTime? value)
    {
        return value?.GetStatus() ?? Status.Ended;
    }
}