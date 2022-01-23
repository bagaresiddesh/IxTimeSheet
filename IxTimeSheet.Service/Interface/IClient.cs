using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface IClient
    {
        public IEnumerable<Client> GetAll();
        public Client GetById(int id);
        public void Create(Client clinet);
        public void Delete(int id);
        public bool Any(int id);    
    }
}
