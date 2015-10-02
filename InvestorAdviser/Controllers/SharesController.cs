using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InvestorAdviser.Models;

namespace InvestorAdviser.Controllers
{
    public class SharesController : Controller
    {
        private DbContextShares db = new DbContextShares();

        // GET: Shares
        public ActionResult Index()
        {
            return View(db.Shares.ToList());
        }

        // GET: Shares
        public ActionResult IndexViewModel()
        {

            var dbSharesEagerLoadingPurchases = db.Shares.Include(p => p.Purchases);
            List<ShareViewModel> listShareViewModel = new List<ShareViewModel>();
            foreach (Share aShare in dbSharesEagerLoadingPurchases)
                listShareViewModel.Add(ShareModelsMapper.convertTo(aShare));
            return View(listShareViewModel);
        }

        // GET: Shares
        public ActionResult IndexFilterPurchased()
        {
            //List<Share> listShares = new List<Share>();
            //foreach (Share aShare in db.Shares)
            //{
            //    if (aShare.Purchases!=null)
            //    {
            //        if (aShare.Purchases.Count > 0)
            //            listShares.Add(aShare);
            //    }
            //}
            //return View("Index", listShares);

            var items = from item in db.Shares
                        where item.Purchases.Count > 0
                        select item;
            return View("Index", items.ToList());
        }

        // GET: Shares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.Shares.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            return View(share);
        }

        // GET: Shares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,CompanyName,MarketPrice")] Share share)
        {
            if (ModelState.IsValid)
            {
                db.Shares.Add(share);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(share);
        }

        // GET: Shares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.Shares.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            return View(share);
        }

        // POST: Shares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,CompanyName,MarketPrice")] Share share)
        {
            if (ModelState.IsValid)
            {
                db.Entry(share).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(share);
        }

        // GET: Shares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Share share = db.Shares.Find(id);
            if (share == null)
            {
                return HttpNotFound();
            }
            return View(share);
        }

        // POST: Shares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Share share = db.Shares.Find(id);
            db.Shares.Remove(share);
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
