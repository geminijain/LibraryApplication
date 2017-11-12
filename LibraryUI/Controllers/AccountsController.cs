using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryApp;

namespace LibraryUI.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        [Authorize]
        public ActionResult Index()
        {
            return View(Library.GetAllAccounts(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = Library.GetAccountByAccountNumber(id.Value);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountNumber,EmailAddress,NumberOfIssuedBooks,CreatedDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                Library.CreateAccount(account.EmailAddress);
                return RedirectToAction("Index");
            }

            return View(account);
        }
        public ActionResult Deposit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var account = Library.GetAccountByAccountNumber(id.Value);
            return View(account);
        }

        [HttpPost]
        public ActionResult Deposit(FormCollection controls)
        {
            var accountNumber = Convert.ToInt32(controls["AccountNumber"]);
            var bookNumber = Convert.ToInt32(controls["BookNumber"]);
            var quantity = Convert.ToInt32(controls["Quantity"]);
            Library.Deposit(accountNumber, bookNumber, quantity);
            return RedirectToAction("Index");
        }

        //// GET: Accounts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = Library.GetAccountByAccountNumber(id.Value);

        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(account);
        //}

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "AccountNumber,EmailAddress,NumberOfIssuedBooks,CreatedDate")] Account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(account).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(account);
        //}

        protected override void Dispose(bool disposing)
        {
          base.Dispose(disposing);
        }
    }
}
