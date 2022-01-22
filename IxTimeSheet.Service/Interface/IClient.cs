using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface IClient
    {
        public IEnumerable<Client> GetAll();
        public void Create(Client clinet);
        public void Delete(int Id);
    }
}
