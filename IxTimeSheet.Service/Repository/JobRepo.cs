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

        public bool Any(int id)
        {
            if(_applicationDbContext.Jobs.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public void Create(Job job)
        {
            job.CreatedDate = DateTime.Now;

            _applicationDbContext.Jobs.Add(job);
            _applicationDbContext.SaveChanges();
        }

        public void Update(Job job)
        {
            Job oldData = _applicationDbContext.Jobs.Where(x => x.Id == job.Id).FirstOrDefault();
            if (oldData != null)
            {
                oldData.Name = job.Name;
                oldData.PId = job.PId;
                oldData.UpdatedDate = DateTime.Now;
            }

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

        public IEnumerable<Project> GetProjects()
        {
            return _applicationDbContext.Projects.ToList();
        }

        public Job GetById(int id)
        {
            return _applicationDbContext.Jobs.FirstOrDefault(x => x.Id == id);
        }
    }
}
