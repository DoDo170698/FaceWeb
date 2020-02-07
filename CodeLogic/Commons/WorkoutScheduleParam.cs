using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Commons
{
    public class WorkoutScheduleParam
    {
        public int IDStudent { get; set; }
        public int IDCoach { get; set; }
        public string NameStudent { get; set; }
        public string NameCoach { get; set; }
        public int WorkoutScheduleStatus { get; set; }
        public int Day { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int IDTimeSchedule { get; set; }


    }
}