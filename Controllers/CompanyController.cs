using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyShop.AppDbContext;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    [Authorize(Roles="Admin,Executive")]
    public class CompanyController : Controller
    {
        private DataContext _db;

        public CompanyController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Companies.ToList());
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (Company company)
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _db.Companies.Remove(_db.Companies.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult Edit(int id)
        {
            Company c = _db.Companies.Find(id);
            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Company company,int id)
        {
            Company c = _db.Companies.Find(id);
            c.Name = company.Name;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
