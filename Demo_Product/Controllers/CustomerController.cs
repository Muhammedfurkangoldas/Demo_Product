using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        JobManager jManager = new JobManager(new EfJobDal());
        public IActionResult Index()
        {
            var value = customerManager.GetCustomersListWithJob();
            return View(value);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            
            List<SelectListItem> value = (from x in jManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.JobID.ToString()
                                          }).ToList();
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer t)
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                customerManager.TInsert(t);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCustomer(int id)
        {
            var value = customerManager.TGetById(id);
            customerManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> value = (from x in jManager.TGetList()
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.JobID.ToString()
                                          }).ToList();
            ViewBag.v = value;
            var values = customerManager.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer t)
        {
            customerManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
