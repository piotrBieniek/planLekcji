using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planLekcji
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataModel = DataLoader.LoadData();
            var scheduler = new Scheduler();
            var scheduled = scheduler.TrySchedule(dataModel);
            Console.WriteLine(scheduled.Groups.First().Lessons.Count());
        }
    }
}
