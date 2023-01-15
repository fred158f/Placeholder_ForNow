using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Measurements.Interfaces
{
    public interface IMeasurementSource<T>
    {
        string Name { get; set; }
        T ReadMeasurement();
    }
}
