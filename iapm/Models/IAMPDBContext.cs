using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace iapm.Models
{
   public class IAMPDBContext : DbContext
    {
        public IAMPDBContext()
            : base("name=DConnection")
        { }
        public DbSet<Test> tests { get; set; }

        public DbSet<Ibeacon> Ibeacons { get; set; }
        public DbSet<WechatUser> WechatUsers { get; set; }
        public DbSet<ActiveGarden> ActiveGardens { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
