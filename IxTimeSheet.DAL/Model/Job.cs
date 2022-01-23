using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IxTimeSheet.DAL.Model
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Job Name")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
