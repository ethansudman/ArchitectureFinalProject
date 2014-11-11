using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements_Application
{
    abstract public class Map
    {
        public int RequirementNumber { get; set; }

        public string Tool { get; set; }

        public bool FullyFulfills { get; set; }

        /// <summary>
        /// Factory to get a <see cref="Connection"/> to the underlying provider
        /// </summary>
        /// <returns></returns>
        abstract protected Connection ConnectToTool();

        public virtual bool Check()
        {
            var connection = ConnectToTool();

            connection.Query();
        }
    }
}
