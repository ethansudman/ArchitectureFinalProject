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
    /// 
    /// <remarks>
    /// This implements access to a generic requirements Excel spreadsheet meeting certain specifications.
    /// 
    /// In the future, remove hardcoded values for column names and allow XML mapping.
    /// </remarks>
    /// 
    /// <comments>
    ///     <sequence>
    ///         <step number="1" actor="User" targetClass="MainWindow" method="Click" returnType="Requirement"/>
    ///         <step number="2" callingClass="MainWindow" targetClass="TemporaryFactory" method="GetMap" returnName="" returnType="Requirement"/>
    ///         <!-- Constructor call - equivalent to a Create message -->
    ///         <step number="3" callingClass="TemporaryFactory" targetClass="ExcelProvider" method="ExcelProvider()" returnName="" returnType=""/>
    ///         <!-- Note the difference here; here we're just calling a void method -->
    ///         <!-- It may seem a little strange to have a return type of "void;" this is somewhat programming-language dependent but this is actually typical for many functional languages -->
    ///         <step number="4" callingClass="TemporaryFactory" targetClass="ExcelProvider" method="Init" returnName="" returnType="void"/>
    ///     </sequence>
    ///     
    ///     <!-- Tool name/details are registered separately in the configuration file -->
    ///     <requirement RequirementNumber="1" FullyFulfills="true"/>
    ///     
    ///     <!-- Details on use case location/tools are listed in the configuration -->
    ///     <useCase Number="1"/>
    /// </comments>
    public class ExcelProvider : Requirement
    {
        private string _name, _desc;

        public ExcelProvider()
        {
            Init();
        }

        public override bool UpdateProvider()
        {
            // This implementation is not shown for this provider; see the Access Provider for an example
            throw new NotImplementedException();
        }

        public void Init()
        {
            Application app = new Application();

            string excelFile = ConfigurationManager.AppSettings["ExcelFile"];
            Workbook workbook = app.Workbooks.Open(excelFile);
            //Workbook workbook = app.Workbooks.Open(@"E:\My Documents\Visual Studio 2012\Projects\Architecture Final Project\Requirements Application\Providers\Excel\Sample.xls");
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
