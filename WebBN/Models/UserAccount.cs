using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBN.Models
{
    public class UserAccount
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("BankNo")]
        public string IBAN_No { get; set; }

        [Required]
        [DisplayName("AccountName")]
        public string AccountName { get; set; }

        [Required]
        [DisplayName("CitizenID")]
        public string CID { get; set; }

        [DisplayName("Deposit Amount")]
        public double Deposit_Amount { get; set; }
        public DateTime CreateDate { get; set; }
        public string  CreateUser { get; set; }
    }
}
