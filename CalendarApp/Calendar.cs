using CalendarApp.Models;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp
{
    public class Calendar
    {
        public static void DrawCalendar(RenderWindow app, INodesModel nodes, ISunModel sun, IMoonModel moon, IMetonicYearModel year, IMonthModel month, IDayModel day, ISunCountModel sunCount)
        {
            ElementDrawer.CreateRing(app, 270, new Color(0, 0, 0), true);
            DrawNodeRing(app, nodes);
            DrawSunRing(app, sun);
            DrawMoonRing(app, moon);
            ElementDrawer.CreateRing(app, 210, new Color(0, 0, 0), true);
            DrawDayRing(app, day, month);
            DrawSunCountRing(app, sunCount);

            DrawMonthRing(app, month);
            DrawYearRing(app, year);
        }

        private static void DrawDayRing(RenderWindow app, IDayModel day, IMonthModel month)
        {
            var dayRing1 = ElementDrawer.CreateRing(app, 180, new Color(0, 0, 0), true);
            var day1PegPoints = ElementDrawer.CreatePegPoints(app, dayRing1, 30, (Math.PI * 2) / 30);
            Array.Reverse(day1PegPoints);
            var dayRing2 = ElementDrawer.CreateRing(app, 160, new Color(0, 0, 0), true);
            var day2PegPoints = ElementDrawer.CreatePegPoints(app, dayRing2, 29, (Math.PI * 2) / 29);
            Array.Reverse(day2PegPoints);
            if (!day.IsShortMonth() || (month.Get() == 11 || month.Get() == 10))
            {
                day1PegPoints[day.Get() - 1].FillColor = new Color(255, 0, 0);

            }
            else
            {
                day2PegPoints[day.Get() - 1].FillColor = new Color(255, 0, 0);

            }
            foreach (var p in day1PegPoints)
                app.Draw(p);
            foreach (var p in day2PegPoints)
                app.Draw(p);
        }

        private static void DrawYearRing(RenderWindow app, IMetonicYearModel year)
        {
            var yearRing = ElementDrawer.CreateRing(app, 80, new Color(0, 0, 0), true);
            var yearPegPoints = ElementDrawer.CreatePegPoints(app, yearRing, 19, (Math.PI * 2) / 19);
            Array.Reverse(yearPegPoints);
            yearPegPoints[year.GetMetonicYear() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in yearPegPoints)
                app.Draw(p);
        }

        private static void DrawMonthRing(RenderWindow app, IMonthModel month)
        {
            var monthRing = ElementDrawer.CreateRing(app, 100, new Color(255, 255, 255), false);
            monthRing.FillColor = new Color(255, 255, 0, 0);
            var monthPegPoints = ElementDrawer.CreatePegPoints(app, monthRing, 13, ((Math.PI * 2) / 13) / 2);
            Array.Reverse(monthPegPoints);
            monthPegPoints[month.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in monthPegPoints)
                app.Draw(p);
        }

        private static void DrawSunCountRing(RenderWindow app, ISunCountModel sunCount)
        {
            var sunCountRing = ElementDrawer.CreateRing(app, 130, new Color(0, 0, 0), true);
            var sunCountPegPoints = ElementDrawer.CreatePegPoints(app, sunCountRing, 13, (Math.PI * 2) / 13);
            foreach (var p in sunCountPegPoints)
                DrawMonthLine(app, p);
            Array.Reverse(sunCountPegPoints);
            sunCountPegPoints[sunCount.GetPosition() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in sunCountPegPoints)
                app.Draw(p);
        }

        private static void DrawMonthLine(RenderWindow app, CircleShape p)
        {
            var line = new Line();
            line.SetPoints(new SFML.System.Vector2f(400, 300), p.Position);
            line.Thickness = 2;
            line.Color = new Color(0, 0, 0);
            app.Draw(line);
        }

        private static void DrawMoonRing(RenderWindow app, IMoonModel moon)
        {
            var moonRing = ElementDrawer.CreateRing(app, 220, new Color(255, 255, 255), true);
            var moonPegPoints = ElementDrawer.CreatePegPoints(app, moonRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(moonPegPoints);
            moonPegPoints[moon.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in moonPegPoints)
                app.Draw(p);
        }

        private static void DrawSunRing(RenderWindow app, ISunModel sun)
        {
            var sunRing = ElementDrawer.CreateRing(app, 240, new Color(255, 255, 255), true);
            var sunPegPoints = ElementDrawer.CreatePegPoints(app, sunRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(sunPegPoints);
            sunPegPoints[sun.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in sunPegPoints)
                app.Draw(p);
        }

        private static void DrawNodeRing(RenderWindow app, INodesModel nodes)
        {
            var nodeRing = ElementDrawer.CreateRing(app, 260, new Color(255, 255, 255), true);
            var nodePegPoints = ElementDrawer.CreatePegPoints(app, nodeRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(nodePegPoints);
            nodePegPoints[nodes.GetNode1Position() - 1].FillColor = new Color(255, 0, 0);
            nodePegPoints[nodes.GetNode2Position() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in nodePegPoints)
                app.Draw(p);
        }
    }
}
