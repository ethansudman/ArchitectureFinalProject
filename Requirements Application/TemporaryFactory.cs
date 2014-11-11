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
        public Map GetMap(string provider)
        {
            // Should do other checks

            switch (provider.Trim().ToLower())
            {
                case "Access":
                    break;

                default:
                    throw new ArgumentException("Not a known provider");
            }
        }
    }
}
