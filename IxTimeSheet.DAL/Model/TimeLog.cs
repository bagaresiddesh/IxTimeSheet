using System;
using System.ComponentModel.DataAnnotations;

namespace IxTimeSheet.DAL.Model
{
    public class TimeLog
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }


        public string Client { get; set; }
        public string Project { get; set; }
        public string Job { get; set; }
        public string WorkItem { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TimeSpan Hours { get; set; }
        public bool BillableStatus { get; set; }
    }
}
