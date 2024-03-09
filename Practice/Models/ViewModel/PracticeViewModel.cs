using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice20240309.Models.ViewModel
{
    public class PracticeViewModel
    {
        public string Level { get; set; }

        [Required(ErrorMessage = "請輸入")]
        public string EmpName { get; set; }

        public List<SelectListItem> Levels { get; set; } = new List<SelectListItem>();

        public List<Employee> Datas { get; set; } = new List<Employee>();
    }
}