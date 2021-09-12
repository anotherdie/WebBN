using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebBN.Models
{
    public class TansactionLog
    {
        public enum TransType
        {
            Create=0,
            Deposit=1,
            Transfer=2
        }

        [Key]
        [DisplayName("TransactionID")]
        public string  TranID { get; set; }

        [Required]
        [DisplayName("TransactionDate")]
        public DateTime TransDate { get; set; }

        [Required]
        [DisplayName("TransactionType")]
        public TransType Types { get; set; }

        [Required]
        [DisplayName("BankNo")]
        public string IBAN_No { get; set; }

        [DisplayName("To BankNo")]
        public string ToIBAN_No { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value more than zero")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Plese insert number.")]
        [DisplayName("Amount")]
        public double Amount { get; set; }

        [Required]
        [DisplayName("fee rate %")]
        public double Fee { get; set; }

        [Required]
        [DisplayName("Real Amount")]
        public double AmountAfterFee { get; set; }


        public void SetTranID()
        {
            string TRX = DateTime.Now.ToString("yyMMdd") + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 26).ToUpper();
            this.TranID = TRX;
        }
    }
}
