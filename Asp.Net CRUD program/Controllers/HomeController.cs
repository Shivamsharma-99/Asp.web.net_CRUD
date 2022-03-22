using Asp.Net_CRUD_program.DAta_base;
using Asp.Net_CRUD_program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_CRUD_program.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DB1Entities obj = new DB1Entities();
            List<ModelClass> mobj = new List<ModelClass>();
            var x = obj.mytables.ToList();
            foreach (var item in x)
            {
                mobj.Add(new ModelClass
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Department = item.Department,
                    Company = item.Company,
                });
            }
            return View(mobj);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(ModelClass Mobj)
        {
            DB1Entities obj = new DB1Entities();
            mytable tbl = new mytable();
            tbl.Id = Mobj.Id;
            tbl.Name = Mobj.Name;
            tbl.Mobile = Mobj.Mobile;
            tbl.Email = Mobj.Email;
            tbl.Company = Mobj.Company;
            tbl.Department = Mobj.Department;
            if (Mobj.Id == 0)
            {
                obj.mytables.Add(tbl);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(tbl).State = System.Data.Entity.EntityState.Modified;
                obj.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        } 
        public ActionResult Edit(int Id)
        {
            DB1Entities obj = new DB1Entities();
            ModelClass Mobj = new ModelClass();
            var Eitem = obj.mytables.Where(m => m.Id == Id).First();
            Mobj.Id = Eitem.Id;
            Mobj.Name = Eitem.Name;
            Mobj.Email = Eitem.Email;
            Mobj.Mobile = Eitem.Mobile;
            Mobj.Company = Eitem.Company;
            Mobj.Department = Eitem.Department;
            ViewBag.Id = Eitem.Id;
            return View("AddEmployee", Mobj);
        }
        public ActionResult Delete(int Id)
        {
            DB1Entities obj = new DB1Entities();
            var del = obj.mytables.Where(m => m.Id == Id).First();
            obj.mytables.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}