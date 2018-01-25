using System;
using System.Collections.Generic;
using System.Text;

namespace calendarProject
{
    public class Sun
    {
        private Nodes _nodes;
        private int _count = 1;

        public Sun(Nodes nodes)
        {
            _nodes = nodes;
        }

        public void Incriment()
        {
            if (_count == 56)
            {
                _count = 0;
            }
            _count += 1;
            if (_count == 19 || _count == 39 || _count == 1)
            {
                _nodes.Incriment();
            }
        }

        public int Get()
        {
            return _count;
        }

        public void Set(int value)
        {
             _count = value;
        }
    }
}
