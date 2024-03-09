using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice20240309.Models.ViewModel
{
    public class PracticeViewModel
    {
        public string Level { get; set; }
        public List<SelectListItem> Levels { get; set; }
        public List<Employee> Datas { get; set; }
    }
}