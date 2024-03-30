using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Enditiy;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenikategori(TBLKATEGORILER p1)
        {
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult kategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("kategoriGetir", ktgr);

        }

        public ActionResult SIL(int id)
        {
            var Kategori = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(Kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}