using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Scheduler
    {
        private static Random random = new Random();

        public DataModel TrySchedule(DataModel dataModel)
        {
            var dataModelCopy = dataModel.Copy();
            var same = false;
            while (IsPossible(dataModelCopy) && !same)
            {
                same = true;
                if (IsReady(dataModelCopy))
                {
                    return dataModelCopy;
                }
                OrderDataModel(dataModelCopy);

                foreach (var (teacher, room, group, type, interval) in dataModelCopy.TeacherRoomGroupLessonTypeIntervalTuples())
                {
                    var lesson = Model.Assign(room, teacher, group, type, interval);
                    if(!(lesson is null))
                    {
                        same = false;
                        break;
                    }
                }
            }
            return dataModelCopy;
        }
        private bool IsPossible(DataModel dataModel)
        {
            Dictionary<LessonType, int> teachersIntervalsAvailable = new Dictionary<LessonType, int>();
            Dictionary<LessonType, int> roomsIntervalsAvailable = new Dictionary<LessonType, int>();
            Dictionary<LessonType, int> groupsLessonsNeeded = new Dictionary<LessonType, int>();
            DataModel
                .lessonTypes
                .ForEach(type => teachersIntervalsAvailable
                                    .Add(type, dataModel
                                        .Teachers
                                        .FindAll(teacher => teacher.LessonTypes.Contains(type))
                                        .Select(teacher => teacher.Intervals.Count)
                                        .Sum())
                                    );
            DataModel
                .lessonTypes
                .ForEach(type => roomsIntervalsAvailable
                                    .Add(type, dataModel
                                        .Rooms
                                        .FindAll(room => room.LessonTypes.Contains(type))
                                        .Select(room => room.Intervals.Count)
                                        .Sum())
                                    );
            DataModel
                .lessonTypes
                .ForEach(type => groupsLessonsNeeded
                                    .Add(type, dataModel
                                        .Groups
                                        .Select(group => group
                                            .LessonTypes
                                            .Where(lessonType => lessonType == type)
                                            .Count())
                                        .Sum())
                                    );
            return DataModel
                .lessonTypes
                .All(type => 
                        groupsLessonsNeeded[type] <= roomsIntervalsAvailable[type] 
                        && groupsLessonsNeeded[type] <= teachersIntervalsAvailable[type]
                    );
        }

        private bool IsReady(DataModel dataModel)
        {
            return dataModel.Groups.Select(group => group.LessonTypes.Count).Sum() == 0;
        }

        private DataModel OrderDataModel(DataModel dataModel)
        {
            Dictionary<LessonType, double> coeffs = new Dictionary<LessonType, double>();
            DataModel.lessonTypes.ForEach(type =>
                {
                    var a = (double)dataModel
                                .Teachers
                                .Select(teacher => teacher.Intervals.Count)
                                .Sum();
                    var b = dataModel
                                .Groups
                                .Select(group => group.LessonTypes.FindAll(lessonType => lessonType == type).Count)
                                .Sum();
                    coeffs.Add(type, b / a);
                });
            Dictionary<Teacher, double> teacherCoeffs = new Dictionary<Teacher, double>();
            dataModel.Teachers.ForEach(teacher =>
                {
                    var coeff = 1.0 / teacher.LessonTypes.Select(type => coeffs[type]).Sum();
                    teacherCoeffs.Add(teacher, coeff);
                });
            Dictionary<Room, double> roomCoeffs = new Dictionary<Room, double>();
            dataModel.Rooms.ForEach(room =>
                {
                    var coeff = 1.0 / room.LessonTypes.Select(type => coeffs[type]).Sum();
                    roomCoeffs.Add(room, coeff);
                });
            dataModel
                .Teachers
                .OrderBy(teacher => teacher.Intervals.Count * teacherCoeffs[teacher] + random.NextDouble() * 2.0);
            dataModel
                .Rooms
                .OrderBy(room => room.Intervals.Count * roomCoeffs[room] + random.NextDouble() * 2.0);
            dataModel
                .Groups
                .OrderBy(group => group.LessonTypes.Count + random.NextDouble() * 2.0);
            return dataModel;
        }
    }
}
