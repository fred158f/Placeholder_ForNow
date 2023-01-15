using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Measurements.Interfaces
{
    public interface IMeasurement<T>
    {
        string Name { get; set; }
        string Unit { get; set; }
        T Value { get; set; }
    }
}
