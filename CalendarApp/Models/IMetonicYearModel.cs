using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public interface IMetonicYearModel
    {
        int GetMetonicYear();
        void IncrimentYear();
        bool IsLeapYear();
        void SetMetonicYear(int yeartoSet);
    }
}
