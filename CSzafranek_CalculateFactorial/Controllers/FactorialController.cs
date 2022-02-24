using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSzafranek_CalculateFactorial.Models;
using System.Data.Entity;

namespace CSzafranek_CalculateFactorial.Controllers
{
    public class FactorialController : Controller
    {

        private CalculateFactorialDbContext context = new CalculateFactorialDbContext();
        // GET: Factorial
        public ActionResult Index()
        {
            List<CalculateFactorial> calculate = context.CalculateFactorials.ToList();
            return View(calculate);
        }
        [HttpGet]
        public ActionResult Factorials()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Factorials(CalculateFactorial quote)
        {
            if (ModelState.IsValid)
            {
                quote.CalculateUserFactorial();
                quote.CreatedAt = DateTime.Now;

                context.CalculateFactorials.Add(quote);
                context.SaveChanges();

                return View("Details", quote);
            }
            return View(quote);
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CalculateFactorial calculateFactorial = context.CalculateFactorials.Find(id);

            if (calculateFactorial == null)
            {

                return HttpNotFound();

            }
            return View(calculateFactorial);
        }
        [HttpPost]
        public ActionResult Edit(CalculateFactorial calculateFactorial)
        {
            if (ModelState.IsValid)
            {
                context.Entry(calculateFactorial).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CalculateFactorial calculateFactorial = context.CalculateFactorials.Find(id);

            if (calculateFactorial == null)
            {

                return HttpNotFound();

            }
            return View(calculateFactorial);

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CalculateFactorial calculateFactorial = context.CalculateFactorials.Find(id);

            if (calculateFactorial == null)
            {

                return HttpNotFound();

            }

            context.CalculateFactorials.Remove(calculateFactorial);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}