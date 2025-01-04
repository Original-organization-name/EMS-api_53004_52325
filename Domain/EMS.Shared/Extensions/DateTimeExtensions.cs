using EMS.Shared.Shared;

namespace EMS.Shared.Extensions;

public static class DateTimeExtensions
{
    public static RecordStatus GetStatus(this DateTime value)
    {
        if(DateTime.Now > value)
        {
            return RecordStatus.Ended;
        }

        if(DateTime.Now.AddDays(14) >= value){
            return RecordStatus.Ending;
        }

        return RecordStatus.Ended;
    }
    
    public static RecordStatus GetStatus(this DateTime? value)
    {
        return value?.GetStatus() ?? RecordStatus.Ended;
    }
}