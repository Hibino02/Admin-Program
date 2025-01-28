using Admin_Program.SupplyManagement.ObjectClass;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Admin_Program.SupplyManagement.BusinessClass
{
    class SFPManage
    {
        private static List<SupplyForPacking> sfp = SupplyForPacking.GetAllSupplyForPacking() ?? new List<SupplyForPacking>();
        private static List<SupplyBalance> sb = SupplyBalance.GetAllSupplyBalanceList();
        public static bool SFPCheckAndCreate(string[] files)
        {
            foreach(string file in files)
            {
                if (File.Exists(file))
                {
                    using (var workbook = new XLWorkbook(file))
                    {
                        // Access the first worksheet
                        var worksheet = workbook.Worksheets.FirstOrDefault();
                        if (worksheet != null)
                        {
                            // Read the value of cell D4
                            string cellInv = worksheet.Cell("D4").GetValue<string>();

                            bool matchFound = sfp.Any(inv => inv.InvNum == cellInv);
                            if (matchFound)
                            {
                                continue;
                            }
                            ExtrackAndCreate(file, cellInv);
                        }
                    }
                }
            }
            return true;
        }
        private static void ExtrackAndCreate(string f,string inv)
        {
            var specificKeywords = new List<string> { "TOKIN 1", "TOKIN 2", "TOKIN 3", "TOKIN 4", "TOKIN 1W", "TOKIN 2W", "TOKIN 3W", "TOKIN 4W" };
            string dynamicPattern = @"\d+\)\s+(?<Keyword>" + string.Join("|", specificKeywords.Select(Regex.Escape)) + @")\s+:\s+([\d*]+)\s*CMS,\s*G/W:\s*([\d.]+)\s*KGS\.";
            string totalPattern = @"TOTAL\s+\d+\s+PALLET\(S\)";
            // StringBuilder for concatenated result
            var resultBuilder = new StringBuilder();

            using (var workbook = new XLWorkbook(f))
            {
                var worksheet = workbook.Worksheets.FirstOrDefault();
                if(worksheet != null)
                {
                    foreach(var row in worksheet.RowsUsed())
                    {
                        // Assuming data is in the first column (adjust if necessary)
                        string cellValue = row.Cell(1).GetValue<string>();
                        // Check if the line matches the TOTAL pattern
                        if(Regex.IsMatch(cellValue, totalPattern, RegexOptions.IgnoreCase))
                        {
                            break;
                        }
                        var match = Regex.Match(cellValue, dynamicPattern);
                        if (match.Success)
                        {
                            string matchedKeyword = match.Groups["Keyword"].Value;
                            if (!string.IsNullOrEmpty(matchedKeyword))
                            {
                                switch (matchedKeyword)
                                {
                                    case "TOKIN 1":
                                        UpdateSupplyBalance(new List<int> { 30, 31 }, 1);
                                        break;
                                    case "TOKIN 2":
                                        UpdateSupplyBalance(new List<int> { 32, 36 }, 1);
                                        break;
                                    case "TOKIN 3":
                                        UpdateSupplyBalance(new List<int> { 28, 29 }, 1);
                                        break;
                                    case "TOKIN 4":
                                        UpdateSupplyBalance(new List<int> { 34, 35 }, 1);
                                        break;
                                    case "TOKIN 1W":
                                        UpdateSupplyBalance(new List<int> { 7, 8 }, 1);
                                        break;
                                    case "TOKIN 2W":
                                        UpdateSupplyBalance(new List<int> { 9, 10 }, 1);
                                        break;
                                    case "TOKIN 3W":
                                        UpdateSupplyBalance(new List<int> { 11, 12 }, 1);
                                        break;
                                    case "TOKIN 4W":
                                        UpdateSupplyBalance(new List<int> { 13, 14 }, 1);
                                        break;
                                }
                                sb = SupplyBalance.GetAllSupplyBalanceList();

                            }
                            string entireMatch = match.Value;
                            // Append the original line to the result
                            resultBuilder.AppendLine(cellValue);
                        }
                    }
                }
            }
            string result = resultBuilder.ToString();
            SupplyForPacking newSFP = new SupplyForPacking(DateTime.Now, inv, result);
            newSFP.Create();
            sfp = SupplyForPacking.GetAllSupplyForPacking();
        }
        private static void UpdateSupplyBalance(List<int> supplyIds, int decrementValue)
        {
            foreach(var supplyId in supplyIds)
            {
                var newestBalance = sb.Where(s => s.Supply.ID == supplyId)
                .OrderByDescending(s => s.UpdateDate).FirstOrDefault();
                if(newestBalance != null)
                {
                    var updateBalance = newestBalance.Balance - decrementValue;
                    if (newestBalance.UpdateDate.Date != DateTime.Now.Date)
                    {
                        //Create balance if it not current date
                        var updateSupplyBalance = new SupplyBalance(
                        newestBalance.Supply, updateBalance, DateTime.Now.Date,
                        GlobalVariable.Global.userName, GlobalVariable.Global.warehouseID);
                        updateSupplyBalance.Create();
                    }
                    else
                    {
                        //Edit balance if it has current date
                        var editSupplyBalance = new SupplyBalance(
                            newestBalance.ID, newestBalance.Supply, updateBalance, DateTime.Now.Date,
                        GlobalVariable.Global.userName);
                        editSupplyBalance.Change();
                    }
                }
            }
        }
    }
}
