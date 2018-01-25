using System;
using System.Threading;
using calendarProject;
using SFML;
using SFML.Graphics;
using SFML.Window; 


namespace CalendarUI
{
    class Program
    {
        private readonly RenderWindow _app;
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main(string[] args)
        {
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "Metonic Calendar");
            app.Closed += new EventHandler(OnClose);

            Nodes nodes = new Nodes();
            Sun sun = new Sun(nodes);
            Moon moon = new Moon();
            IMetonicYear year = new MetonicYear();
            IMonth month = new Month(year,sun,moon);
            Day day = new Day(month, year);
            SunCount sunCount = new SunCount(sun);

            Control controller = new Control(year, month, day, moon, sunCount, nodes, sun);
            controller.SetYearZero();

            Color windowColor = new Color(255,255, 255);

            while (app.IsOpen)
            {
                app.DispatchEvents();
                app.Clear(windowColor);

                DrawCalendar(app, nodes, sun, moon, year, month, day, sunCount);

                app.Display();
                controller.AddDay();
                Thread.Sleep(1000);


            }
        }

        private static void DrawCalendar(RenderWindow app, Nodes nodes, Sun sun, Moon moon, IMetonicYear year, IMonth month, Day day, SunCount sunCount)
        {
            CreateRing(app, 270, new Color(0, 0, 0), true);
            DrawNodeRing(app, nodes);
            DrawSunRing(app, sun);
            DrawMoonRing(app, moon);
            CreateRing(app, 210, new Color(0, 0, 0), true);
            DrawDayRing(app, day);
            DrawSunCountRing(app, sunCount);

            DrawMonthRing(app, month);
            DrawYearRing(app, year);
        }

        private static void DrawDayRing(RenderWindow app, Day day)
        {
            var dayRing1 = CreateRing(app, 180, new Color(0, 0, 0), true);
            var day1PegPoints = CreatePegPoints(app, dayRing1, 30, (Math.PI * 2) / 30);
            Array.Reverse(day1PegPoints);
            var dayRing2 = CreateRing(app, 160, new Color(0, 0, 0), true);
            var day2PegPoints = CreatePegPoints(app, dayRing2, 29, (Math.PI * 2) / 29);
            Array.Reverse(day2PegPoints);
            if (!day._shortMonth)
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

        private static void DrawYearRing(RenderWindow app, IMetonicYear year)
        {
            var yearRing = CreateRing(app, 80, new Color(0, 0, 0), true);
            var yearPegPoints = CreatePegPoints(app, yearRing, 19, (Math.PI * 2) / 19);
            Array.Reverse(yearPegPoints);
            yearPegPoints[year.GetMetonicYear() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in yearPegPoints)
                app.Draw(p);
        }

        private static void DrawMonthRing(RenderWindow app, IMonth month)
        {
            var monthRing = CreateRing(app, 100, new Color(255, 255, 255), false);
            monthRing.FillColor = new Color(255,255,0,0);
            var monthPegPoints = CreatePegPoints(app, monthRing, 13, ((Math.PI * 2) / 13) / 2);
            Array.Reverse(monthPegPoints);
            monthPegPoints[month.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in monthPegPoints)
                app.Draw(p);
        }

        private static void DrawSunCountRing(RenderWindow app, SunCount sunCount)
        {
            var sunCountRing = CreateRing(app, 130, new Color(0, 0, 0), true);
            var sunCountPegPoints = CreatePegPoints(app, sunCountRing, 13, (Math.PI * 2) / 13);
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
            line.SetPoints(new SFML.System.Vector2f(400, 300),p.Position);
            line.Thickness = 2;
            line.Color = new Color(0, 0, 0);
            app.Draw(line);
        }

        private static void DrawMoonRing(RenderWindow app, Moon moon)
        {
            var moonRing = CreateRing(app, 220, new Color(255, 255, 255), true);
            var moonPegPoints = CreatePegPoints(app, moonRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(moonPegPoints);
            moonPegPoints[moon.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in moonPegPoints)
                app.Draw(p);
        }

        private static void DrawSunRing(RenderWindow app, Sun sun)
        {
            var sunRing = CreateRing(app, 240, new Color(255, 255, 255), true);
            var sunPegPoints = CreatePegPoints(app, sunRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(sunPegPoints);
            sunPegPoints[sun.Get() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in sunPegPoints)
                app.Draw(p);
        }

        private static void DrawNodeRing(RenderWindow app, Nodes nodes)
        {
            var nodeRing = CreateRing(app, 260, new Color(255, 255, 255), true);
            var nodePegPoints = CreatePegPoints(app, nodeRing, 56, (Math.PI * 2) / 56);
            Array.Reverse(nodePegPoints);
            nodePegPoints[nodes.GetNode1Position() - 1].FillColor = new Color(255, 0, 0);
            nodePegPoints[nodes.GetNode2Position() - 1].FillColor = new Color(255, 0, 0);
            foreach (var p in nodePegPoints)
                app.Draw(p);
        }

        private static CircleShape GetPegPointTemplate()
        {
            var pegPoint = new CircleShape(5, 8);
            pegPoint.FillColor = new Color(0, 0, 0);
            pegPoint.Origin = new SFML.System.Vector2f(5, 5);
            return pegPoint;
        }

        private static CircleShape[] CreatePegPoints(RenderWindow app, CircleShape ring, int points, double offset = 0)
        {
            CircleShape[] pegPoints = new CircleShape[points];
            var yearPoints = points;
            for (var i = 0; i < yearPoints; i++)
            {
                float x = Convert.ToSingle(400 + ring.Radius * Math.Sin(Math.PI + offset + (2 * Math.PI * i / yearPoints)));
                float y = Convert.ToSingle(300 + ring.Radius * Math.Cos(Math.PI + offset + (2 * Math.PI * i / yearPoints)));
                var point = new CircleShape(GetPegPointTemplate());
                point.Position = new SFML.System.Vector2f(x, y);
                //app.Draw(point);
                pegPoints[i] = point;
            }
            return pegPoints;
        }

        private static CircleShape CreateRing(RenderWindow app, int radius, Color color, bool draw)
        {
            var ring = new CircleShape(radius, 100);
            ring.OutlineThickness = 2;
            ring.Origin = new SFML.System.Vector2f(radius, radius);
            ring.Position = new SFML.System.Vector2f(400, 300);
            ring.OutlineColor = color;
            if(draw)
                app.Draw(ring);
            return ring;
        }
    }
}
