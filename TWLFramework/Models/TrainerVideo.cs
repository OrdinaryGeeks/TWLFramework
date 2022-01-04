using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWLFramework.Models
{
    public class TrainerVideo
    {

        public int ID { get; set; }
        public virtual int TrainerID { get; set; }

        public string URL { get; set; }

        public string Tags { get; set; }
   
    }
}