using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWLFramework.Models
{
    public class Exercise
    {

        public int ID { get; set; }
        public string Description { get; set; }

        public string URL { get; set; }

        public virtual int TrainerVideoID { get; set; }
        public virtual int TrainerID { get; set; }
    }
}