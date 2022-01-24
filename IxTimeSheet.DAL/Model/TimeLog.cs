using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IxTimeSheet.DAL.Model
{
    public class TimeLog
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Client Name")]
        public string Client { get; set; }

        [DisplayName("Project Name")]
        public string Project { get; set; }

        [DisplayName("Job Name")]
        public string Job { get; set; }

        [DisplayName("Work Item")]
        public string WorkItem { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public TimeSpan Hours { get; set; }

        [DisplayName("Billable Status")]
        public bool BillableStatus { get; set; }
    }
}
