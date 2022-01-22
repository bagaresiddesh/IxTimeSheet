using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace IxTimeSheet.Service.Repository
{
    public class ProjectRepo : IProject
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProjectRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext; 
        }
        public void Create(Project project)
        {
            _applicationDbContext.Projects.Add(project);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Project Temp = _applicationDbContext.Projects.Where(x => x.Id == Id).FirstOrDefault();
            
            _applicationDbContext.Remove(Temp);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Project> GetAll()
        {
            return _applicationDbContext.Projects.ToList();
        }
    }
}
