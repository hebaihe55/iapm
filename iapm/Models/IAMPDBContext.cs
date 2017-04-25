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
        public DbSet<ImgManager> ImgManagers { get; set; }
        public DbSet<Report1> Report1s { get; set; }
        public DbSet<Report2> Report2s { get; set; }
        public DbSet<Report3> Report3s { get; set; }
        public DbSet<Report4> Report4s { get; set; }
        public DbSet<Report5> Report5s { get; set; }
        public DbSet<Report6> Report6s { get; set; }

        public System.Data.Entity.DbSet<iapm.Models.Report7> Report7 { get; set; }
    }
}
