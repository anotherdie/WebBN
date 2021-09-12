using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBN.Data;
using WebBN.Models;

namespace WebBN.Controllers
{
    public class TransferController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TransferController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (TempData["MsgTrans"] != null)
            {
                ViewBag.Message = TempData["MsgTrans"].ToString();
                TempData["MsgTrans"] = null;
            }



            double fee = _db.SetupFees.Where(a => a.ID == 1).FirstOrDefault().FeeRate;
            TempData["MsgFee"] = fee.ToString();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TansactionLog trans)
        {

            if (ModelState.IsValid)
            {
                string message = InsertTrans(trans);
                TempData["MsgTrans"] = message;

            }

            return RedirectToAction("Index");
        }

        public string InsertTrans(TansactionLog trans)
        {
            string result = "";

            try
            {
                if (!ValidateAmount(trans))
                {
                    result += " Not Enough Amount : " + trans.Amount + " |";
                }
                
                if (!ValidateBankNo(trans))
                {
                    result += " Invalid BankNo : " + trans.IBAN_No + " |";
                }

                if (!ValidateToBankNo(trans))
                {
                    result += " Invalid ToBankNo : " + trans.ToIBAN_No + " |";
                }

                if (!ValidateSameBankNo(trans))
                {
                    result += " Invalid BankNo same ToBankNo." + " |";
                }

                result = result.TrimEnd('|');

                if (result == "")
                {
                    trans.Types = TansactionLog.TransType.Transfer;
                    trans.SetTranID();
                    trans.TransDate = DateTime.Now;
                    _db.TansactionLogs.Add(trans);

                    UserAccount uFrom = _db.UserAccounts.Where(u => u.IBAN_No == trans.IBAN_No).FirstOrDefault();
                    UserAccount uTo = _db.UserAccounts.Where(u => u.IBAN_No == trans.ToIBAN_No).FirstOrDefault();

                    uFrom.Deposit_Amount = uFrom.Deposit_Amount - trans.Amount;
                    uTo.Deposit_Amount = uTo.Deposit_Amount + GetRealAmount(trans);

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

        private bool ValidateAmount(TansactionLog trans)
        {
            bool status = false;
            UserAccount a = _db.UserAccounts.Where(a => a.IBAN_No == trans.IBAN_No).FirstOrDefault();
            if (a.Deposit_Amount > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
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

        private bool ValidateToBankNo(TansactionLog trans)
        {
            bool status = false;
            int validToBankNo = _db.UserAccounts.Where(a => a.IBAN_No == trans.ToIBAN_No).Count();
            if (validToBankNo > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        private bool ValidateSameBankNo(TansactionLog trans)
        {
            bool status = false;
            if (trans.IBAN_No != trans.ToIBAN_No)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        private double GetRealAmount(TansactionLog trans) 
        {
            double fee = _db.SetupFees.Where(a => a.ID == 1).FirstOrDefault().FeeRate;
            return trans.Amount - (trans.Amount * fee);
        }

    }
}
