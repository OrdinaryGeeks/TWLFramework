using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TWLFramework.Models
{
    public class Client
    {

        public int ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<TrainerVideo> AccessableVideos { get; set; }
    }
}