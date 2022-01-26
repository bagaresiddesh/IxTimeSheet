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

        [Required]
        [DisplayName("Client Name")]
        public string Client { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string Project { get; set; }

        [Required]
        [DisplayName("Job Name")]
        public string Job { get; set; }

        [Required]
        [DisplayName("Work Item")]
        public string WorkItem { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public TimeSpan Hours { get; set; }

        [Required]
        [DisplayName("Billable Status")]
        public bool BillableStatus { get; set; }
    }
}
