using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class DataModel
    {
        public static readonly List<LessonType> lessonTypes = new List<LessonType>();
        private readonly List<Group> groups = new List<Group>();
        private readonly List<Room> rooms = new List<Room>();
        private readonly List<Teacher> teachers = new List<Teacher>();

        public List<Group> Groups => groups;

        public List<Room> Rooms => rooms;

        public List<Teacher> Teachers => teachers;

        public DataModel Copy()
        {
            var dataModel = new DataModel();
            dataModel.groups.AddRange(this.groups.Select(group => group.Copy()));
            dataModel.rooms.AddRange(this.rooms.Select(room => room.Copy()));
            dataModel.teachers.AddRange(this.teachers.Select(teacher => teacher.Copy()));
            return dataModel;
        }

        public IEnumerable<(Teacher, Room, Group, LessonType, Interval)> TeacherRoomGroupLessonTypeIntervalTuples()
        {
            foreach (var teacher in this.teachers)
            {
                foreach (var interval in teacher.Intervals)
                {
                    foreach (var room in this.rooms)
                    {
                        if (room.Intervals.Contains(interval))
                        {
                            foreach (var group in this.groups)
                            {
                                if (group.Intervals.Contains(interval))
                                {
                                    foreach (var type in group.LessonTypes)
                                    {
                                        yield return (teacher, room, group, type, interval);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
