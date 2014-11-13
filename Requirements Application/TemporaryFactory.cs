using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Requirements_Application
{
    // For now use a factory, use DI later
    public class TemporaryFactory
    {
        public Requirement GetMap(string provider)
        {
            // Should do other checks

            switch (provider.Trim().ToLower())
            {
                case "access":
                    return new AccessProvider();

                case "excel":
                    return new ExcelProvider();

                default:
                    throw new ArgumentException("Not a known provider");
            }
        }
    }
}
