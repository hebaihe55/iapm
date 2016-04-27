using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iapm.Models
{
  public  class Login
    {

        [Required]
       
        public string name { get; set; }
        [Required]
        public string pwd { get; set; }
    }
}
