using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Product.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index()
        {
            var value = categoryManager.TGetList();
            return View(value);
        }

        [HttpGet]

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category t)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                categoryManager.TInsert(t);
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
        public IActionResult DeleteCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            categoryManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult UpdateCategory(int id)
        {
            var value = categoryManager.TGetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult UpdateCategory(Category t)
        {
            categoryManager.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}
