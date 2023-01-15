using ADL.Models.db_Models;
using AIL.idh.sql.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIL.idh.sql.Repositories
{
    public class MeasurementTypeRepository : GenericRepository<MeasurementType>
    {
        public MeasurementTypeRepository(DataSourceContext dbContext) : base(dbContext)
        {
        }
    }
}
