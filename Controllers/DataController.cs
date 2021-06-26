using CloudTestApplication.Models;
using CloudTestApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTestApplication.Controllers
{
    public class DataController : Controller
    {
 
        public IDataServices ds;

        public DataController(IDataServices dataService)
        {
            ds = dataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateData()
        {
            return View(new Data());
        }

        public IActionResult AddData(Data data)
        {
            ds.addData(data);
            return View("AllData", ds.findAllData());
        }

        public IActionResult Delete(Data data)
        {
            ds.deleteData(data);
            System.Diagnostics.Debug.WriteLine("Removed Data: ID "+ data.ID);
            return View("AllData", ds.findAllData());
        }

        public IActionResult AllData()
        {
            //Get all data from the database;

            //But for now we will create random data
            return View(ds.findAllData());

        }



    }
}
