using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud1.Models;

namespace MvcCrud1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Student.ToList());
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel dbModel = new DbModel()) {
                
                return View(dbModel.Student.Where(x=>x.Id==id).FirstOrDefault());

            }
           
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    dbModel.Student.Add(student);
                    dbModel.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
             using (DbModel dbModel = new DbModel())
            {

                return View(dbModel.Student.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (DbModel dbModel = new DbModel())
                {
                    dbModel.Entry(student).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbModel = new DbModel())
            {

                return View(dbModel.Student.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                // TODO: Add delete logic here
                using (DbModel dbModel = new DbModel())
                {

                    Student student = dbModel.Student.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Student.Remove(student);
                    dbModel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
