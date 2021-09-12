using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBN.Models;

namespace WebBN.ViewModel
{
    public class AccountDetail
    {

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IBAN_No { get; set; }
        public string AccountName { get; set; }
        public string CID { get; set; }
        public double Deposit_Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }

        public List<TansactionLog> ls_T = new List<TansactionLog>();
    }
}
