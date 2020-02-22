using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace Repository.File
{
    public class ReportExport
    {

        public byte[] XLSXFromObject<T>(IEnumerable<T> listElement, string nameOfTabs, string title) where T : class
        {
            byte[] fileContents;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(nameOfTabs);
                worksheet.Cells["A1"].Value = title;
                worksheet.Cells["A1"].Style.Font.SetFromFont(new Font("Arial", 20));
                var range = worksheet.Cells["A4"].LoadFromCollection(Collection: listElement, PrintHeaders: true, TableStyle: OfficeOpenXml.Table.TableStyles.Medium14);
                range.AutoFitColumns();
                fileContents = package.GetAsByteArray();
            }
            return fileContents;
        }

        public byte[] XLSXFromDataTable(DataTable data, string nameOfTabs, string title)
        {
            byte[] fileContents;

            using (var package = new ExcelPackage())
            {

                var worksheet = package.Workbook.Worksheets.Add(nameOfTabs);
                worksheet.Cells["A1"].Value = title;
                worksheet.Cells["A1"].Style.Font.SetFromFont(new Font("Arial", 20));
                var range = worksheet.Cells["A4"].LoadFromDataTable(data, PrintHeaders: true, TableStyle: OfficeOpenXml.Table.TableStyles.Medium14);
                range.AutoFitColumns();
                fileContents = package.GetAsByteArray();
            }
            return fileContents;
        }

        public byte[] XLSXFromDataReader(IDataReader data, string nameOfTabs, string title)
        {
            byte[] fileContents;

            using (var package = new ExcelPackage())
            {

                var worksheet = package.Workbook.Worksheets.Add(nameOfTabs);
                worksheet.Cells["A1"].Value = title;
                worksheet.Cells["A1"].Style.Font.SetFromFont(new Font("Arial", 20));
                var range = worksheet.Cells["A4"].LoadFromDataReader(data, PrintHeaders: true, TableName: title, TableStyle: OfficeOpenXml.Table.TableStyles.Medium14);
                range.AutoFitColumns();
                fileContents = package.GetAsByteArray();
            }
            return fileContents;
        }

    }
}
