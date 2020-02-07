using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using static demo1.CodeLogic.Enums.Enums;
namespace demo1.CodeLogic.Customs
{
    public static class CUtils
    {
        public static MvcHtmlString RenderOderStatus(int status, string addCss = "white d-block")
        {
            var dic = Utils.EnumToDictionary<OrderStatus>();
            TagBuilder tag = new TagBuilder("span");
            tag.MergeAttribute("value", status.ToString());
            switch (status)
            {
                case (int)OrderStatus.Receive:
                    tag.SetInnerText(dic[(int)OrderStatus.Receive]);
                    tag.MergeAttribute("class", "label label-default " + addCss);
                    break;
                case (int)OrderStatus.Delivery:
                    tag.SetInnerText(dic[(int)OrderStatus.Delivery]);
                    tag.MergeAttribute("class", "label label-warning " + addCss);
                    break;
                case (int)OrderStatus.IRVReturn:
                    tag.SetInnerText(dic[(int)OrderStatus.IRVReturn]);
                    tag.MergeAttribute("class", "label label-success " + addCss);
                    break;
                case (int)OrderStatus.CollectVouchers:
                    tag.SetInnerText(dic[(int)OrderStatus.CollectVouchers]);
                    tag.MergeAttribute("class", "label label-primary " + addCss);
                    break;
                //case (int)OrderStatus.AccountingDept:
                //    tag.SetInnerText(dic[(int)OrderStatus.AccountingDept]);
                //    tag.MergeAttribute("class", "label label-violet " + addCss);
                //    break;
                //case (int)OrderStatus.AccountingDeptConfirm:
                //    tag.SetInnerText(dic[(int)OrderStatus.AccountingDeptConfirm]);
                //    tag.MergeAttribute("class", "label label-blueviolet " + addCss);
                //    break;
                //case (int)OrderStatus.Payed:
                //    tag.SetInnerText(dic[(int)OrderStatus.Payed]);
                //    tag.MergeAttribute("class", "label label-success " + addCss);
                //    break;
                //case (int)OrderStatus.PayedConfirm:
                //    tag.SetInnerText(dic[(int)OrderStatus.PayedConfirm]);
                //    tag.MergeAttribute("class", "label label-darksuccess " + addCss);
                //    break;
                //case (int)OrderStatus.Execellent:
                //    tag.SetInnerText(dic[(int)LevelCourse.Execellent]);
                //    tag.MergeAttribute("class", "label label-purple  " + addCss);
                //    break;
                default:
                    break;
            }

            return new MvcHtmlString(tag.ToString());
        }

        public static bool CheckUtf8(string value)
        {
            var asciiBytesCount = Encoding.ASCII.GetByteCount(value);
            var unicodBytesCount = Encoding.UTF8.GetByteCount(value);
            return asciiBytesCount != unicodBytesCount;
        }

        public static string ImageToBase64(string path)
        {
            if(path == null)
            {
                return string.Empty;
            }
            byte[] data = File.ReadAllBytes(path);
            // ... Convert byte array to Base64 string.
            string result = Convert.ToBase64String(data);
            return result;
        }

