using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Lesson
    {
        private readonly LessonType type;
        private Group group;
        private readonly Interval interval;

        public Lesson(LessonType type, Group group, Interval interval)
        {
            this.type = type;
            type.AddLesson(this);
            this.group = group;
            group.AddLesson(this);
            this.interval = interval;
            interval.Lesson = this;
        }   

        internal LessonType Type => type;

        internal Group Group { get => group; set => group = value; }

        internal Interval Interval => interval;
    }
}
