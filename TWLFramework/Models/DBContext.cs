using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TWLFramework.Models;

namespace TWLFramework.Models
{
    public class DBContext : DbContext
    {



        public DBContext()
        {


            this.Configuration.LazyLoadingEnabled = true;

        }

        public System.Data.Entity.DbSet<TWLFramework.Models.Trainer> Trainers { get; set; }

        public System.Data.Entity.DbSet<TWLFramework.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<TWLFramework.Models.TrainerVideo> TrainerVideos { get; set; }

        public System.Data.Entity.DbSet<TWLFramework.Models.Admin> Admins { get; set; }

        public System.Data.Entity.DbSet<TWLFramework.Models.Exercise> Exercises { get; set; }
    }
}