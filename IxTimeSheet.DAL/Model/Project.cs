using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IxTimeSheet.DAL.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
