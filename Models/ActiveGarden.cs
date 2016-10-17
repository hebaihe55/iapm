using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iapm.Models
{
   public class ActiveGarden
    {
        public int ActiveGardenid { get; set; }
        public string  OpenId { get; set; }
        public int Ibeaconid { get; set; }
        public int? gardenFee { get; set; }

        public string  gardenType { get; set; }
        public DateTime cdate { get; set; }
        public DateTime ctime { get; set; }




    }
}
