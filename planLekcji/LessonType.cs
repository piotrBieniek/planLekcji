using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class LessonType
    {
        private readonly List<Lesson> lessons = new List<Lesson>();
        private readonly List<Teacher> teachers = new List<Teacher>();
        private readonly List<Room> rooms = new List<Room>();
        private readonly string name;

        public LessonType(string name)
        {
            this.name = name;
        }

        internal List<Lesson> Lessons => lessons;
        
        internal List<Teacher> Teachers => teachers;

        internal List<Room> Rooms => rooms;

        public string Name => name;

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void AddRoom(Room room)
        {
            rooms.Add(room);
        }
    }
}
