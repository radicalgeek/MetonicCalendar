using calendarProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace calendarTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetMetonicYear()
        {
            int yearToExpect = 2;
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(yearToExpect);
            int metonicYear = calendar.GetMetonicYear();

            Assert.AreEqual(yearToExpect, metonicYear);
        }

        [TestMethod]
        public void SetMetonicYear()
        {
            var yeartoSet = 3;
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(yeartoSet);
            int metonicYear = calendar.GetMetonicYear();
            Assert.AreEqual(metonicYear, yeartoSet);
        }

        [TestMethod]
        public void IncrimentMetonicYear()
        {
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(1);
            calendar.IncrimentYear();
            var metonicYear = calendar.GetMetonicYear();
            Assert.AreEqual(2, metonicYear);
        }

        [TestMethod]
        public void IncrimentPast19Returns1()
        {
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(19);
            calendar.IncrimentYear();
            var metonicYear = calendar.GetMetonicYear();
            Assert.AreEqual(1, metonicYear);
        }

        [TestMethod]
        public void IsYear1LeapYear()
        {
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(1);
            var isLeapYear = calendar.IsLeapYear();
            Assert.AreEqual(false, isLeapYear);
        }

        [TestMethod]
        public void IsYear19LeapYear()
        {
            var calendar = new MetonicYear();
            calendar.SetMetonicYear(19);
            var isLeapYear = calendar.IsLeapYear();
            Assert.AreEqual(true, isLeapYear);
        }

        [TestMethod]
        public void SetMonth()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(1);
            var currentMonth = month.Get();
            Assert.AreEqual(1, currentMonth);
        }

        [TestMethod]
        public void IncrimentMonthNonLeapYearWontAccepts13()
        {
            var year = new MetonicYear();
            year.SetMetonicYear(1);
            var month = new Month(year);
            month.Set(12);
            month.Incriment();
            var currentMonth = month.Get();
            Assert.AreEqual(1, currentMonth);
        }

        [TestMethod]
        public void IncrimentMonthLeapYearAccepts13()
        {
            var year = new MetonicYear();
            year.SetMetonicYear(3);
            var month = new Month(year);
            month.Set(12);
            month.Incriment();
            var currentMonth = month.Get();
            Assert.AreEqual(13, currentMonth);
        }

        [TestMethod]
        public void IncrimentMonthLeapYearWontAccept14()
        {
            var year = new MetonicYear();
            year.SetMetonicYear(3);
            var month = new Month(year);
            month.Set(13);
            month.Incriment();
            var currentMonth = month.Get();
            Assert.AreEqual(1, currentMonth);
        }

        [TestMethod]
        public void setDay()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.Set(1);
            var currentDay = day.Get();
            Assert.AreEqual(1, currentDay);
        }

        [TestMethod]
        public void IncrimentDayTo30ShortMonthSets1()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetShortMonth();
            day.Set(29);
            day.Incriment();
            var currentDay = day.Get();
            Assert.AreEqual(1, currentDay);
        }

        [TestMethod]
        public void IncrimentDayTo30LongMonthSets30()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetLongMonth();
            day.Set(29);
            day.Incriment();
            var currentDay = day.Get();
            Assert.AreEqual(30, currentDay);
        }

        [TestMethod]
        public void IncrimentDayTo1InShortMonthIncrimentsMonth()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetShortMonth();
            day.Set(29);
            day.Incriment();
            var currentMonth = month.Get();
            Assert.AreEqual(4, currentMonth);
        }

        [TestMethod]
        public void IncrimentDayTo1InLongMonthIncrimentsMonth()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetLongMonth();
            day.Set(30);
            day.Incriment();
            var currentMonth = month.Get();
            Assert.AreEqual(4, currentMonth);
        }

        [TestMethod]
        public void IncrimentDayTo1InLongMonthSetsShortMonth()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetLongMonth();
            day.Set(30);
            day.Incriment();
            var isShortMonth = day._shortMonth;
            Assert.AreEqual(true, isShortMonth);
        }

        [TestMethod]
        public void IncrimentDayTo1InShortMonthSetsLongMonth()
        {
            var year = new MetonicYear();
            var month = new Month(year);
            month.Set(3);
            var day = new Day(month, year);
            day.SetShortMonth();
            day.Set(29);
            day.Incriment();
            var isShortMonth = day._shortMonth;
            Assert.AreEqual(false, isShortMonth);
        }

        [TestMethod]
        public void IncrimentMonthTo1UpdatesYearInLeapYear()
        {
            var year = new MetonicYear();
            year.SetMetonicYear(3);
            var month = new Month(year);
            month.Set(13);
            month.Incriment();
            Assert.AreEqual(4, year.GetMetonicYear());
        }

        [TestMethod]
        public void IncrimentMonthTo1UpdatesYearInNonLeapYear()
        {
            var year = new MetonicYear();
            year.SetMetonicYear(2);
            var month = new Month(year);
            month.Set(12);
            month.Incriment();
            Assert.AreEqual(3, year.GetMetonicYear());
        }

        [TestMethod]
        public void TestDate()
        {
            IMetonicYear year = new MetonicYear();
            IMonth month = new Month(year);
            Day day = new Day(month, year);
            var date = new DateTime(2018, 1, 19);
            Control cal = new Control(year, month, day);
            var metonicDate = cal.GetMetonicDate(date);
            Assert.AreEqual("4 stay home, year 5", metonicDate);
        }


        [TestMethod]
        public void TestDate2()
        {

            var date = new DateTime(2017, 12, 16);
            var date2 = date.AddDays(-6940);
            TimeSpan diff = date - date2;





        }

    }
}
