using System;
using System.Collections.Generic;
using System.Text;

namespace calendarProject
{
    public class SunCount
    {
        private Sun _sun;
        public SunCount(Sun sun)
        {
            _sun = sun;
        }
        private int _count = 1;

        public void Incriment()
        {
            
            if (_count == 13)
            {
                _count = 0;
            }
            _count += 1;

            if (_count == 7 || _count == 1)
            {
                _sun.Incriment();
            }

        }

        public int GetPosition()
        {
            return _count;
        }

        internal void Set(int value)
        {
            _count = value;
        }
    }
}
