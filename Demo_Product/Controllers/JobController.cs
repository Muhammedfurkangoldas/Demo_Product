using BusinessLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager jobManager = new JobManager(new EfJobDal()); 
        public IActionResult Index()
        {
            var values = jobManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job t)
        {
            jobManager.TInsert(t);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteJob(int id)
        {
            var values = jobManager.TGetById(id);
            jobManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var value = jobManager.TGetById(id);
            return View(value);

        }
        [HttpPost]
        public IActionResult UpdateJob(Job t)
        {
            jobManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
