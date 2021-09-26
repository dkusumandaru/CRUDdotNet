using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRUDdotNet.Models;

namespace CRUDdotNet.Controllers
{
    public class productCategoryController : Controller
    {
        // GET: productCategory
        public  ActionResult index()
        {

            // var is_delete = 0;
            DemoEntities  dbModel = new DemoEntities();
            string query = "SELECT * FROM product_category WHERE is_delete = 0";
            var category = dbModel.product_category.SqlQuery(query);
            //.Include(a => a.Parent)
            //.Include(a => a.Category)
            //.ThenInclude(c => c.Parent)
            //.Include(a => a.Term)
            //.Select(a => new { a.Name, a.Parent, a.Category.Category, a.Category.Parent, a.Term.BusinessTerm, a.Term.ShortDescription });

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
            //using (DemoEntities dbModel = new DemoEntities())
            //{
            //    return View(dbModel.product_category.ToList());
            //}
            // return View();
        }

        // GET: productCategory/Details/5
        public ActionResult Details(int id)
        {
            using (DemoEntities context = new DemoEntities())
            {
                var data = context.product_category.Where(x => x.id == id).SingleOrDefault();

                //System.Diagnostics.Debug.WriteLine(data);

                return View(data);
            }
        }

        // GET: productCategory/Create
        public ActionResult Create()
        {
    
            return View(); 

        }

        // POST: productCategory/Create
        [HttpPost]
        public ActionResult Create(product_category category)
        {
            //Console.WriteLine(category);

            System.Diagnostics.Debug.WriteLine("SomeText");
            //try
            //{
                
                using (DemoEntities dbModel = new DemoEntities())
                {
                    dbModel.product_category.Add(category);
                    dbModel.SaveChanges();
                }
                string message = "Created the record successfully";

                ViewBag.Message = message;
                System.Diagnostics.Debug.WriteLine(message);
                //return View();
            //}
            //catch (Exception ex) // catches all exceptions
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //    return View(ex.Message);
            //}
            return RedirectToAction("Index");
        }

        // GET: productCategory/Edit/5
        public ActionResult Edit(int id)
        {
            using (DemoEntities context = new DemoEntities())
            {
                var data = context.product_category.Where(x => x.id == id).SingleOrDefault();
                return View(data);
            }
        }

        // POST: productCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, product_category model)
        {

            using (var context = new DemoEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.product_category.FirstOrDefault(x => x.id == id);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.name = model.name;
                    context.SaveChanges();

                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Edit");
                }
                else
                    return View();
            }

            //try
            //{
            //    // TODO: Add update logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: productCategory/Delete/5
        public ActionResult Delete(int id)
        {
            using (DemoEntities context = new DemoEntities())
            {
                var data = context.product_category.Where(x => x.id == id).SingleOrDefault();
                return View(data);
            }
        }

        // POST: productCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, product_category model)
        {
            using (var context = new DemoEntities())
            {

                // Use of lambda expression to access
                // particular record from a database
                var data = context.product_category.FirstOrDefault(x => x.id == id);

                // Checking if any such record exist 
                if (data != null)
                {
                    data.is_delete = 1;
                    context.SaveChanges();

                    // It will redirect to 
                    // the Read method
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                //return RedirectToAction("Index");
            }
        }
    }
}
