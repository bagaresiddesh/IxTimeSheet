using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IxTimeSheet.DAL.Model
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public virtual ICollection<Project> Project { get; set; }
    }
}
