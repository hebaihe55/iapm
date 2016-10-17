using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace iapm.Models
{
   public  class Card
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string  OpenId { get; set; }
        [StringLength(50)]
        public string  CardId { get; set; }
        [StringLength(50)]
        public string CardCode{ get; set; }
        [StringLength(50)]
        public string CardType { get; set; }
     
        public int? CardFee { get; set; }
        public DateTime CCtime { get; set; }
    }
}
