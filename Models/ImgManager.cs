using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace iapm.Models
{
  public  class ImgManager
    {
        public int id { get; set; }
        [StringLength(500)]
        public string  imgurl { get; set; }
        [StringLength(20)]
        public string imgname { get; set; }
        [StringLength(20)]
        public string imgsize { get; set; }
        [StringLength(20)]
        public string pagename { get; set; }
        public DateTime? cctime { get; set; }
    }
}
