using System;
using System.Collections.Generic;
using System.Text;

namespace calendarProject
{
    public class Moon
    {
        private int _count = 1;

        public void Incriment()
        {
            if (_count == 55)
            {
                _count = -1;
            }
            else if (_count == 56)
            {
                _count = 0;
            }
            _count += 2;
        }

        internal void Set(int moonPosition)
        {
            _count = moonPosition;
        }

        public int Get()
        {
            return _count;
        }
    }
}
