using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace IxTimeSheet.Service.Repository
{
    public class TimeLogRepo : ITimeLog
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TimeLogRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public bool Any(int Id)
        {
            if(_applicationDbContext.TimeLogs.Any(x=>x.Id==Id))
            {
                return true;
            }
            return false;
        }

        public void Create(TimeLog timelog)
        {
            _applicationDbContext.TimeLogs.Add(timelog);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            TimeLog temp= _applicationDbContext.TimeLogs.Where(x=>x.Id==Id).FirstOrDefault();

            _applicationDbContext.Remove(temp);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<TimeLog> GetAll()
        {
            return _applicationDbContext.TimeLogs.ToList();
        }

        public TimeLog GetById(int id)
        { 
            return _applicationDbContext.TimeLogs.FirstOrDefault(x=>x.Id==id);
        }

        public void Update(TimeLog timelog)
        {
            _applicationDbContext.Entry(timelog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Client> GetClients()
        {
            return _applicationDbContext.Clients.ToList();
        }

        public IEnumerable<Project> GetProjects()
        {
            return _applicationDbContext.Projects.ToList(); 
        }

        public IEnumerable<Job> GetJobs()
        {
            return _applicationDbContext.Jobs.ToList();
        }
    }
}
