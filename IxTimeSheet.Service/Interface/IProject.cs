using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface IProject
    {
        public IEnumerable<Project> GetAll();
        public Project GetById(int id);
        public void Create(Project project);
        public void Delete(int Id);
        public void Update(Project project);
        public bool Any(int id);
        public IEnumerable<Client> GetClients();
    }
}
