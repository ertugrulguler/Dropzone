using Dropzene.Model.Models;
using Dropzone.DataAccessLayer.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropzone.DataAccessLayer.Context
{
    public class ProjectContext:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProjectContext>(new ProjectInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
