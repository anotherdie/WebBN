﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebBN.Models
{
    public class SetupFee
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("fee rate")]
        [Required]
        public double FeeRate { get; set; }
    }
}
