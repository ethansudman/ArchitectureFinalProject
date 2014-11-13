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
    public class AccessProvider : Requirement
    {
        private OleDbConnection GetConnection()
        {
            var connStr = ConfigurationManager.ConnectionStrings["Access"].ConnectionString;
            return new OleDbConnection(connStr);
        }

        public override string Name
        {
            get
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.Parameters.AddWithValue("@ID", RequirementNumber);

                        // TOP(1) is just a hint to the query engine for optimization, the ID will only match 1 row anyway
                        command.CommandText =
                            @"SELECT TOP(1) Name
                              FROM RequirementTable
                              WHERE ID = @ID";

                        return command.ExecuteScalar() as string;
                    } // Dispose of command
                } // Dispose of DB connection
            } // End get
        } // End property Name

        public override string ToolName
        {
            get { return "Access"; }
        }

        /// <summary>
        /// Get the description of the 
        /// </summary>
        public override string Description
        {
            get
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.Parameters.AddWithValue("@ID", RequirementNumber);

                        // TOP(1) is just a hint to the query engine for optimization, the ID will only match 1 row anyway
                        command.CommandText =
                            @"SELECT TOP(1) Description
                              FROM RequirementTable
                              WHERE ID = @ID";

                        return command.ExecuteScalar() as string;
                    } // Dispose of command
                } // Dispose of DB connection
            } // End get
        } // End property Description
    }
}
