using IxTimeSheet.DAL.Data;
using IxTimeSheet.DAL.Model;
using IxTimeSheet.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IxTimeSheet.Service.Repository
{
    public class ClientRepo : IClient
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ClientRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext= applicationDbContext;
        }

        public bool Any(int id)
        {
            if (_applicationDbContext.Clients.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public void Create(Client client)
        {
            client.CreatedDate = DateTime.Now;

            _applicationDbContext.Clients.Add(client);
            _applicationDbContext.SaveChanges();
        }

        public void Update(Client client)
        {
            Client oldData = _applicationDbContext.Clients.Where(x => x.Id == client.Id).FirstOrDefault();
            if(oldData != null)
            {
                oldData.Name = client.Name;
                oldData.UpdatedDate = DateTime.Now;
            }
            
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

        public Client GetById(int id)
        {
            return _applicationDbContext.Clients.FirstOrDefault(x => x.Id == id);
        }
    }
}
