using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class DataLoader
    {
        public static DataModel LoadData()
        {
            var dataModel = new DataModel();

            var math = new LessonType("Matematyka");
            var inf = new LessonType("Informatyka");
            var his = new LessonType("Historia filozofii tańca w pierwszej połowie Xw.");

            DataModel.lessonTypes.Add(math);
            DataModel.lessonTypes.Add(inf);
            DataModel.lessonTypes.Add(his);

            var jko = new Teacher("Jan", "Kowalski");
            var kpi = new Teacher("Krzysztof", "Pixel");
            var jwi = new Teacher("Jadwiga", "Wielka");

            Model.AddTeachersToDataModel(dataModel, jko, kpi, jwi);

            Model.AddIntervalToTeacher(jko, 1, 1);
            Model.AddIntervalToTeacher(jko, 2, 1);
            Model.AddIntervalToTeacher(jko, 4, 1);
            Model.AddIntervalToTeacher(jko, 5, 1);
            Model.AddLessonTypeToTeacher(jko, math);

            Model.AddIntervalToTeacher(kpi, 1, 1);
            Model.AddIntervalToTeacher(kpi, 2, 1);
            Model.AddLessonTypeToTeacher(kpi, inf);

            Model.AddIntervalToTeacher(jwi, 1, 1);
            Model.AddIntervalToTeacher(jwi, 2, 1);
            Model.AddIntervalToTeacher(jwi, 3, 1);
            Model.AddIntervalToTeacher(jwi, 4, 1);
            Model.AddLessonTypeToTeacher(jwi, his);

            var teachers = new List<Teacher>()
            {
                jko,
                kpi,
                jwi
            };

            var s1 = new Room("s1");
            var s2 = new Room("s2");
            var s3 = new Room("s3");

            Model.AddIntervalToRoom(s1, 1, 1);
            Model.AddIntervalToRoom(s1, 2, 1);
            Model.AddIntervalToRoom(s1, 5, 1);
            Model.AddIntervalToRoom(s1, 10, 1);

            Model.AddLessonTypeToRoom(s1, math);
            Model.AddLessonTypeToRoom(s1, inf);

            Model.AddIntervalToRoom(s2, 2, 1);
            Model.AddIntervalToRoom(s2, 3, 1);
            Model.AddIntervalToRoom(s2, 10, 1);

            Model.AddLessonTypeToRoom(s2, his);

            Model.AddIntervalToRoom(s3, 2, 1);
            Model.AddIntervalToRoom(s3, 3, 1);
            Model.AddIntervalToRoom(s3, 10, 1);

            Model.AddLessonTypeToRoom(s3, his);
            Model.AddLessonTypeToRoom(s3, math);
            Model.AddLessonTypeToRoom(s3, inf);

            Model.AddRoomsToDataModel(dataModel, s1, s2, s3);

            var rooms = new List<Room>()
            {
                s1,
                s2,
                s3
            };

            var c1A = new Group("1A");

            for(int i = 0; i < 12; i++)
            {
                Model.AddIntervalToGroup(c1A, i, 1);
            }

            Model.AddLessonTypeToGroup(c1A, math);
            Model.AddLessonTypeToGroup(c1A, inf);
            Model.AddLessonTypeToGroup(c1A, his);
            Model.AddLessonTypeToGroup(c1A, his);

            Model.AddGroupsToDataModel(dataModel, c1A);

            return dataModel;
        }
    }
}
