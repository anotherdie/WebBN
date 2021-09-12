using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBN.Models;

namespace WebBN.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<SetupFee> SetupFees { get; set; }
        public DbSet<TansactionLog> TansactionLogs { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
