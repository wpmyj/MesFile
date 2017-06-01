using LY.MES.Manage.Commonn;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LY.MES.Service.Common
{
    public class EF6Process
    {
        public static void Warmup()
        {
            //EF暖机操作
            using (LYMesSystemEntities dbContext = new LYMesSystemEntities())
            {
                var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;

                var mappintCollection =
                    (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                mappintCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
    }
}
