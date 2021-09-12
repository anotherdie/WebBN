using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBN.Data;
using WebBN.Models;

namespace WebBN.Controllers
{
    public class DepositController : Controller
    {
        private readonly ApplicationDBContext _db;

        public DepositController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData["MsgDeposit"] != null)
            {
                ViewBag.Message = TempData["MsgDeposit"].ToString();
                TempData["MsgDeposit"] = null;
            }


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(TansactionLog trans)
        {

            if (ModelState.IsValid)
            {
                string message = InsertTrans(trans);
                TempData["MsgDeposit"] = message;

            }

            return RedirectToAction("Index");
        }

        public string InsertTrans(TansactionLog trans)
        {
            string result = "";

            try
            {

                if (!ValidateBankNo(trans))
                {
                    result += " Invalid BankNo : " + trans.IBAN_No;
                }

                if (result == "")
                {
                    trans.Types = TansactionLog.TransType.Deposit;
                    trans.SetTranID();
                    trans.TransDate = DateTime.Now;
                    _db.TansactionLogs.Add(trans);

                    UserAccount uTo = _db.UserAccounts.Where(u => u.IBAN_No == trans.IBAN_No).FirstOrDefault();

                    uTo.Deposit_Amount = uTo.Deposit_Amount + trans.Amount;

                    _db.SaveChanges();
                    result = "Success.";
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

            return result;
        }

        private bool ValidateBankNo(TansactionLog trans)
        {
            bool status = false;
            int validBankNo = _db.UserAccounts.Where(a => a.IBAN_No == trans.IBAN_No).Count();
            if (validBankNo > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }
    }
}
