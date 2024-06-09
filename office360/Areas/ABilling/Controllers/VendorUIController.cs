using office360.Models.EDMX;
using office360.Models.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace office360.Areas.ABilling.Controllers
{
    public class VendorUIController : Controller
    {
        // GET: ABilling/VendorUI
        public ActionResult NewVendor_FE()
        {
            return View();
        }
        public ActionResult InsertIntoDB(Vendors PostedData)
        {
            if (ModelState.IsValid)
            {
                using (var db = new SESEntities())
                {
                    db.Vendors.Add(PostedData); 
                    db.SaveChanges(); 
                }
                return RedirectToAction("Index"); // Redirect to a view (optional, replace with appropriate action)
            }
            return View("NewVendor_FE"); // Return to the view with the posted data if the model state is not valid
        }
        public ActionResult VendorsList()
        {
            List<Vendors> Data;
            using (var db = new SESEntities())
            {
                Data = db.Vendors.ToList();
            }
            return Json(new { success = true, data = Data }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DBOperation(_SqlParameters PostedData)
        {
            using (var db = new SESEntities())
            {
                if (PostedData.Action == "Edit")
                {
                    // Find the vendor by ID
                    var vendor = db.Vendors.Find(PostedData.Id_);
                    if (vendor != null)
                    {
                        // Update vendor properties here
                        vendor.Title = PostedData.Title; // Example property

                        db.Entry(vendor).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        return Json(new { success = false, message = "Vendor not found" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (PostedData.Action == "Delete")
                {
                    // Find the vendor by ID
                    var vendor = db.Vendors.Find(PostedData.Id_);
                    if (vendor != null)
                    {
                        db.Vendors.Remove(vendor);
                        db.SaveChanges();
                    }
                    else
                    {
                        return Json(new { success = false, message = "Vendor not found" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }




    }
}