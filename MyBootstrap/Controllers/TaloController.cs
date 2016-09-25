using System.Collections.Generic;
using MyBootstrap.Utilities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using MyBootstrap.Database;
using MyBootstrap.Models;
using System.Globalization;
using System.Net;
using System.Web;

//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;
//using MyBootstrap.Database;
//using System.Globalization;
//using MyBootstrap.Utilities;
//using Newtonsoft.Json;
//using System;
//using Newtonsoft.Json.Linq;

namespace MyBootstrap.Controllers
{
    public class TaloController : Controller
    {
        private alytaloEntities db = new alytaloEntities();

        [HttpPost]
        public JsonResult AssignTalo()
        {
            string json = Request.InputStream.ReadToEnd();
            AssignTaloModel inputData =
                JsonConvert.DeserializeObject<AssignTaloModel>(json);

            bool success = false;
            string error = "";
            alytaloEntities entities = new alytaloEntities();
            try
            {
                //// haetaan ensin paikan id-numero koodin perusteella
                //int locationId = (from l in entities.AssetLocations
                //                  where l.Code == inputData.LocationCode
                //                  select l.Id).FirstOrDefault();

                //// haetaan laitteen id-numero koodin perusteella
                //int assetId = (from a in entities.Assets
                //               where a.Code == inputData.AssetCode
                //               select a.Id).FirstOrDefault();

                //if ((locationId > 0) && (assetId > 0))
                //{
                //    // tallennetaan uusi rivi aikaleiman kanssa kantaan
                //    AssetLocation1 newEntry = new AssetLocation1();
                //    newEntry.LocationId = locationId;
                //    newEntry.AssetId = assetId;
                //    newEntry.LastSeen = DateTime.Now;

                //    entities.AssetLocations1.Add(newEntry);
                //    entities.SaveChanges();

                //    success = true;
                //}
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            // palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);
            //return (result);
            //        JObject.Parse(JObject.Parse(result));
            // return result;
        }

        // GET: Talo
        public ActionResult Index()
        {
            return View(db.Talo.ToList());
        }

        public string ActionHello()
        {
            return ("Hello world! from Hello controller action.");
        }


        // GET: Talo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // GET: Talo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Talo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaloId,NykyLampo,TavoiteLampo")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Talo.Add(talo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talo);
        }

        // GET: Talo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // POST: Talo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaloId,NykyLampo,TavoiteLampo")] Talo talo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talo);
        }

        // GET: Talo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talo talo = db.Talo.Find(id);
            if (talo == null)
            {
                return HttpNotFound();
            }
            return View(talo);
        }

        // POST: Talo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talo talo = db.Talo.Find(id);
            db.Talo.Remove(talo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Test()
        {
            //List<LocatedTaloViewModel> model = new List<LocatedTaloViewModel>();

            //alytaloEntities entities = new alytaloEntities();
            //try
            //{
            //    List<Talo> talot = entities.Talo.ToList();

            //    // muodostetaan näkymämalli tietokannan rivien pohjalta
            //    CultureInfo fiFi = new CultureInfo("fi-FI");
            //    foreach (Talo talo in talot)
            //    {
            //        LocatedTaloViewModel view = new LocatedTaloViewModel();
            //        view.TaloId = talo.TaloId;
            //        view.NykyLampo = talo.NykyLampo;
            //        view.TavoiteLampo = talo.TavoiteLampo;
            //        //                    view.LastSeen = talo.LastSeen.Value.ToString(fiFi);

            //        model.Add(view);
            //    }
            //}
            //finally
            //{
            //    entities.Dispose();
            //}

            //return View(model);

            return View();
        }

        public ActionResult List()
        {
            List<LocatedTaloViewModel> model = new List<LocatedTaloViewModel>();

            alytaloEntities entities = new alytaloEntities();
            try
            {
                List<Talo> talot = entities.Talo.ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                CultureInfo fiFi = new CultureInfo("fi-FI");
                foreach (Talo talo in talot)
                {
                    LocatedTaloViewModel view = new LocatedTaloViewModel();
                    view.TaloId = talo.TaloId;
                    view.NykyLampo = talo.NykyLampo;
                    view.TavoiteLampo = talo.TavoiteLampo;
//                    view.LastSeen = talo.LastSeen.Value.ToString(fiFi);

                    model.Add(view);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }



        public ActionResult LisaaTestii()
        {
            return View();
        }
        

        public JsonResult AssignTemp2Talo()
        {
            // halutaan viedä taloon uusi tavoitelämpötila

            // haetaan json muuttujaan input-striimistä json
            string json = Request.InputStream.ReadToEnd();
            // input dataan parsitaan jsonista kentät
            AssignTaloModel inputData =
                JsonConvert.DeserializeObject<AssignTaloModel>(json);

            bool success = false;
            string error = "";
            alytaloEntities entities = new alytaloEntities();
            try
            {
                //// haetaan ensin paikan id-numero koodin perusteella
                //int locationId = (from l in entities.AssetLocations
                //                  where l.Code == inputData.LocationCode
                //                  select l.Id).FirstOrDefault();

                ////// haetaan laitteen id-numero koodin perusteella
                ////int assetId = (from a in entities.Assets
                ////               where a.Code == inputData.AssetCode
                ////               select a.Id).FirstOrDefault();

                //if ((locationId > 0) && (assetId > 0))
                //{
                //    // tallennetaan uusi rivi aikaleiman kanssa kantaan
                //    AssetLocation1 newEntry = new AssetLocation1();
                //    newEntry.LocationId = locationId;
                //    newEntry.AssetId = assetId;
                //    newEntry.LastSeen = DateTime.Now;

                //    entities.AssetLocations1.Add(newEntry);
                //    entities.SaveChanges();

                //    success = true;
                //}
            }
            catch (Exception ex)
            {
                error = ex.GetType().Name + ": " + ex.Message;
            }
            finally
            {
                entities.Dispose();
            }

            // palautetaan JSON-muotoinen tulos kutsujalle
            var result = new { success = success, error = error };
            return Json(result);
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