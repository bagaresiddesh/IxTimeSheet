using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IxTimeSheet.Service.Repository
{
    public class ClientRepo : IClient
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ClientRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }
        public void Create(Client clinet)
        {
            _applicationDbContext.Clients.Add(clinet);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            Client Temp=_applicationDbContext.Clients.Where(x=>x.Id==Id).FirstOrDefault();

            _applicationDbContext.Clients.Remove(Temp);
            _applicationDbContext.SaveChanges();
        }

        public IEnumerable<Client> GetAll()
        {
            return _applicationDbContext.Clients.ToList();
        }
    }
}