        public static MvcHtmlString RenderACDStatus(int status, string addCss = "white d-block")
        {
            var dic = Utils.EnumToDictionary<AccountingDeptStatus>();
            TagBuilder tag = new TagBuilder("span");
            tag.MergeAttribute("value", status.ToString());
            switch (status)
            {
                case (int)AccountingDeptStatus.Receive:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Receive]);
                    tag.MergeAttribute("class", "label label-success " + addCss);
                    break;
                case (int)AccountingDeptStatus.Reject:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Reject]);
                    tag.MergeAttribute("class", "label label-danger " + addCss);
                    break;
                case (int)OrderStatus.IRVReturn:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Confirm]);
                    tag.MergeAttribute("class", "label label-darksuccess " + addCss);
                    break;
                default:
                    break;
            }

            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString RenderBillStatus(int status, string addCss = "white d-block")
        {
            var dic = Utils.EnumToDictionary<BillStatus>();
            TagBuilder tag = new TagBuilder("span");
            tag.MergeAttribute("value", status.ToString());
            switch (status)
            {
                case (int)BillStatus.NotPay:
                    tag.SetInnerText(dic[(int)BillStatus.NotPay]);
                    tag.MergeAttribute("class", "label label-primary " + addCss);
                    break;
                case (int)BillStatus.Payed:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Reject]);
                    tag.MergeAttribute("class", "label label-success " + addCss);
                    break;
                case (int)OrderStatus.IRVReturn:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Confirm]);
                    tag.MergeAttribute("class", "label label-darksuccess " + addCss);
                    break;
                default:
                    break;
            }

            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString RenderOrderType(int status, string addCss = "white d-block")
        {
            var dic = Utils.EnumToDictionary<OrderType>();
            TagBuilder tag = new TagBuilder("span");
            tag.MergeAttribute("value", status.ToString());
            switch (status)
            {
                case (int)OrderType.Order:
                    tag.SetInnerText(dic[(int)OrderType.Order]);
                    tag.MergeAttribute("class", "label label-warning " + addCss);
                    break;
                case (int)OrderType.Amount:
                    tag.SetInnerText(dic[(int)AccountingDeptStatus.Reject]);
                    tag.MergeAttribute("class", "label label-primary " + addCss);
                    break;

                default:
                    break;
            }

            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString RenderQuater(int status, string addCss = "white d-block")
        {
            var dic = Utils.EnumToDictionary<Quater>();
            TagBuilder tag = new TagBuilder("span");
            tag.MergeAttribute("value", status.ToString());
            switch (status)
            {
                case (int)Quater.Quater1:
                    tag.SetInnerText(dic[(int)Quater.Quater1]);
                    tag.MergeAttribute("class", "label label-warning " + addCss);
                    break;
                case (int)Quater.Quater2:
                    tag.SetInnerText(dic[(int)Quater.Quater2]);
                    tag.MergeAttribute("class", "label label-primary " + addCss);
                    break;
                case (int)Quater.Quater3:
                    tag.SetInnerText(dic[(int)Quater.Quater3]);
                    tag.MergeAttribute("class", "label label-success " + addCss);
                    break;
                case (int)Quater.Quater4:
                    tag.SetInnerText(dic[(int)Quater.Quater4]);
                    tag.MergeAttribute("class", "label label-danger " + addCss);
                    break;
                case (int)Quater.All:
                    tag.SetInnerText(dic[(int)Quater.All]);
                    tag.MergeAttribute("class", "label label-violet " + addCss);
                    break;
                default:
                    break;
            }

            return new MvcHtmlString(tag.ToString());
        }
        public static string GetTitleByView(string view)
        {
            var title = "Danh sách đơn ";
            switch (view)
            {
                case "Receive":
                    title += "đặt hàng";
                    break;
                case "Delivery":
                    title += "giao hàng";
                    break;
                case "IRVReturn":
                    title += "đã trả phiếu nhập kho";
                    break;
                case "CollectVouchers":
                    title += " đã thu thập chứng từ";
                    break;
                case "AccountingDept":
                    title += "đã chuyển đến phòng kế toán";
                    break;
                case "Payed":
                    title += "đã thanh toán hóa đơn";
                    break;
                default:
                    break;
            }
            return title;
        }

        public static string GetValue(this Dictionary<int, string> dic, int key)
        {
            if (dic.ContainsKey(key))
                return dic[key];
            return "Không xác định";
        }
        public static bool IsBase64String(this string s)
        {
            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,2}$", RegexOptions.None);

        }
        public static string ConvertMoney(decimal? money)
        {
            return money.HasValue ? money.Value.ToString("N0", new CultureInfo("en-US")) : string.Empty;
        }
        public static string GetLinkByStatus(int status, string controller)
        {
            var link = "#";
            switch (status)
            {
                case (int)OrderStatus.Receive:
                    link = string.Format("/{0}?ListStatus={1}&ViewName={2}", controller, (int)OrderStatus.Receive, "Receive");
                    break;
                case (int)OrderStatus.Delivery:
                    link = string.Format("/{0}?ListStatus={1}&ViewName={2}", controller, (int)OrderStatus.Delivery, "Delivery");
                    break;
                case (int)OrderStatus.IRVReturn:
                    link = string.Format("/{0}?ListStatus={1}&ViewName={2}", controller, (int)OrderStatus.IRVReturn, "IRVReturn");
                    break;
                case (int)OrderStatus.CollectVouchers:
                    link = string.Format("/{0}?ListStatus={1}&ViewName={2}", controller, (int)OrderStatus.CollectVouchers, "CollectVouchers");
                    break;
                default:
                    break;
            }
            return link;
        }
        public static string GetListStatus(int status)
        {
            var list = "0";
            switch (status)
            {
                case (int)OrderStatus.Receive:
                    list = string.Format("{0}", (int)OrderStatus.Receive);
                    break;
                case (int)OrderStatus.Delivery:
                    list = string.Format("{0}", (int)OrderStatus.Delivery);
                    break;
                case (int)OrderStatus.IRVReturn:
                    list = string.Format("{0}", (int)OrderStatus.IRVReturn);
                    break;
                case (int)OrderStatus.CollectVouchers:
                    list = string.Format("{0}", "CollectVouchers", (int)OrderStatus.CollectVouchers);
                    break;
                //case (int)OrderStatus.AccountingDept:
                //case (int)OrderStatus.AccountingDeptConfirm:
                //    list = string.Format("{0},{1}", (int)OrderStatus.AccountingDept, (int)OrderStatus.AccountingDeptConfirm);
                //    break;
                //case (int)OrderStatus.Payed:
                //case (int)OrderStatus.PayedConfirm:
                //    list = string.Format("{0},{1}", (int)OrderStatus.Payed, (int)OrderStatus.PayedConfirm);
                //    break;
                default:
                    break;
            }
            return list;
        }
        public static int GetOverDay(DateTime realDay, DateTime oldDay)
        {
            try
            {
                var overDay = 0;
                overDay = (realDay.Date - oldDay.Date).Days;
                return overDay;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return 0;
            }

        }
        public static bool ExportToPdf(DataTable data, string template, out string filePdf, string header, string footer, float[] widths)
        {
            filePdf = string.Empty;
            try
            {
                Document document = new Document();
                filePdf = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Templates\" + template);
                //File.Delete(filePdf);
                //File.Create(filePdf);
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePdf, FileMode.Truncate));
                if (document.IsOpen())
                {
                    document.Close();
                }
                document.Open();
                PdfPTable table = new PdfPTable(data.Columns.Count);
                table.TotalWidth = 500f;
                table.LockedWidth = true;
                if (!Equals(null, widths))
                    table.SetWidths(widths);

                string fonts = Path.Combine(AppDomain.CurrentDomain.BaseDirectory) + @"\Assets\fonts\arialbd.ttf";
                BaseFont bf = BaseFont.CreateFont(fonts, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 8);
                //header
                if (!header.IsNullOrEmpty())
                {
                    PdfPCell headerCell = new PdfPCell(new Phrase(header, new Font(bf, 14)));
                    headerCell.Colspan = data.Columns.Count;
                    headerCell.Border = 0;
                    headerCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    headerCell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    headerCell.PaddingBottom = 20;
                    table.AddCell(headerCell);
                }
                //column
                for (int k = 0; k < data.Columns.Count; k++)
                {

                    PdfPCell cell = new PdfPCell(new Phrase(data.Columns[k].ColumnName, font));
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(188, 223, 241);
                    cell.Padding = 5;
                    table.AddCell(cell);
                }
                // row
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        var caption = data.Columns[i].Caption;

                        PdfPCell cell = new PdfPCell(new Phrase(data.Rows[i][j].ToString(), font));
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.VerticalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.Padding = 5;
                        cell.NoWrap = true;
                        table.AddCell(cell);
                    }
                }
                // footer
                if (!footer.IsNullOrEmpty())
                {
                    PdfPCell footerCell = new PdfPCell(new Phrase(footer, font));
                    footerCell.Colspan = data.Columns.Count;
                    footerCell.Border = 0;
                    footerCell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    footerCell.VerticalAlignment = PdfPCell.ALIGN_LEFT;
                    footerCell.PaddingTop = 10;
                    table.AddCell(footerCell);
                }
                document.Add(table);
                document.Close();
                return true;
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                return false;
            }
        }
        public static bool ExportExcel<T>(out XLWorkbook MyWorkBook, List<T> itemSheets, Dictionary<string, string> headers, bool isshowheader, string template, int rowstart, int colstart, List<ItemExcel> itemexcels)
        {
            if (File.Exists(template))
                MyWorkBook = new XLWorkbook(template);
            else
                MyWorkBook = new XLWorkbook();
            var MyWorkSheet = MyWorkBook.Worksheet(1);
            try
            {
                int index = 0;
                int sheet = 1;
                if (isshowheader)
                {
                    foreach (var item in headers)
                    {
                        MyWorkSheet.Cell(rowstart, colstart + index).Style.Font.Bold = true;
                        MyWorkSheet.Cell(rowstart, colstart + index).Value = item.Value;
                        MyWorkSheet.Cell(rowstart, colstart + index).Style.Alignment.WrapText = true;
                        index++;
                    }
                }
                index = 1;
                var row = MyWorkSheet.Row(rowstart + 1);
                var totalItems = itemSheets.Count;
                row.InsertRowsBelow(itemSheets.Count);
                foreach (var item in itemSheets)
                {
                    var values = item.KeyValues();
                    int col = 0;
                    foreach (var it in headers)
                    {
                        var value = values.Contains(it.Key) ? values[it.Key] : "";
                        if (col == 0)
                        {
                            MyWorkSheet.Cell(rowstart + index, colstart + col).Value = index.ToString();
                            col++;
                            continue;
                        }
                        if (value is DateTime || value is DateTime?)
                        {
                            MyWorkSheet.Cell(rowstart + index, colstart + col).DataType = XLDataType.Text;
                            MyWorkSheet.Cell(rowstart + index, colstart + col).SetValue<string>(Utils.DateToString((DateTime)value, "dd-MM-yyyy"));
                        }
                        else
                        {
                            MyWorkSheet.Cell(rowstart + index, colstart + col).Value = Convert.ToString(value);
                        }
                        MyWorkSheet.Cell(rowstart + index, colstart + col).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        MyWorkSheet.Cell(rowstart + index, colstart + col).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        MyWorkSheet.Cell(rowstart + index, colstart + col).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        MyWorkSheet.Cell(rowstart + index, colstart + col).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        col++;
                    }
                    index++;
                }
                if (!Equals(itemexcels, null))
                {
                    foreach (var itexcel in itemexcels)
                    {
                        MyWorkSheet.Cell(itexcel.Row, itexcel.Col).DataType = XLDataType.Text;
                        MyWorkSheet.Cell(itexcel.Row, itexcel.Col).Value = itexcel.Value;
                    }
                }
                sheet++;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
    public class ItemExcel
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
    }
}