using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    static class Model
    {
        public static void AddTeachersToDataModel(DataModel dataModel, params Teacher[] teachers)
        {
            dataModel.Teachers.AddRange(teachers);
        }
        public static void AddRoomsToDataModel(DataModel dataModel, params Room[] rooms)
        {
            dataModel.Rooms.AddRange(rooms);
        }
        public static void AddGroupsToDataModel(DataModel dataModel, params Group[] groups)
        {
            dataModel.Groups.AddRange(groups);
        }

        public static void AddIntervalToTeacher(Teacher teacher, int number, int day)
        {
            var interval = new Interval(number, day);
            teacher.AddInterval(interval);
        }
        public static void AddIntervalToRoom(Room room, int number, int day)
        {
            var interval = new Interval(number, day);
            room.AddInterval(interval);
        }
        public static void AddIntervalToGroup(Group group, int number, int day)
        {
            var interval = new Interval(number, day);
            group.AddInterval(interval);
        }
        public static void AddLessonTypeToTeacher(Teacher teacher, LessonType lessonType)
        {
            teacher.LessonTypes.Add(lessonType);
        }
        public static void AddLessonTypeToRoom(Room room, LessonType lessonType)
        {
            room.LessonTypes.Add(lessonType);
        }
        public static void AddLessonTypeToGroup(Group group, LessonType lessonType)
        {
            group.LessonTypes.Add(lessonType);
        }

        public static Lesson Assign(Room room, Teacher teacher, Group group, LessonType lessonType, Interval interval)
        {
            if (room.Intervals.Contains(interval)
                && teacher.Intervals.Contains(interval)
                && group.Intervals.Contains(interval)
                && group.LessonTypes.Contains(lessonType)
                && teacher.LessonTypes.Contains(lessonType)
                && room.LessonTypes.Contains(lessonType))
            {
                teacher.Intervals.Remove(interval);
                group.Intervals.Remove(interval);
                room.Intervals.Remove(interval);
                group.LessonTypes.RemoveAt(group.LessonTypes.IndexOf(lessonType));
                return new Lesson(lessonType, group, interval);
            }
            return null;
        }
    }
}
