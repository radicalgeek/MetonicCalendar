using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public interface IMonthModel
    {
        int Get();
        void Incriment();
        void Set(int month);
        string GetMonthName();

        void PerformMoonCorrection();
    }
}
