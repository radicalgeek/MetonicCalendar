using System;

namespace CalendarApp.Models
{
    public interface ISunCountModel
    {
        int GetPosition();
        void Incriment(DateTime gregorianDate);
        void Set(int value);
    }
}