using SFML.Graphics;
using System;

namespace CalendarApp
{
    public class ElementDrawer
    {
        public static CircleShape GetPegPointTemplate()
        {
            var pegPoint = new CircleShape(5, 8);
            pegPoint.FillColor = new Color(0, 0, 0);
            pegPoint.Origin = new SFML.System.Vector2f(5, 5);
            return pegPoint;
        }

        public static CircleShape[] CreatePegPoints(RenderWindow app, CircleShape ring, int points, double offset = 0)
        {
            CircleShape[] pegPoints = new CircleShape[points];
            var yearPoints = points;
            for (var i = 0; i < yearPoints; i++)
            {
                float x = Convert.ToSingle(400 + ring.Radius * Math.Sin(Math.PI + offset + (2 * Math.PI * i / yearPoints)));
                float y = Convert.ToSingle(300 + ring.Radius * Math.Cos(Math.PI + offset + (2 * Math.PI * i / yearPoints)));
                var point = new CircleShape(GetPegPointTemplate());
                point.Position = new SFML.System.Vector2f(x, y);
                pegPoints[i] = point;
            }
            return pegPoints;
        }

        public static CircleShape CreateRing(RenderWindow app, int radius, Color color, bool draw)
        {
            var ring = new CircleShape(radius, 100);
            ring.OutlineThickness = 2;
            ring.Origin = new SFML.System.Vector2f(radius, radius);
            ring.Position = new SFML.System.Vector2f(400, 300);
            ring.OutlineColor = color;
            if (draw)
                app.Draw(ring);
            return ring;
        }
    }
}