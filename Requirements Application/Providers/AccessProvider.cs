using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace Requirements_Application
{
    public class AccessProvider : Map
    {
        protected override Connection ConnectToTool()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override string ToolName
        {
            get { return "Access"; }
        }

        /// <summary>
        /// Get the description of the 
        /// </summary>
        public override string Description
        {
            get { throw new NotImplementedException(); }
        }
    }
}
