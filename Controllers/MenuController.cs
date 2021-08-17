using Microsoft.AspNetCore.Mvc;
using Show__table.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Show__table.Controllers
{
    public class MenuController : Controller
    {
        MenuDBContext menuDB = new MenuDBContext();
        
        public IActionResult Index()
        {
            var ps = from p in menuDB.GroupMenusTbls select p;
            //query ข้อมูลจาก Table GroupMenusTbls มาเก็บไว้ในตัวแปล p แล้วไปเก็บไว้ในตัวแปร ps อีกที
            return View(ps);//นำข้อมูลไปแสดงผล
        }
    }
}
