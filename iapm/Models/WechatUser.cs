using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iapm.Models
{
 public   class WechatUser
    {
        public int WechatUserId { get; set; }


        [Required]
        [StringLength(50)]
        public string openid { get; set; }
        [StringLength(50)]
        public string nickname { get; set; }

        public int sex { get; set; }
        [StringLength(50)]
        public string province { get; set; }
        [StringLength(50)]
        public string city { get; set; }
        [StringLength(50)]
        public string country { get; set; }
        [StringLength(500)]
        public string headimgurl { get; set; }
        public int Ibeaconid { get; set; }
    



    }
}
