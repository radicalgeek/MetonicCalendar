using System;

namespace CalendarApp.Models
{
    public interface ISunModel
    {
        int Get();
        void Incriment(DateTime gregorianDate);
        void Set(int value);
    }
}