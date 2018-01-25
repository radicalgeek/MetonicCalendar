using System;
using System.Collections.Generic;
using System.Text;

namespace calendarProject
{
    public class Control
    {
        private readonly IMetonicYear _year;
        private readonly IMonth _month;
        private readonly Day _day;
        private readonly Moon _moon;
        private readonly Sun _sun;
        private readonly SunCount _sunCount;
        private readonly Nodes _nodes;
        private DateTime _gregorianDate; 

        public Control(IMetonicYear year, IMonth month, Day day, Moon moon, SunCount sunCount, Nodes nodes, Sun sun)
        {
            _year = year;
            _month = month;
            _day = day;
            _moon = moon;
            _sunCount = sunCount;
            _nodes = nodes;
            _sun = sun;
        }

        public void AddDay()
        {
            _day.Incriment();
            _moon.Incriment();
            _sunCount.Incriment();
            
        }

        public void AddDays(int daysToAdd)
        {
            for (int i = 1; i <= daysToAdd; i++)
            {
                AddDay();
            }
        }

        public void SetYearZero()
        {
            _day.Set(1);
            _day.SetLongMonth();
            _month.Set(1);
            _year.SetMetonicYear(5);
            _moon.Set(1);
            _sunCount.Set(1);
            _sun.Set(1);
            _nodes.SetNode1Position(1);
            _nodes.SetNode2Position(29);
            _gregorianDate = new DateTime(1998, 12, 18);
        }

        private string GetMetonicDate()
        {
            string date = _day.Get() + " " + _month.GetMonthName() + ", year " + _year.GetMetonicYear();
            return date;
        }

        public string GetMetonicDate(DateTime date)
        {
            SetYearZero();
            TimeSpan diff = date - _gregorianDate;
            AddDays(diff.Days);
            return GetMetonicDate();
        }
    }
}
