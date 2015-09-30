using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MobilePOS.Class
{
    public class EppTools
    {
        private string _int { get; set; }
        private string _decimal { get; set; }
        private string _datetime { get; set; }
        private string _time { get; set; }
        private string _date { get; set; }

        public EppTools()
        {
            _int = "###";
            //_decimal = "##0.00";
            _decimal = "#,###,##0";
            _datetime = "MM/dd/yyyy hh:mm:ss AM/PM";
            _time = "hh:mm:ss";
            _date = "MM/dd/yyyy";
        }

        public void GenerateWorkSheet(DataTable table, ref ExcelPackage package, string fName)
        {
            var ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 5;
            int dataRow = headerRow + 1;
            int col = 1;

            // HEADER FORMAT
            foreach (DataColumn dc in table.Columns)
            {
                //
                ws.Cells[headerRow, col].Value = dc.ColumnName;
                ws.Cells[headerRow, col].Style.Font.Bold = true;
                col++;
            }

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            //

            // POPULATING DATA TO ROWS
            foreach (DataRow dr in table.Rows)
            {
                col = 1;
                foreach (DataColumn dc in table.Columns)
                {

                    ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                    ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                    //
                    //ws.Cells[dataRow, col].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    ws.Cells[dataRow, col].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    ws.Cells[dataRow, col].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    //
                    col++;
                }
                dataRow++;
            }
        }

        public void GenerateMonthlyReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 6;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 3;
            //

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "KIOSK";
            ws.Cells[headerRow, col+1].Value = "LOCATION";
            ws.Column(1).Width = 30;
            ws.Column(2).Width = 40;
            ////
            
            table.DefaultView.Sort = "Monthly";
            DataTable distTable = table.DefaultView.ToTable(true, "Monthly");
            int colsLimit = distTable.Rows.Count;

            using (var range = ws.Cells[headerRow, 1, headerRow, colsLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }
            // populate distinct month
            foreach(DataRow dr in distTable.Rows){
                foreach(DataColumn dc in distTable.Columns){
                    col++;
                    ws.Cells[headerRow, col+1].Value = dr[dc.ColumnName];
                    ws.Column(col+1).Width = 20;
                }
            }
            col += 2;
            ws.Cells[headerRow, col].Value = "GRAND TOTAL";
            ws.Column(col).Width = 20;

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, colsLimit + added].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, colsLimit + added].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, colsLimit + added].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, colsLimit + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, colsLimit + added].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // POPULATING DATA TO ROWS
            string Supervisor = "";
            string className = "";
            string tempClassName = "";
            string visor = "";
            string location = "";
            bool stepOnce = false;

            int GrandTotal = 0;

            foreach(DataRow dr in table.Rows){
                // set to null
                col = 1;
                className = "";
                visor = "";
                int Col4Month = 0;
                
                //
                foreach (DataColumn dc in table.Columns)
                {
                    switch(col){
                        case 1:// set Class Name with Supervisor
                            className = (string)dr[dc.ColumnName];
                            //
                            if (stepOnce)
                            {
                                if (className != tempClassName)
                                {
                                    MonthRepGetSupervisorGrandTotal(table, distTable, colsLimit, ref dataRow, ws, tempClassName, added);
                                } 
                            }
                            //
                            tempClassName = className;
                            stepOnce = true;
                        break;
                        case 2:// set Class Name with Supervisor
                            visor = (string)dr[dc.ColumnName];
                            string full = className + "("+ visor+")";

                            if (Supervisor != full)
                            {
                                Supervisor = full;
                                ws.Cells[dataRow, col - 1].Value = Supervisor;
                                ws.Cells[dataRow, col - 1].Style.Font.Bold = true;
                                //
                                GrandTotal = 0;
                            }
                        break;
                        case 3:
                            string currLocation = dr[dc.ColumnName]as string;
                            if (location != currLocation)
                            {
                                location = currLocation;
                                ws.Cells[dataRow, col - 1].Value = currLocation;
                                GrandTotal = 0;
                            }
                            else
                            {
                                dataRow -=1;
                            }
                        break;
                        case 4:
                            int colDis = 1;
                            foreach(DataRow dr1 in distTable.Rows){
                                foreach(DataColumn dc1 in distTable.Columns){
                                    //
                                    string month = dr[dc.ColumnName] as string;
                                    string monthDist = dr1[dc1.ColumnName] as string;
                                    //
                                    if(month == monthDist){
                                        Col4Month = colDis;
                                    }
                                    //
                                    colDis++;
                                }
                        }
                        break;
                        case 5:
                            int total = Convert.ToInt32(dr[dc.ColumnName]);
                            GrandTotal += total;

                            ws.Cells[dataRow, col + Col4Month - added].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col + Col4Month - added].Style.Numberformat.Format = checkDataType(dc);
                            break;
                    }
                    // incrementing
                    col++;
                }
                // Populate Grand Total
                ws.Cells[dataRow, colsLimit + added].Value = GrandTotal;
                ws.Cells[dataRow, colsLimit + added].Style.Numberformat.Format = _decimal;
                //
                dataRow++;
                }
                // final class total
            MonthRepGetSupervisorGrandTotal(table, distTable, colsLimit, ref dataRow, ws, tempClassName, added);
            // Grand Grand Grand Total
            MonthRepCalculateGrandTotal(table, distTable, ws, dataRow, colsLimit, added);

        }

        private void MonthRepGetSupervisorGrandTotal(DataTable table, DataTable distTable, int colsLimit,ref int dataRow, ExcelWorksheet ws, string className, int added)
        {
            //dataRow++;
            int totalCol = 2;
            ws.Cells[dataRow, totalCol].Value = "TOTAL";
            using (var range = ws.Cells[dataRow, 2, dataRow, colsLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 229, 241));
                range.Style.Font.Bold = true;
            }

            // COMPUTATIN FOR TOTALITY OF CLASS, LOCATION,
            var groupRes = (from tab in table.AsEnumerable()
                            group tab by new { classI = tab["ClassName"], month = tab["Monthly"] } into grp
                            select new
                            {
                                rclass = grp.Key.classI,
                                rmonth = grp.Key.month,
                                Sum = grp.Sum(o => decimal.Parse(o["Total"].ToString()))
                            }).ToList();

            int GrandGrandTotal = 0;
            foreach (DataRow dr2 in distTable.Rows)
            {
                foreach (DataColumn dc2 in distTable.Columns)
                {
                    string month = dr2[dc2.ColumnName] as string;

                    var search = groupRes.Where(o => o.rmonth.ToString() == month.ToString() && o.rclass.ToString() == className.ToString()).Select(o => o.Sum);
                    //search.FirstOrDefault();
                    //
                    totalCol += 1;
                    foreach (var c in search)
                    {
                        GrandGrandTotal += (int)c;
                        ws.Cells[dataRow, totalCol].Value = (int)c;
                        ws.Cells[dataRow, totalCol].Style.Numberformat.Format = _decimal;
                    }
                }
                
            }
            //
            ws.Cells[dataRow, totalCol + 1].Value = GrandGrandTotal;
            ws.Cells[dataRow, totalCol + 1].Style.Numberformat.Format = _decimal;
            //
            dataRow++;
        }

        private void MonthRepCalculateGrandTotal(DataTable table, DataTable distTable, ExcelWorksheet ws, int dataRow, int colsLimit, int added)
        {
            using (var range = ws.Cells[dataRow, 1, dataRow, colsLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }

            ws.Cells[dataRow, 1].Value = "GRAND TOTAL";

            int colInc = 3;
            int TotalGrand = 0;

            var GrandTotalPerMonth = (from mot in table.AsEnumerable()
                                      group mot by mot["Monthly"] into grpMot
                                      select new
                                      {
                                          Group = grpMot.Key,
                                          Sum = grpMot.Sum(o => decimal.Parse(o["Total"].ToString()))
                                      }).ToList();
            //
            foreach(DataRow dr in distTable.Rows){
                //
                foreach(DataColumn dc in distTable.Columns){
                    string month = dr[dc.ColumnName]as string;

                    var search = GrandTotalPerMonth.Where(o => o.Group.ToString() == month.ToString()).Select(o=> o.Sum);

                    foreach(var res in search){
                        ws.Cells[dataRow, colInc].Value = res;
                        ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
                        TotalGrand += (int)res;
                    }
                    colInc++;
                }
            }
            // finally
            ws.Cells[dataRow, colInc].Value = TotalGrand;
            ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
        }

        public void GenerateWeeklyReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 6;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 3;

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "KIOSK";
            ws.Cells[headerRow, col + 1].Value = "LOCATION";
            ws.Column(1).Width = 30;
            ws.Column(2).Width = 40;

            //GET COLUMN LIST OF WEEK INDEX
            table.DefaultView.Sort = "WeekIn";
            DataTable disTable = table.DefaultView.ToTable(true, "WeekIn");
            int disColLimit = disTable.Rows.Count;

            // DECORATE HEADER LAYOUT
            using (var range = ws.Cells[headerRow, 1, headerRow, disColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }

            // POPULATE DISTINCT WEEK INDEX HEADER COLUMN
            foreach (DataRow dr in disTable.Rows)
            {
                foreach (DataColumn dc in disTable.Columns)
                {
                    col++;
                    ws.Cells[headerRow, col + 1].Value = dr[dc.ColumnName];
                    ws.Column(col + 1).Width = 10;
                }
            }
            col += 2;
            ws.Cells[headerRow, col].Value = "GRAND TOTAL";
            ws.Column(col).Width = 20;

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, disColLimit + added].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, disColLimit + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // POPULATING DATA TO ROWS
            string className = "";
            string tempClassName = "";
            string Supervisor = "";
            string visor = "";
            string location = "";
            bool stepOnce = false;
            int GrandTotal = 0;
            //
            foreach(DataRow dr in table.Rows){
                //
                col = 1;
                className = "";
                visor = "";
                int Col4Week = 0;

                //
                foreach(DataColumn dc in table.Columns){
                    //
                    switch(col){
                        case 1:
                            className = dr[dc.ColumnName] as string;
                            //
                            if(stepOnce){
                                //
                                if (className != tempClassName)
                                {
                                    WeekRepGetSupervisorGrandTotal(table, disTable, disColLimit, ref dataRow, ws, tempClassName, added);
                                }
                            }

                            tempClassName = className;
                            stepOnce = true;
                        break;
                        case 2:
                            visor = dr[dc.ColumnName] as string;
                            string full = className + "(" + visor + ")";

                            if(Supervisor != full){
                                Supervisor = full;

                                ws.Cells[dataRow, col - 1].Value = Supervisor;
                                ws.Cells[dataRow, col - 1].Style.Font.Bold = true;
                                //
                                GrandTotal = 0;
                            }
                        break;
                        case 3:
                            string currLocation = dr[dc.ColumnName] as string;
                            if (location != currLocation)
                            {
                                location = currLocation;
                                ws.Cells[dataRow, col - 1].Value = location;
                                //
                                GrandTotal = 0;
                            }
                            else
                            {
                                dataRow--;
                            }
                        break;
                        case 4:// FIND WEEK INDEX TO POPULATE THE TOTAL BY WEEK
                            int colDis = 1;
                            foreach (DataRow drDis in disTable.Rows){
                                foreach(DataColumn dcDis in disTable.Columns){
                                    //
                                    int week = (int)dr[dc.ColumnName];
                                    int weekDis = (int)drDis[dcDis.ColumnName];
                                    //
                                    if (week == weekDis)
                                    {
                                        Col4Week = colDis;
                                    }
                                    
                                    //
                                    colDis++;
                                }
                            }
                        break;
                        case 5:
                            int total = Convert.ToInt32(dr[dc.ColumnName]);
                            GrandTotal += total;
                            //
                            ws.Cells[dataRow, col + Col4Week - added].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col + Col4Week - added].Style.Numberformat.Format = checkDataType(dc);
                        break;
                    }

                    col++;
                }
                // POPULATE GRAND TOTAL
                ws.Cells[dataRow, disColLimit + added].Value = GrandTotal;
                ws.Cells[dataRow, disColLimit + added].Style.Numberformat.Format = _decimal;
                //
                dataRow++;
            }
            // FINAL CLASS TOTAL
            WeekRepGetSupervisorGrandTotal(table, disTable, disColLimit, ref dataRow, ws, tempClassName, added);

            WeeklyRepGrandTotalFooter(table, disTable, ws, dataRow, disColLimit, added);
        }

        private void WeekRepGetSupervisorGrandTotal(DataTable table, DataTable disTable, int disColLimit, ref int dataRow, ExcelWorksheet ws, string className, int added)
        {
            int totalCol = 2;
            ws.Cells[dataRow, totalCol].Value = "TOTAL";
            using (var range = ws.Cells[dataRow, 2, dataRow, disColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 229, 241));
                range.Style.Font.Bold = true;
            }
            // COMPUTATION FOR TOTALITY OF CLASS PER LOCATION
            var groupRes = (from week in table.AsEnumerable()
                            group week by new { classN = week["ClassName"], weekIndx = week["WeekIn"] } into grp
                            select new
                            {
                                grpClass = grp.Key.classN,
                                grpWeek = grp.Key.weekIndx,
                                Sum = grp.Sum(o=> decimal.Parse(o["TotalAm"].ToString()))
                            }).ToList();
            //
            int GrandGrandTotal = 0;
            foreach(DataRow drDis in disTable.Rows){
                //
                foreach(DataColumn dcDis in disTable.Columns){
                    //
                    int weekIndex = (int)drDis[dcDis.ColumnName];
                    var search = groupRes.Where(o => (int)o.grpWeek == (int)weekIndex && (string)o.grpClass == (string)className).Select(o => o.Sum);
                    //
                    totalCol++;
                    foreach(var w in search){
                        GrandGrandTotal += (int)w;
                        ws.Cells[dataRow, totalCol].Value = (int)w;
                        ws.Cells[dataRow, totalCol].Style.Numberformat.Format = _decimal;
                    }
                    
                }
                
            }
            // FINAL TOTAL OF TOTALS
            ws.Cells[dataRow, totalCol + 1].Value = GrandGrandTotal;
            ws.Cells[dataRow, totalCol + 1].Style.Numberformat.Format = _decimal;
            //

            dataRow++;
        }

        private void WeeklyRepGrandTotalFooter(DataTable table, DataTable disTable, ExcelWorksheet ws, int dataRow, int disColLimit, int added)
        {
            using (var range = ws.Cells[dataRow, 1, dataRow, disColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }
            //
            ws.Cells[dataRow, 1].Value = "GRAND TOTAL";

            int colInc = 3;
            int TotalGrand = 0;
            //
            var GrandTotalperWeek = (from grand in table.AsEnumerable()
                                     group grand by grand["Weekin"] into grpGrand
                                     select new
                                     {
                                         Group = grpGrand.Key,
                                         Sum = grpGrand.Sum(o=> decimal.Parse(o["TotalAm"].ToString()))
                                     }).ToList();
            //
            foreach(DataRow drDis in disTable.Rows){
                //
                foreach(DataColumn dcDis in disTable.Columns){
                    //
                    int weekIndex = (int)drDis[dcDis.ColumnName];

                    var search = GrandTotalperWeek.Where(o=> (int)o.Group == (int) weekIndex).Select(o=> o.Sum);

                    foreach(var res in search){
                        ws.Cells[dataRow, colInc].Value = res;
                        ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
                        TotalGrand += (int)res;
                    }
                    colInc++;
                }
            }
            // finally ariel happen to me!
            ws.Cells[dataRow, colInc].Value = TotalGrand;
            ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
        }

        public void GenerateDailyReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 6;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 3;

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "KIOSK";
            ws.Cells[headerRow, col + 1].Value = "WEEK";
            ws.Column(1).Width = 30;
            ws.Column(2).Width = 10;

            // SET WEEK HEADER FORMAT
            List<string> weekdays = new List<string>();
            weekdays.Add("Sunday");
            weekdays.Add("Monday");
            weekdays.Add("Tuesday");
            weekdays.Add("Wednesday");
            weekdays.Add("Thursday");
            weekdays.Add("Friday");
            weekdays.Add("Saturday");
            int weekColLimit = weekdays.Count;

            // DECORATE HEADER LAYOUT
            using (var range = ws.Cells[headerRow, 1, headerRow, weekColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }

            // POPULATE WEEKDAYS IN HEADER COLUMN
            foreach(string day in weekdays){
                ws.Cells[headerRow, col + 2].Value = day;
                ws.Column(col + 2).Width = 15;
                col++;
            }
            ws.Cells[headerRow, col + 2].Value = "GRAND TOTAL";
            ws.Column(col + 2).Width = 15;

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, weekColLimit + added].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, weekColLimit + added].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, weekColLimit + added].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, weekColLimit + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, weekColLimit + added].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // POPULATING DATA TO ROWS
            string className = "";
            string tempClassName = "";
            string Supervisor = "";
            string visor = "";
            int weekIndex = 0;
            bool stepOnce = false;
            int WeekGrandTotal = 0;

            foreach(DataRow dr in table.Rows){
                //
                col = 1;
                className = "";
                visor = "";
                int Col4Day = 0;

                foreach(DataColumn dc in table.Columns){
                    //
                    switch(col){
                        case 1:
                            className = (string)dr[dc.ColumnName];
                            //
                            if(stepOnce){
                                if (className != tempClassName)
                                {
                                    DailyRepGetSupervisorGrandTotal(table, weekdays, weekColLimit, ref dataRow, ws, tempClassName, added);
                                }
                            }

                            tempClassName = className;
                            stepOnce = true;
                        break;
                        case 2:
                            visor = (string)dr[dc.ColumnName];
                            string full = className + "(" + visor + ")";

                            if(Supervisor != full){
                                Supervisor = full;

                                ws.Cells[dataRow, col - 1].Value = Supervisor;
                                ws.Cells[dataRow, col - 1].Style.Font.Bold = true;
                                //
                                WeekGrandTotal = 0;
                            }
                        break;
                        case 3:
                            int currWeekIndex = (int)dr[dc.ColumnName];
                            if (weekIndex != currWeekIndex)
                            {
                                weekIndex = currWeekIndex;
                                ws.Cells[dataRow, col - 1].Value = weekIndex;

                                WeekGrandTotal = 0;
                            }
                            else
                            {
                                dataRow--;
                            }
                        break;
                        case 4:
                        int dayIndex = 1;
                            foreach(string day in weekdays){
                                //
                                string dayWeek = (string)dr[dc.ColumnName];
                                if( dayWeek == day){
                                    Col4Day = dayIndex;
                                    break;
                                }
                                dayIndex++;
                            }
                        break;
                        case 5:
                            int total = Convert.ToInt32(dr[dc.ColumnName]);
                            WeekGrandTotal += total;

                            ws.Cells[dataRow, col + Col4Day - added].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col + Col4Day - added].Style.Numberformat.Format = _decimal;
                        break;
                    }
                    //// INCREMENTING COL
                    col++;
                }
                // POPULATE GRAND TOTAL
                ws.Cells[dataRow, weekColLimit + added].Value = WeekGrandTotal;
                ws.Cells[dataRow, weekColLimit + added].Style.Numberformat.Format = _decimal;
                //// INCREMENTING ROWS
                dataRow++;
            }
            // FINAL CLASS TOTAL
            DailyRepGetSupervisorGrandTotal(table, weekdays, weekColLimit, ref dataRow, ws, tempClassName, added);

            DailyRepGrandTotalFooter(table, weekdays, ws, dataRow, weekColLimit, added);
        }

        private void DailyRepGetSupervisorGrandTotal(DataTable table, List<string> weekdays, int disColLimit, ref int dataRow, ExcelWorksheet ws, string className, int added)
        {
            int totalCol = 2;
            ws.Cells[dataRow, totalCol].Value = "TOTAL";
            using (var range = ws.Cells[dataRow, 2, dataRow, disColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(219, 229, 241));
                range.Style.Font.Bold = true;
            }

            // COMPUTATION FOR TOTALITY OF CLASS PER LOCATION
            var groupRes = (from days in table.AsEnumerable()
                            group days by new { classN = days["ClassName"], weekS = days["DayIn"] } into grp
                            select new
                            {
                                grpClass = grp.Key.classN,
                                grpDays = grp.Key.weekS,
                                Sum = grp.Sum(o=> decimal.Parse(o["TotalAm"].ToString()))
                            }).ToList();
            //
            int GrandGrandTotal = 0;
            foreach(string day in weekdays){
                //
                var search = groupRes.Where(o => (string)o.grpClass == (string)className && (string)o.grpDays == (string)day).Select(o=> o.Sum);
                //
                totalCol++;
                foreach(var s in search){
                    GrandGrandTotal += (int)s;

                    ws.Cells[dataRow, totalCol].Value = (int)s;
                    ws.Cells[dataRow, totalCol].Style.Numberformat.Format = _decimal;
                }
            }
            // FINAL TOTAL OF TOTALS
            ws.Cells[dataRow, totalCol + 1].Value = GrandGrandTotal;
            ws.Cells[dataRow, totalCol + 1].Style.Numberformat.Format = _decimal;
            //
            dataRow++;
        }

        private void DailyRepGrandTotalFooter(DataTable table, List<string> weekdays, ExcelWorksheet ws, int dataRow, int disColLimit, int added)
        {
            using (var range = ws.Cells[dataRow, 1, dataRow, disColLimit + added])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }
            //
            ws.Cells[dataRow, 1].Value = "GRAND TOTAL";

            int colInc = 3;
            int TotalGrand = 0;
            //
            var GrandTotalPerDays = (from grand in table.AsEnumerable()
                                     group grand by grand["DayIn"] into grpGrand
                                     select new
                                     {
                                         Group = grpGrand.Key,
                                         Sum = grpGrand.Sum(o=> decimal.Parse(o["TotalAm"].ToString()))
                                     }).ToList();
            //
            foreach(string day in weekdays){
                //
                var search = GrandTotalPerDays.Where(o=> (string)o.Group == (string)day ).Select(o=> o.Sum);

                foreach (var res in search)
                {
                    ws.Cells[dataRow, colInc].Value = res;
                    ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
                    TotalGrand += (int)res;
                }
                colInc++;
            }
            // finally ariel happen to me!
            ws.Cells[dataRow, colInc].Value = TotalGrand;
            ws.Cells[dataRow, colInc].Style.Numberformat.Format = _decimal;
        }

        public void GenerateSalesReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 7;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 9;
            int TotalHeadCount = 2;

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "DATE";
            ws.Cells[headerRow, col + 1].Value = "TAGGING";
            ws.Cells[headerRow, col + 2].Value = "ID#";
            ws.Cells[headerRow, col + 3].Value = "KIOSK";
            ws.Cells[headerRow, col + 4].Value = "EXIST?";
            ws.Cells[headerRow, col + 5].Value = "YEAR";
            ws.Cells[headerRow, col + 6].Value = "MONTH";
            ws.Cells[headerRow, col + 7].Value = "WEEK";
            ws.Cells[headerRow, col + 8].Value = "SRP";

            // HEADER WIDTH
            ws.Column(1).Width = 15;
            ws.Column(2).Width = 10;
            ws.Column(3).Width = 10;
            ws.Column(4).Width = 20;
            ws.Column(5).Width = 10;
            ws.Column(6).Width = 10;
            ws.Column(7).Width = 10;
            ws.Column(8).Width = 15;

            // SET PRODUCT HEADER
            table.DefaultView.Sort = "ProdName";
            DataTable disTable = table.DefaultView.ToTable(true, "ProdName");
            int disColCount = disTable.Rows.Count;

            // DECORATE HEADER LAYOUT
            using (var range = ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }

            //  POPULATE PRODNAME IN HEADER COLUMN
            foreach(DataRow drDis in disTable.Rows){
                //
                foreach(DataColumn dcDis in disTable.Columns){
                    //
                    ws.Cells[headerRow, col + added].Value = drDis[dcDis.ColumnName];
                    ws.Cells[headerRow, col + added].Style.WrapText = true;
                    ws.Column(col + added).Width = 15;
                    col++;
                }
            }
            //
            ws.Cells[headerRow, col + added].Value = "TOTAL (QTY)";
            ws.Cells[headerRow, col + added].Style.WrapText = true;
            ws.Column(col + added).Width = 15;
            //
            //col++;
            //ws.Cells[headerRow, col + added].Value = "TOTAL (SALES)";
            //ws.Cells[headerRow, col + added].Style.WrapText = true;
            //ws.Column(col + added).Width = 15;

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, disColCount + added + TotalHeadCount - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // FREEZE PANE FORMAT
            ws.View.FreezePanes(8, added+1);

            // POPULATING DATA TO ROWS
            string dateSales = "";
            string ClassName = "";
            string KioskName = "";

            bool isDateTrue = false;
            bool isClassTrue = false;
            bool isKioskName = false;

            int GrandTotalQTY = 0;
            int GrandTotalSales = 0;
            //
            foreach(DataRow dr in table.Rows){
                //
                col = 1;
                int Col4ProdName = 0;
                int qty = 0;

                foreach(DataColumn dc in table.Columns){
                    //
                    switch(col){
                        case 1:// date column
                            string ds = (string)dr[dc.ColumnName];

                            if(ds == dateSales){
                                isDateTrue = true;
                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            } else {
                                isDateTrue = false;
                                dateSales = ds;

                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            }

                            
                        break;
                        case 2:// class name column
                            string cn = (string)dr[dc.ColumnName];

                            if(ClassName == cn){
                                isClassTrue = true;
                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            } else{
                                isClassTrue = false;
                                ClassName = cn;

                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            }

                            
                        break;
                        case 3:// kiosk id column
                            ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                        break;
                        case 4:// kiosk name column
                            string kn = (string)dr[dc.ColumnName];

                            if (kn == KioskName)
                            {
                                isKioskName = true;
                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            }
                            else
                            {
                                isKioskName = false;
                                KioskName = kn;

                                ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                                ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            }

                            if (isDateTrue && isClassTrue && isKioskName)
                            {
                                dataRow--;
                            }
                            else
                            {
                                GrandTotalQTY = 0;
                                GrandTotalSales = 0;
                            }
                            //
                            
                        break;
                        case 5:// kiosk existing or new column
                        ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                        ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                        break;
                        case 6:// year column
                            ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                        break;
                        case 7:// month column
                            ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                        break;
                        case 8:// week column
                            ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                        break;
                        case 9:// srp column
                            //
                            ws.Cells[dataRow, col].Value = dr[dc.ColumnName];
                            ws.Cells[dataRow, col].Style.Numberformat.Format = checkDataType(dc);
                            //
                        break;
                        case 10:// Product name column
                            //
                            int ProdNameIndx = 1;
                            foreach(DataRow drDis in disTable.Rows){
                                //
                                foreach(DataColumn dcDis in disTable.Columns){
                                    //
                                    string currProdname = (string)dr[dc.ColumnName];
                                    string Prodname = (string)drDis[dcDis.ColumnName];

                                    if(currProdname == Prodname){
                                        Col4ProdName = ProdNameIndx;
                                        break;
                                    }
                                    ProdNameIndx++;
                                }
                            }
                        break;
                        case 11:// Prod Qty

                            decimal qtyStr = (decimal)dr[dc.ColumnName];
                            qty = Convert.ToInt32(qtyStr);

                            GrandTotalQTY += qty;
                            ws.Cells[dataRow, Col4ProdName + added].Value = qty;
                            ws.Cells[dataRow, Col4ProdName + added].Style.Numberformat.Format = checkDataType(dc);

                            ws.Cells[dataRow, Col4ProdName + added].Style.Font.Bold = true;
                            ws.Cells[dataRow, Col4ProdName + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[dataRow, Col4ProdName + added].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        break;
                        case 12:// Unit Price

                        using (var range = ws.Cells[6, Col4ProdName + added])
                        {
                            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(255, 255, 0));
                            range.Style.Font.Color.SetColor(Color.Black);
                            range.Style.Font.Bold = true;

                        }
                            int price = Convert.ToInt32((decimal)dr[dc.ColumnName]);
                            GrandTotalSales += qty * price;

                            ws.Cells[6, Col4ProdName + added].Value = dr[dc.ColumnName];
                            ws.Cells[6, Col4ProdName + added].Style.Numberformat.Format = checkDataType(dc);

                            ws.Cells[6, Col4ProdName + added].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                            ws.Cells[6, Col4ProdName + added].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                            ws.Cells[6, Col4ProdName + added].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                            // DISPLAY GRAND TOTAL QTY
                            ws.Cells[dataRow, disColCount + added + TotalHeadCount-1].Value = GrandTotalQTY;
                            ws.Cells[dataRow, disColCount + added + TotalHeadCount-1].Style.Numberformat.Format = _int;
                            ws.Cells[dataRow, disColCount + added + TotalHeadCount-1].Style.Font.Bold = true;

                            // DISPLAY GRAND TOTAL SALES
                            ws.Cells[dataRow, 9].Value = GrandTotalSales;
                            ws.Cells[dataRow, 9].Style.Numberformat.Format = _decimal;
                            ws.Cells[dataRow, 9].Style.Font.Bold = true;
                        break;
                    }
                    col++;
                }
                //
                dataRow++;
            }
            // CLEAR EXCESS TEXT METHOD
            ws.Cells[dataRow, 1,dataRow, 4].Value = "";
            using (var range = ws.Cells[dataRow, 1, dataRow, disColCount + added + TotalHeadCount])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182, 211, 232));
                range.Style.Font.Color.SetColor(Color.Black);
                range.Style.Font.Bold = true;

            }
            
        }

        public void GenerateVolumeWeekReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 7;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 3;
            int TotalHeadCount = 2;

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "Class";
            ws.Cells[headerRow, col + 1].Value = "Kiosk";
            ws.Cells[headerRow, col + 2].Value = "Items";

            // HEADER WIDTH
            ws.Column(1).Width = 20;
            ws.Column(2).Width = 20;
            ws.Column(3).Width = 30;



            //GET COLUMN LIST OF WEEK INDEX
            table.DefaultView.Sort = "WeekIn";
            DataTable disTable = table.DefaultView.ToTable(true, "WeekIn");
            int disColLimit = disTable.Rows.Count;

            // DECORATE HEADER LAYOUT
            using (var range = ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
            }

            // FREEZE PANE FORMAT
            ws.View.FreezePanes(8, added + 1);

            //  POPULATE PRODNAME IN HEADER COLUMN
            foreach (DataRow drDis in disTable.Rows)
            {
                //
                foreach (DataColumn dcDis in disTable.Columns)
                {
                    //
                    ws.Cells[headerRow, col + added].Value = drDis[dcDis.ColumnName];
                    ws.Cells[headerRow, col + added].Style.WrapText = true;
                    ws.Column(col + added).Width = 10;
                    col++;
                }
            }
            //
            ws.Cells[headerRow, disColLimit + added + TotalHeadCount - 1].Value = "STOCK HELD";
            ws.Cells[headerRow, disColLimit + added + TotalHeadCount - 1].Style.WrapText = true;
            ws.Column(disColLimit + added + TotalHeadCount - 1).Width = 15;

            ws.Cells[headerRow, disColLimit + added + TotalHeadCount].Value = "GRAND TOTAL";
            ws.Cells[headerRow, disColLimit + added + TotalHeadCount].Style.WrapText = true;
            ws.Column(disColLimit + added + TotalHeadCount).Width = 15;

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // POPULATING DATA TO ROWS
            string ClassName = "";
            string KioskName = "";
            string ProdName = "";

            int GrandTotalQTY = 0;
            //
            foreach(DataRow dr in table.Rows){
                //
                col = 1;
                int Col4Week = 0;
                foreach(DataColumn dc in table.Columns){
                    //
                    switch(col){
                        case 1: // Class name column
                            string _classname = (string)dr[dc.ColumnName];

                            if(ClassName != _classname){
                                ws.Cells[dataRow, col].Value = _classname;
                                ClassName = _classname;
                            } 
                            break;
                        case 2: // Kiosk name column
                            string _kioskname = (string)dr[dc.ColumnName];

                            if(KioskName != _kioskname){
                                ws.Cells[dataRow, col].Value = _kioskname;
                                KioskName = _kioskname;
                            }
                            break;
                        case 3: // prodname column
                            string _prodname = (string)dr[dc.ColumnName];
                            if (ProdName != _prodname)
                            {
                                ws.Cells[dataRow, col].Value = _prodname;
                                ProdName = _prodname;
                                GrandTotalQTY = 0;
                            }
                            else
                            {
                                dataRow--;
                            }
                            break;
                        case 4: // week index matcher maker
                            int WeekColMatch = 1;
                            //
                            foreach (DataRow drDis in disTable.Rows)
                            {
                                foreach (DataColumn dcDis in disTable.Columns)
                                {
                                    int week = (int)dr[dc.ColumnName];
                                    int weekDis = (int)drDis[dcDis.ColumnName];
                                    //
                                    if (week == weekDis)
                                    {
                                        Col4Week = WeekColMatch;
                                    }
                                    //
                                    WeekColMatch++;
                                }
                            }
                            break;
                        case 5: // Product Quantity column
                            Int64 _quant = (Int64)dr[dc.ColumnName];
                            GrandTotalQTY += Convert.ToInt32(_quant);

                            ws.Cells[dataRow, Col4Week + added].Value = _quant;
                            ws.Cells[dataRow, Col4Week + added].Style.Numberformat.Format = _int;

                            ws.Cells[dataRow, Col4Week + added].Style.Font.Bold = true;
                            ws.Cells[dataRow, Col4Week + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[dataRow, Col4Week + added].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            break;
                        case 6:
                            Int64 _stocks = (Int64)dr[dc.ColumnName];

                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount - 1].Value = _stocks;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount - 1].Style.Numberformat.Format = _int;

                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount - 1].Style.Font.Bold = true;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount - 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            // DISPLAY GRAND TOTAL QTY
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Value = GrandTotalQTY;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Style.Numberformat.Format = _int;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Style.Font.Bold = true;

                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Style.Font.Bold = true;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            ws.Cells[dataRow, disColLimit + added + TotalHeadCount].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            break;
                    }
                    //
                    col++;
                }
                dataRow++;
            }

            using (var range = ws.Cells[dataRow, 1, dataRow, disColLimit + added + TotalHeadCount])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182, 211, 232));
                range.Style.Font.Color.SetColor(Color.Black);
                range.Style.Font.Bold = true;

            }
        }

        public void GenereateFootTrafficReport(DataTable table, ref ExcelPackage package, string fName)
        {
            ExcelWorksheet ws = package.Workbook.Worksheets.Add(fName);
            int headerRow = 7;
            int dataRow = headerRow + 1;
            int col = 1;
            int added = 2;
            int TotalHeadCount = 0;

            // HEADER FORMAT
            ws.Cells[headerRow, col].Value = "BRANCH";
            ws.Cells[headerRow, col + 1].Value = "TOTAL";

            // HEADER WIDTH
            ws.Column(1).Width = 40;
            ws.Column(2).Width = 15;

            //GET COLUMN LIST OF WEEK INDEX
            table.DefaultView.Sort = "WeekIn";
            DataTable disTable = table.DefaultView.ToTable(true, "WeekIn");
            int disColLimit = disTable.Rows.Count;

            // DECORATE HEADER LAYOUT
            using (var range = ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount])
            {
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                range.Style.Font.Color.SetColor(Color.White);
                range.Style.Font.Italic = true;
                range.Style.Font.Bold = true;
                //range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            }

            // HEADER BORDER LINE
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.Border.Right.Style = ExcelBorderStyle.Thin;

            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[headerRow, 1, headerRow, disColLimit + added + TotalHeadCount].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            //  POPULATE WEEK IN HEADER COLUMN
            foreach (DataRow drDis in disTable.Rows)
            {
                foreach (DataColumn dcDis in disTable.Columns)
                {
                    ws.Cells[headerRow, col + added].Value = "WEEK "+ drDis[dcDis.ColumnName];
                    ws.Cells[headerRow, col + added].Style.WrapText = true;
                    ws.Column(col + added).Width = 10;
                    col++;
                }
            }

            // FREEZE PANE FORMAT
            ws.View.FreezePanes(8, added + 1);

            // HEADER WIDTH SETTINGS
            ws.Row(headerRow).Height = 35;

            // POPULATING DATA TO ROWS
            string ClassName = "";
            string KioskName = "";
            int GrandTotalQTY = 0;

            foreach(DataRow dr in table.Rows){
                col = 1;
                int Col4Week = 0;
                foreach(DataColumn dc in table.Columns){
                    //
                    switch (col)
                    {
                        case 1: // Class name column
                            string _classname = (string)dr[dc.ColumnName];

                            if(ClassName != _classname){
                                ws.Cells[dataRow, col].Value = _classname;
                                ws.Cells[dataRow, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                ClassName = _classname;
                                //
                                using (var range = ws.Cells[dataRow, 1, dataRow, disColLimit + added + TotalHeadCount])
                                {
                                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(182, 211, 232));
                                    range.Style.Font.Bold = true;

                                }
                                //
                                dataRow++;
                            }
                            break;
                        case 2: // Kiosk name column
                            string _kioskname = (string)dr[dc.ColumnName];
                            if (KioskName != _kioskname)
                            {
                                ws.Cells[dataRow, col - 1].Value = _kioskname;
                                KioskName = _kioskname;
                                GrandTotalQTY = 0;
                            }
                            else
                            {
                                dataRow--;
                            }
                            break;
                        case 3: // week index matcher maker
                            int WeekColMatch = 1;
                            //
                            foreach (DataRow drDis in disTable.Rows)
                            {
                                foreach (DataColumn dcDis in disTable.Columns)
                                {
                                    int week = (int)dr[dc.ColumnName];
                                    int weekDis = (int)drDis[dcDis.ColumnName];
                                    //
                                    if (week == weekDis)
                                    {
                                        Col4Week = WeekColMatch;
                                    }
                                    //
                                    WeekColMatch++;
                                }
                            }
                            break;
                        case 4:
                            decimal _counter = (decimal)dr[dc.ColumnName];
                            GrandTotalQTY += (int)_counter;

                            ws.Cells[dataRow, Col4Week + added].Value = _counter;
                            ws.Cells[dataRow, Col4Week + added].Style.Numberformat.Format = _decimal;
                            ws.Cells[dataRow, Col4Week + added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            ws.Cells[dataRow, added].Value = GrandTotalQTY;
                            ws.Cells[dataRow, added].Style.Numberformat.Format = _decimal;
                            ws.Cells[dataRow, added].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                            break;
                    }
                    ///
                    col++;
                }
                dataRow++;
            }

            ///
        }

        public string checkDataType(DataColumn dc)
        {
            var format = "";

            if (dc.DataType == typeof(int) || dc.DataType == typeof(Int16) || dc.DataType == typeof(Int32) || dc.DataType == typeof(Int64)
               || dc.DataType == typeof(uint) || dc.DataType == typeof(UInt16) || dc.DataType == typeof(UInt32) || dc.DataType == typeof(UInt64))
            {
                format = _int;
            }
            else if (dc.DataType == typeof(decimal) || dc.DataType == typeof(double) || dc.DataType == typeof(Decimal) || dc.DataType == typeof(Double))
            {
                format = _decimal;
            }
            else if (dc.DataType == typeof(DateTime))
            {
                format = _datetime;
            }

            return format;
        }
    }

}