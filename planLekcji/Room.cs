using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Room
    {
        private readonly List<Interval> intervals = new List<Interval>();
        private readonly List<LessonType> lessonTypes = new List<LessonType>();
        private readonly string name;

        public Room(string name)
        {
            this.name = name;
        }

        public string Name => name;

        internal List<Interval> Intervals => intervals;

        internal List<LessonType> LessonTypes => lessonTypes;

        public void AddInterval(Interval interval)
        {
            intervals.Add(interval);
            interval.Room = this;
        }

        public void AddLessonType(LessonType lessonType)
        {
            LessonTypes.Add(lessonType);
        }
        public Room Copy()
        {
            var room = new Room(this.name);
            room.LessonTypes.AddRange(this.LessonTypes);
            this.Intervals.ForEach(interval => room.AddInterval(interval.Copy()));
            return room;
        }
    }
}
