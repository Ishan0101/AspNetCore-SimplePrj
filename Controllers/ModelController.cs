using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.AppDbContext;
using MyShop.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    [Authorize(Roles = "Admin,Executive")]
    public class ModelController : Controller
    {
        private DataContext _db;

        [BindProperty]
        public ModelViewModel ModelVM { get; set; }

        public ModelController(DataContext db)
        {
            _db = db;
            ModelVM = new ModelViewModel()
            {
                Companies = _db.Companies.ToList(),
                Model = new MyShop.Models.Model()
            };
        }

        public IActionResult Index()
        {
            var model = _db.Models.Include(model => model.Company);
            return View(model);
        }

        public IActionResult Create()
        {
            return View(ModelVM);
        }

        [HttpPost,ActionName("Create")]
        public IActionResult CreateModel()
        {
            _db.Models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ModelVM.Model = _db.Models.Include(model => model.Company).SingleOrDefault(model => model.Id == id);
            return View(ModelVM);
        }
        [HttpPost]
        public IActionResult Edit()
        {
            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _db.Models.Remove(_db.Models.Find(id));
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
