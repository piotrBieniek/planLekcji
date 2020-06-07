using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Interval
    {
        private Teacher teacher;
        private Group group;
        private Room room;
        private Lesson lesson;
        private readonly int number;
        private readonly int day;

        public Teacher Teacher { get => teacher; set => teacher = value; }
        public Group Group { get => group; set => group = value; }
        public Room Room { get => room; set => room = value; }
        public Lesson Lesson { get => lesson; set => lesson = value; }
        public Interval(int number, int day)
        {
            this.number = number;
            this.day = day;
        }

        public int Number => number;

        public int Day => day;

        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case Interval interval:
                    return this.day == interval.day && this.number == interval.number;
            }
            return false;
        }
        public Interval Copy() => new Interval(this.Number, this.Day);
    }
}
