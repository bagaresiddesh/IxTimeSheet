using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System;
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

        public bool Any(int id)
        {
            if (_applicationDbContext.Projects.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public void Create(Project project)
        {
            project.CreatedDate = DateTime.Now;
            project.UpdatedDate = DateTime.Now;
            
            _applicationDbContext.Projects.Add(project);
            _applicationDbContext.SaveChanges();
        }

        public void Update(Project project)
        {
            Project oldData = _applicationDbContext.Projects.Where(x => x.Id == project.Id).FirstOrDefault();
            if (oldData != null)
            {
                oldData.Name = project.Name;
                oldData.CId=project.CId;    
                oldData.UpdatedDate = DateTime.Now;
            }

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

        public Project GetById(int id)
        {
            return _applicationDbContext.Projects.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _applicationDbContext.Clients.ToList();
        }
    }
}
