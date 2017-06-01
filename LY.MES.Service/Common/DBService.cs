using LY.MES.Manage.Commonn;
using Server.Framework.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Service
{
    /// <summary>
    /// Auth:xxp
    /// Remark:基础数据库处理类
    /// CreateTime:20161013
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class DBService<TEntity> where TEntity : class,new()
    {
        private LYMesSystemEntities dbContext = null;

        public DBService()
        {
            dbContext = new LYMesSystemEntities();
        }

        public DBService(LYMesSystemEntities DbContext)
        {
            dbContext = DbContext;
        }

        public GenericRepository<LYMesSystemEntities, TEntity> DbSession
        {
            get { return new GenericRepository<LYMesSystemEntities, TEntity>(dbContext); }
        }
    }
}
