using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IxTimeSheet.DAL.Model
{
    public class Project
    {
        public int Id { get; set; }

        [DisplayName("Project Name")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
    }
}
