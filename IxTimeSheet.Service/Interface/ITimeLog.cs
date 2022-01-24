using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface ITimeLog
    {
        public IEnumerable<TimeLog> GetAll();
        public IEnumerable<Client> GetClients();
        public IEnumerable<Project> GetProjects();
        public IEnumerable<Job> GetJobs();
        public TimeLog GetById(int id);
        public void Create(TimeLog timelog);
        public void Update(TimeLog timelog);
        public bool Any(int id);
        public void Delete(int id);
    }
}
