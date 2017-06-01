using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Manage.Commonn
{

    public partial class LYMesSystemEntities : DbContext
    {
        public LYMesSystemEntities()
            : base("name=LYMesSystemEntities")
        {
            Database.SetInitializer<LYMesSystemEntities>(null);
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

     
    }
}
