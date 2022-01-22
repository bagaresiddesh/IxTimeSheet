using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IxTimeSheet.Service.Repository
{
    public class JobRepo : IJob
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public JobRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public void Create(Job job)
        {
            _applicationDbContext.Jobs.Add(job);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Job Temp = _applicationDbContext.Jobs.Where(x=>x.Id==Id).FirstOrDefault();
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Job> GetAll()
        {
            return _applicationDbContext.Jobs.ToList();
        }
    }
}
