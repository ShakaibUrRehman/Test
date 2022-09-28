using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shakaib_UR_Rehman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shakaib_UR_Rehman.Controllers
{
    public class InformationClass : Controller
    {
        private readonly ContextClass cc;
        public InformationClass (ContextClass dd)
        {
            cc = dd;
        }
        public ActionResult Index(string searchBy, string search)
        {

            if(searchBy=="empl_name")
            {
                var data = cc.empl.Where(gg => gg.empl_name==search).ToList();
                return View(data); 
            } 
            else if (searchBy=="city")
            {
                var data = cc.empl.Where(gg => gg.city == search).ToList();
                return View(data);
            }
            else
            {
                var data = cc.empl.ToList();
                return View(data);
            }
            
            //return View (data);
        }
        [HttpGet] 
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(dataClass ec)
        {
            if (ModelState.IsValid)
            {
                cc.empl.Add(ec);
                    cc.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction("index"); 
        }
        public IActionResult Edit (int id)
        {
            ViewBag.dataclass = cc.empl.ToList();
            dataClass model = cc.empl.Where(p => p.ID == id).FirstOrDefault();
            return View("Edit", model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit (dataClass ss)
        {
            if (ModelState.IsValid)
            {
                cc.empl.Update(ss);
                cc.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.empl = cc.empl.ToList();
            return View("Edit", ss);
        }
        //[HttpGet]
        //public IActionResult delete(int id)
        //{
        //    return View("delete");
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult delete (int id)
        //{
        //    var student = cc.empl.Find(id);
        //    cc.empl.Remove(student);
        //    if
        //      {
        //        (student!=0)
              
        //            return RedirectToAction("index"); 
        //        }
        //    }
        //    cc.SaveChanges();
        //    return RedirectToAction("Index");
        //}
      
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ww = cc.empl.Where(temp => temp.ID == id).FirstOrDefault();
            return View(ww);
        }
        [HttpPost]
        public IActionResult delete(dataClass d)
        {
            cc.Entry(d).State = EntityState.Deleted;
            int a = cc.SaveChanges();
            //if(a>0)
            //{
            //    TempData["deletemessage"] = "<script> alert('data deleted !!')</script";
            //}
            //else
            //{
            //    TempData["deletedmessage"] = "<script>alert('data not deleted !!)</script";
            //}
            return RedirectToAction("Index");
        }
    }
}
