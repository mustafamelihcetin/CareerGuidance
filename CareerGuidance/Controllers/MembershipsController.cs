using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.ApplicationServices;
using System.Configuration;
using CareerGuidance;
using CareerGuidance.Models;

namespace CareerGuidance.Controllers
{

    public class MembershipsController : Controller
    {
        private CareerGuidanceEntities1 db = new CareerGuidanceEntities1();

        // GET: Memberships
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Membership.ToList());
        }

        // GET: Memberships/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Membership.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // GET: Memberships/Create
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,Name,Surname,Username,Password,Email,Address,Gender")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Membership.Add(membership);
                db.SaveChanges();
                ViewBag.message = "The account has been created.";
                return RedirectToAction("Login");
            }

            return View();
        }

        // GET: Memberships/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Membership.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Surname,Username,Password,Email,Address,Gender")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(membership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(membership);
        }

        // GET: Memberships/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Membership membership = db.Membership.Find(id);
            if (membership == null)
            {
                return HttpNotFound();
            }
            return View(membership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Membership membership = db.Membership.Find(id);
            db.Membership.Remove(membership);
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

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Membership m, string ReturnUrl)
        {
            using (var context = new CareerGuidanceEntities1())
            {
                bool isValid = context.Membership.Any(x => x.Username == m.Username && x.Password == m.Password);
                if (isValid)
                {
                    ViewBag.Message1 = "User login successful, redirecting...";
                    System.Web.Security.FormsAuthentication.SetAuthCookie(m.Username, false);
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ViewBag.Message = "Username or password is wrong.";
                    return View();
                }
            }
        }
        public ActionResult Logout()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Membership m)
        {

            using (var context = new CareerGuidanceEntities1())
            {
                bool isValid = context.Membership.Any(x => x.Username == m.Username && x.Password == m.Password);
                if (isValid)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    return RedirectToAction("Index", "About");
                }
            }
        }
    }
}
