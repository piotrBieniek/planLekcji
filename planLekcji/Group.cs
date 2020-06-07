using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Group
    {
        private readonly List<Interval> intervals = new List<Interval>();
        private readonly List<Lesson> lessons = new List<Lesson>();
        private readonly List<LessonType> lessonTypes = new List<LessonType>();
        private readonly string name;

        public string Name => name;

        internal List<LessonType> LessonTypes => lessonTypes;

        internal List<Interval> Intervals => intervals;

        internal List<Lesson> Lessons => lessons;

        public Group(string name)
        {
            this.name = name;
        }

        public void AddInterval(Interval interval)
        {
            Intervals.Add(interval);
            interval.Group = this;
        }
           
        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
            lesson.Group = this;
        }
        public Group Copy()
        {
            var group = new Group(this.name);
            group.LessonTypes.AddRange(this.LessonTypes);
            this.Intervals.ForEach(interval => group.AddInterval(interval.Copy()));
            return group;
        }
    }
}
