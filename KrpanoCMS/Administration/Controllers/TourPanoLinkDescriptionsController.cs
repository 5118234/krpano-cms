﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KrpanoCMS.Administration.Controllers
{
    public class TourPanoLinkDescriptionsController : Controller
    {
        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View(db.TourPanoLinkDescription.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TourPanoLinkDescription tourPanoLinkDescription = db.TourPanoLinkDescription.Find(id);
            if (tourPanoLinkDescription == null)
            {
                return HttpNotFound();
            }

            return View(tourPanoLinkDescription);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(TourPanoLinkDescription tourPanoLinkDescription)
        {
            if (ModelState.IsValid)
            {
                db.TourPanoLinkDescription.Add(tourPanoLinkDescription);
                db.SaveChanges();

                return Json(new { success = true, hotspotList = tourPanoLinkDescription }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false, hotspotList = tourPanoLinkDescription }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Edit(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            TourPanoLinkDescription tourPanoLinkDescription = db.TourPanoLinkDescription.Find(id);

            if (tourPanoLinkDescription == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, tourPanoLinkDescription = tourPanoLinkDescription }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Edit(TourPanoLinkDescription tourPanoLinkDescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourPanoLinkDescription).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { success = true, tourPanoLinkDescription = tourPanoLinkDescription }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            var tourPanoLinkDescription = db.TourPanoLinkDescription.Find(id);

            if (tourPanoLinkDescription == null)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { success = true, tourPanoLinkDescription = tourPanoLinkDescription }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            TourPanoLinkDescription tourPanoLinkDescription = db.TourPanoLinkDescription.Find(id);
            db.TourPanoLinkDescription.Remove(tourPanoLinkDescription);
            db.SaveChanges();

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
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
