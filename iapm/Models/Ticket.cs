using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace iapm.Models
{
   public  class Ticket
    {
       public int Ticketid { get; set; }

        
   
        [Required]
        [StringLength(27)]
        [Display(Name = "标题")]
        public string title { get; set; }
        [Required]
        [StringLength(108)]
        [Display(Name = "英文标题")]
        public string entitle { get; set; }
        [Required]
        [Display(Name = "数量")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "金币数")]
        public int iconcount { get; set; }



        [Required]
        [Display(Name = "上架时间")]
        public DateTime btime { get; set; }
        [Required]
        [Display(Name = "下架时间")]
        public DateTime etime { get; set; }



        [Required]
        [StringLength(200)]
        [Display(Name = "详情图")]
        public string detailImg { get; set; }
        [Required]
        [StringLength(1024)]
        [Display(Name = "详情")]
        public string detail { get; set; }
        [Required]
        [StringLength(4000)]
        [Display(Name = "英文详情")]
        public string endetail { get; set; }

        public string card_id { get; set; }

        public DateTime ctime { get; set; }


        public int flag { get; set; }

    }
}
