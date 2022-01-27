using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IxTimeSheet.DAL.Model
{
    public class Project
    {
        public int Id { get; set; }
        public int CId { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("CId")]
        public virtual Client Client { get; set; }
    }
}
