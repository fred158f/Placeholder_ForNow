using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Models.db_Models.Interfaces
{
    public class MeasurementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
}
