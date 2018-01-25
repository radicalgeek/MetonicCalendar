using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Models
{
    public class MonthModel : IMonthModel
    {
        private int _month;
        private IMetonicYearModel _metonicYear { get; set; }
        private readonly IMoonModel _moon;
        private readonly ISunModel _sun;

        public MonthModel(IMetonicYearModel metonicYear, ISunModel sun, IMoonModel moon)
        {
            _metonicYear = metonicYear;
            _sun = sun;
            _moon = moon;
        }

        public void Set(int month)
        {

            _month = month;
        }

        public int Get()
        {
            return _month;
        }

        public void Incriment()
        {
            
                if (_month == 13)
                {
                    _month = 0;
                    _metonicYear.IncrimentYear();
                }
            
            if(!_metonicYear.IsLeapYear() && _month == 10)
            {
                _month += 1;
            }
            _month += 1;
        }

        public void PerformMoonCorrection()
        {
            int moonPosition;
            int sunPosition = _sun.Get();
            moonPosition = sunPosition + 29;
            if (moonPosition >= 57)
            {
                moonPosition = moonPosition - 56;
            }
            _moon.Set(moonPosition);
        }

        public string GetMonthName()
        {
            string monthname = "";
            switch (_month)
            {
                case 1:
                    monthname = "cold time";
                    break;
                case 2:
                    monthname = "stay home";
                    break;
                case 3:
                    monthname = "ice time";
                    break;
                case 4:
                    monthname = "wind time";
                    break;
                case 5:
                    monthname = "shoot show";
                    break;
                case 6:
                    monthname = "bright time";
                    break;
                case 7:
                    monthname = "horse time";
                    break;
                case 8:
                    monthname = "claim time";
                    break;
                case 9:
                    monthname = "arbiration time";
                    break;
                case 10:
                    monthname = "song time";
                    break;
                case 11:
                    monthname = "song time";
                    break;
                case 12:
                    monthname = "seed fall";
                    break;
                case 13:
                    monthname = "darkest deapths";
                    break;
            }
            return monthname;
        }
    }
}
