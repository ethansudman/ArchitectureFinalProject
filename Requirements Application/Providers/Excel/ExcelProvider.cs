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

        public void Init()
        {
            Application app = new Application();

            // TODO: use the config version
            //string excelFile = ConfigurationManager.AppSettings["ExcelFile"];
            Workbook workbook = app.Workbooks.Open(@"E:\My Documents\Visual Studio 2012\Projects\Architecture Final Project\Requirements Application\Providers\Excel\Sample.xls");
            Worksheet sheet = workbook.ActiveSheet;
            //sheet.

            for (int i = 2; i <= sheet.Rows.Count; i++)
            {
                // Obviously I'm making some assumptions about what the file will look like here
                var range = sheet.Cells[i, 1] as Range;
                if (range.Value == RequirementNumber)
                {
                    _name = sheet.Cells[i, 2].Value2;
                    _desc = sheet.Cells[i, 3].Value2;
                    break;
                }

                // If we don't do this we'll have background processes left after we quit
                releaseObject(range);
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
