using CloudTestApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Services
{
    public interface IDataServices
    {
        public bool addData(Data data);
        public void deleteData(Data data);
        public List<Data> findAllData();
        public void editData(Data data);

    }
}
