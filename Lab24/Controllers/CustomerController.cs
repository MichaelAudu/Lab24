using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab24.Models;

namespace Lab24.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            NorthwindEntities2 NorthWind = new NorthwindEntities2();
            

            return View(NorthWind.Customers);
        }
        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            NorthwindEntities2 db = new NorthwindEntities2();

            return View(db.Customers.Find(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                NorthwindEntities2 db = new NorthwindEntities2();
                Customer cr = new Customer();
                cr.CustomerID = collection["CustomerID"];
                cr.CompanyName = collection["CompanyName"];
                cr.ContactName = collection["ContactName"];
                cr.ContactTitle = collection["ContactTitle"];
                cr.Address = collection["Address"];
                cr.City = collection["City"];
                cr.Region = collection["Region"];
                cr.PostalCode = collection["PostalCode"];
                cr.Country = collection["Country"];
                cr.Phone = collection["Phone"];
                cr.Fax = collection["Fax"];
                cr.CustomerID = collection["CustomerID"];
                db.Customers.Add(cr);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            NorthwindEntities2 db = new NorthwindEntities2();

            return View(db.Customers.Find(id));
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            try
            {
                NorthwindEntities2 db = new NorthwindEntities2();
                Customer cr = db.Customers.Find(id);
                cr.CompanyName = collection["CompanyName"];
                cr.ContactName = collection["ContactName"];
                cr.ContactTitle = collection["ContactTitle"];
                cr.Address = collection["Address"];
                cr.City = collection["City"];
                cr.Region = collection["Region"];
                cr.PostalCode = collection["PostalCode"];
                cr.Country = collection["Country"];
                cr.Phone = collection["Phone"];
                cr.Fax = collection["Fax"];
                cr.CustomerID = collection["CustomerID"];
                db.SaveChanges();

                return View(db.Customers.Find(id));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            NorthwindEntities2 db = new NorthwindEntities2();
            return View(db.Customers.Find(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                NorthwindEntities2 db = new NorthwindEntities2();
                var foundCustomer = db.Customers.Find(id);
                db.Customers.Remove(foundCustomer);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
    }
}
