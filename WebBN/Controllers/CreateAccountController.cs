using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBN.Data;
using WebBN.Models;

namespace WebBN.Controllers
{
    public class CreateAccountController : Controller
    {
        private readonly ApplicationDBContext _db;

        public CreateAccountController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            if (TempData["Msg"] != null)
            {
                ViewBag.Message = TempData["Msg"].ToString();
                TempData["Msg"] = null;
            }
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Detail(string? IBAN_NO)
        {
            ViewModel.AccountDetail detailAcc = new ViewModel.AccountDetail();
            UserAccount acc = new UserAccount();
            if (IBAN_NO != null)
            {
                acc = _db.UserAccounts.Where(u => u.IBAN_No == IBAN_NO).FirstOrDefault();
                if (detailAcc != null)
                {
                    detailAcc.IBAN_No = acc.IBAN_No;
                    detailAcc.FirstName = acc.FirstName;
                    detailAcc.LastName = acc.LastName;
                    detailAcc.Deposit_Amount = acc.Deposit_Amount;
                    detailAcc.CID = acc.CID;
                    detailAcc.AccountName = acc.AccountName;
                    detailAcc.ls_T = _db.TansactionLogs.Where(t => t.IBAN_No == IBAN_NO || t.ToIBAN_No == IBAN_NO).ToList();
                }
            }

            return View(detailAcc);
        }



        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserAccount acc)
        {

            if (ModelState.IsValid)
            {
                string message = InsertAccount(acc);
                TempData["Msg"] = message;
            }

            return RedirectToAction("Index");
        }

        public string InsertAccount(UserAccount acc)
        {
            string result = "";

            try
            {
                //Set system
                acc.CreateUser = "System";
                acc.CreateDate = DateTime.Now;


                //Validate unique IBan_No
                if (ValidateDuplicateIBAN_NO(acc.IBAN_No))
                {
                    _db.UserAccounts.Add(acc);

                    TansactionLog T = new TansactionLog();
                    T.SetTranID();
                    T.TransDate = DateTime.Now;
                    T.Types = TansactionLog.TransType.Create;
                    T.IBAN_No = acc.IBAN_No;
                    T.Amount = acc.Deposit_Amount;

                    _db.TansactionLogs.Add(T);
                    _db.SaveChanges();
                    result = "Success.";
                }
                else
                {
                    result = "Duplicate IBAN_NO : " + acc.IBAN_No;


                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return result;
        }

        private bool ValidateDuplicateIBAN_NO(string IBAN_NO)
        {
            bool status = false;
            int c = _db.UserAccounts.Where(ib => ib.IBAN_No == IBAN_NO).Count();
            if (c > 0)
            {
                status = false;
            }
            else
            {
                status = true;
            }

            return status;
        }
    }
}
