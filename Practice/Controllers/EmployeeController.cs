using Practice20240309.Models;
using Practice20240309.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice20240309.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly PracticeEntities db = new PracticeEntities();

        public ActionResult Index()
        {
            var model = new PracticeViewModel();

            model.Datas = db.Employee.ToList();

            model.Levels = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Boss", Value = "1" },
                new SelectListItem(){ Text = "Student", Value = "2" }
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string Level)
        {
            var model = new PracticeViewModel();

            if (ModelState.IsValid)
            {
                model.Level = Level;
                model.Datas = db.Employee.Where(m => m.EmpLevel.ToString() == model.Level).ToList();

                model.Levels = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Boss", Value = "1" },
                    new SelectListItem(){ Text = "Student", Value = "2" }
                };
            }

            return View(model);
        }
    }
}