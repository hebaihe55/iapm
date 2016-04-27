using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace iapm.Models
{
    public enum floors
    {
        LG2=-2,
        LG1=-1,
        L1=1,
        L2=2,
        L3=3,
        L4=4,
        L5=5,
        L6=6
    }
  public  class Ibeacon
    {
        public int Ibeaconid { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name ="编码")]
        public string  code { get; set; }//编码

        [Required]
        [Display(Name = "楼层")]
        public floors floor { get; set; }//楼层

        [Required]
        [StringLength(500)]
        [Display(Name = "商家")]
        public string bueness { get; set; }//商家

        [Required]
        [StringLength(500)]
        [Display(Name = "说明")]
        public string demo { get; set; }//说明
        [Display(Name = "最小积分")]
        public int minifen { get; set; }//最小积分
        [Display(Name = "最大积分")]
        public int maxifen { get; set; }//最大积分
        [Display(Name = "双倍卡开始时间")]
        public DateTime dbtime { get; set; }//双倍积分开始时间
        [Display(Name = "双倍卡结束时间")]
        public DateTime detime { get; set; }//双倍积分结束时间
        [Display(Name = "双倍积分出现次数")]
        public int dfen { get; set; }//双倍积分
   

    }
}
