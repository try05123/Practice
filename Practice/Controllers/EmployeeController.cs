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
                new SelectListItem(){ Text = "Boss", Value = "0" },
                new SelectListItem(){ Text = "Student", Value = "4" }
            };

            //var selectItems = _db.Level.ToList();
            //foreach (var item in selectItems)
            //{
            //    model.DropLevels.Add(new SelectListItem() { Text = item.LevelName, Value = item.LevelId.ToString() });
            //}

            //var temp = from c in _db.Employee
            //           join o in _db.Level on c.EmpLevel equals o.LevelId
            //           select new
            //           {
            //               EmployeeId = c.EmployeeId,
            //               EmpName = c.EmpName,
            //               LevelName = o.LevelName
            //           };

            //foreach (var item in temp)
            //{
            //    model.Datas.Add(new EmployeeLevel() { EmployeeId = item.EmployeeId, EmpName = item.EmpName, LevelName = item.LevelName });
            //}

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PracticeViewModel model)
        {
            model.Levels = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Boss", Value = "0" },
                new SelectListItem(){ Text = "Student", Value = "4" }
            };

            //ModelState.AddModelError("EmpName", "上傳的檔案必須是圖片格式(jpg, jpeg, png)");

            //驗證必填
            if (ModelState.IsValid)
            {
                model.Datas = db.Employee.Where(m => m.EmpLevel.ToString() == model.Level && m.EmpName.Equals(model.EmpName)).ToList();
            }

            return View(model);
        }
    }
}