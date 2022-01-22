using IxTimeSheet.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IxTimeSheet.Service.Interface
{
    public interface ITimeLog
    {
        public IEnumerable<TimeLog> GetAll();
        public void Create(TimeLog timelog);
        public void Update(TimeLog timelog);
        public bool Any(int Id);
        public void Delete(int Id);
    }
}
