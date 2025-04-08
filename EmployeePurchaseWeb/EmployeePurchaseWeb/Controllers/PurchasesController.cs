using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeePurchaseWeb.Data;
using EmployeePurchaseWeb.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Web.UI.WebControls;

namespace EmployeePurchaseWeb.Controllers
{
    public class PurchasesController : Controller
    {
        //private EmpPurchaseDbContext db = new EmpPurchaseDbContext();
        Uri baseAddress = new Uri("https://localhost:44302/api");
        HttpClient client;

        public PurchasesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: Purchases
        public ActionResult Index()
        {
            List<Purchase> purchases = new List<Purchase>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/purchases").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                purchases = JsonConvert.DeserializeObject<List<Purchase>>(data);
            }
            return View(purchases);
            //return View(db.Purchases.ToList());
        }

        // GET: Purchases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = new Purchase();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/purchases/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                purchase = JsonConvert.DeserializeObject<Purchase>(data);
            }

            //Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PurchaseDate,Amount,Description")] Purchase purchase, HttpPostedFileBase imgReceipt)
        {
            if (ModelState.IsValid)
            {
                purchase.ReceiptImage = new byte[imgReceipt.ContentLength];
                imgReceipt.InputStream.Read(purchase.ReceiptImage, 0, imgReceipt.ContentLength);

                string data = JsonConvert.SerializeObject(purchase, Formatting.Indented);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/purchases", content).Result;
                if(response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                //db.Purchases.Add(purchase);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            return View(purchase);
        }

        // GET: Purchases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = new Purchase();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/purchases/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                purchase = JsonConvert.DeserializeObject<Purchase>(data);
            }

            //Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PurchaseDate,Amount,Description")] Purchase purchase, HttpPostedFileBase imgReceipt)
        {
            if (ModelState.IsValid)
            {
                purchase.ReceiptImage = new byte[imgReceipt.ContentLength];
                imgReceipt.InputStream.Read(purchase.ReceiptImage, 0, imgReceipt.ContentLength);

                string data = JsonConvert.SerializeObject(purchase, Formatting.Indented);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/purchases/" + purchase.Id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                //db.Entry(purchase).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(purchase);
        }

        // GET: Purchases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = new Purchase();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/purchases/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                purchase = JsonConvert.DeserializeObject<Purchase>(data);
            }

            //Purchase purchase = db.Purchases.Find(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Purchase purchase = new Purchase();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/purchases/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                purchase = JsonConvert.DeserializeObject<Purchase>(data);
            }

            response = client.DeleteAsync(client.BaseAddress + "/purchases/" + purchase.Id).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}

            //Purchase purchase = db.Purchases.Find(id);
            //db.Purchases.Remove(purchase);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
