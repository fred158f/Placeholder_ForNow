using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Models.db_Models
{
    public class MeasurementType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

        public MeasurementSource? ParentSource { get; set; }
    }
}
