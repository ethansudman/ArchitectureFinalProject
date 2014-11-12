using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Diagnostics;

namespace Requirements_Application
{
    /// <summary>
    /// Provider for an Excel spreadsheet
    /// </summary>
    public class ExcelProvider : Map
    {
        private string _name, _desc;

        public ExcelProvider()
        {
            Application app = new Application();

            string excelFile = ConfigurationManager.AppSettings["ExcelFile"];
            Workbook workbook = app.Workbooks.Open(excelFile);
            Worksheet sheet = workbook.ActiveSheet;
            //sheet.

            for (int i = 1; i < sheet.Rows.Count; i++)
            {
                // Obviously I'm making some assumptions about what the file will look like here
                var range = sheet.Rows[i, 0] as Range;
                if (range.Value2.Trim().Equals(RequirementNumber.ToString()))
                {
                    _name = sheet.Rows[i, 1];
                    _desc = sheet.Rows[i, 2];
                    break;
                }

                // TODO: do I need this?
                //releaseObject(range);
            }

            releaseObject(sheet);
            releaseObject(workbook);
            app.Quit();
            releaseObject(app);
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.Collect();
        }

        private void releaseObject(object obj)
        {
            try
            {
                Marshal.FinalReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public override string ToolName
        {
            get { return "Excel"; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override string Description
        {
            get { return _desc; }
        }
    }
}
