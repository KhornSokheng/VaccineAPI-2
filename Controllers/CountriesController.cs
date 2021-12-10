using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VaccineAPI2.Data;
using VaccineAPI2.Models;

namespace VaccineAPI2.Controllers
{
    public class CountriesController : Controller
    {
        private VaccineAPI2Context db = new VaccineAPI2Context();

        // GET: Countries
        public ActionResult Index(string continentName, string countryName)
        {
            //var countries = db.Countries.Include(c => c.Continent);
            //return View(countries.ToList());

            var ContinentList = new List<string>();
            var ContinentQry = from d in db.Continents
                               orderby d.ContinentName
                               select d.ContinentName;
            ContinentList.AddRange(ContinentQry.Distinct());
            ViewBag.continentName = new SelectList(ContinentList);

            var continentId = from d in db.Continents
                              where d.ContinentName == continentName
                            select d.ContinentID;


            var countries = from m in db.Countries.Include(v => v.Continent)
                              select m;
            if (!String.IsNullOrEmpty(countryName))
            {
                countries = countries.Where(s => s.CountryName.Contains(countryName));
            }
            if (!string.IsNullOrEmpty(continentName))
            {
                // vaccination = vaccination.Where(x => x.VaccineID == vaccineId);
                countries = countries.Where(x => x.Continent.ContinentName.Contains(continentName));
            }

            return View(countries);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            ViewBag.ContinentID = new SelectList(db.Continents, "ContinentID", "ContinentName");
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryID,CountryName,Population,ContinentID")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContinentID = new SelectList(db.Continents, "ContinentID", "ContinentName", country.ContinentID);
            return View(country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContinentID = new SelectList(db.Continents, "ContinentID", "ContinentName", country.ContinentID);
            return View(country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryID,CountryName,Population,ContinentID")] Country country)
        {
            if (ModelState.IsValid)
            {
                db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContinentID = new SelectList(db.Continents, "ContinentID", "ContinentName", country.ContinentID);
            return View(country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
