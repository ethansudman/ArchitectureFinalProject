using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements_Application
{
    /// <summary>
    /// Abstract base class for connections to requirements managers
    /// </summary>
    abstract public class Requirement
    {
        public int RequirementNumber { get; set; }

        public bool FullyFulfills { get; set; }

        public abstract string Description { get; }

        public abstract string ToolName { get; }

        public abstract string Name { get; }
    }
}
