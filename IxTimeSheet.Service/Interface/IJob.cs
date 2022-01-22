using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface IJob
    {
        public IEnumerable<Job> GetAll();
        public void Create(Job job);
        public void Delete(int Id);
    }
}
