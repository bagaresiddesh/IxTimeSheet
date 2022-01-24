using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IxTimeSheet.DAL.Model
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        public int PId { get; set; }

        [DisplayName("Job Name")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("PId")]
        public virtual Client Client { get; set; }
    }
}
