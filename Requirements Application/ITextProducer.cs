using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements_Application
{
    /// <summary>
    /// Category that produces descriptions (e.g. requirement descriptions)
    /// </summary>
    public interface ITextProducer
    {
        string Description { get; }
    }
}
