using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Teacher
    {
        private readonly List<Interval> intervals = new List<Interval>();
        private readonly List<LessonType> lessonTypes = new List<LessonType>();
        private readonly string name;
        private readonly string surname;

        public Teacher(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public string Name => name;

        public string Surname => surname;

        internal List<Interval> Intervals => intervals;

        internal List<LessonType> LessonTypes => lessonTypes;

        public void AddInterval(Interval interval)
        {
            Intervals.Add(interval);
            interval.Teacher = this;
        }

        public void AddLessonType(LessonType lessonType)
        {
            LessonTypes.Add(lessonType);
        }
        public Teacher Copy()
        {
            var teacher = new Teacher(this.name, this.surname);
            teacher.LessonTypes.AddRange(this.LessonTypes);
            this.Intervals.ForEach(interval => teacher.AddInterval(interval.Copy()));
            return teacher;
        }
    }
}
