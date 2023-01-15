using ADL.Models.db_Models;
using AIL.idh.sql.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIL.idh.sql.Repositories
{
    public class MeasurementSourceRepository : GenericRepository<MeasurementSource>
    {
        public MeasurementSourceRepository(DataSourceContext dbContext) : base(dbContext)
        {
        }
    }
}
