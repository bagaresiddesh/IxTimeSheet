using IxTimeSheet.DAL.Model;
using System.Collections.Generic;

namespace IxTimeSheet.Service.Interface
{
    public interface IJob
    {
        public IEnumerable<Job> GetAll();
        public Job GetById(int id);
        public void Create(Job job);
        public void Delete(int id);
        public bool Any(int id);
    }
}
