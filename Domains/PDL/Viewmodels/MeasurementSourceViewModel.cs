using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.Viewmodels
{
    public class MeasurementSourceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasurementTypeViewModel SourceType { get; set; }
    }
}
