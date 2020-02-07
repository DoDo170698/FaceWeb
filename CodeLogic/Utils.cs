using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using System.Web.WebPages;

namespace demo1.CodeLogic
{
    public static class Utils
    {
        /// <summary>
        /// JSON Serialization
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }
        /// <summary>
        /// JSON Deserialization
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            var ser = new DataContractJsonSerializer(typeof(T));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
        public static void UploadImageWithBase64(string base64Image, string PathServer, string PathFile)
        {
            try
            {
                byte[] data = Convert.FromBase64String(base64Image.Split(',')[1]);
                MemoryStream ms = new MemoryStream(data);
                FileStream fs = new FileStream(PathServer + PathFile, FileMode.Create, System.IO.FileAccess.Write);
                ms.CopyTo(fs);
                fs.Close();
            }
            catch(Exception e)
            {
                var ex = e.Message;
                throw;
            }
        }

        public static DateTime? StringToDateTime(this string datetime, char dateSpliter = '-', char timeSpliter = ':', char millisecondSpliter = ',')
        {
            try
            {
                var dateNow = DateTime.Now;
                datetime = datetime.Trim();
                datetime = datetime.Replace("  ", " ");
                string[] body = datetime.Split(' ');
                int year = dateNow.Year;
                int month = dateNow.Month;
                int day = dateNow.Day;
                if (datetime.Contains(dateSpliter))
                {
                    string[] date = body[0].Split(dateSpliter);
                    year = date[2].AsInt();
                    month = date[1].AsInt();
                    day = date[0].AsInt();
                }
                int hour = 0, minute = 0, second = 0, millisecond = 0;
                if (body.Length == 2)
                {
                    string[] tpart = body[1].Split(millisecondSpliter);
                    string[] time = tpart[0].Split(timeSpliter);
                    hour = time[0].AsInt();
                    minute = time[1].AsInt();
                    if (time.Length == 3) second = time[2].AsInt();
                    if (tpart.Length == 2) millisecond = tpart[1].AsInt();
                }
                else if(body.Length == 1 && !datetime.Contains(dateSpliter))
                {
                    string[] tpart = body[0].Split(millisecondSpliter);
                    string[] time = tpart[0].Split(timeSpliter);
                    hour = time[0].AsInt();
                    minute = time[1].AsInt();
                    if (time.Length == 3) second = time[2].AsInt();
                    if (tpart.Length == 2) millisecond = tpart[1].AsInt();
                }
                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            catch
            {
                return null;
            }
        }
        public static bool IsDateTime(string txtDate)
        {
            //string[] formats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
            //         "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
            //         "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
            //         "M/d/yyyy h:mm", "M/d/yyyy h:mm",
            //         "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm", "dd-MM-yyyy HH:mm"};
            //string[] dateStrings = {"5/1/2009 6:32 PM", "05/01/2009 6:32:05 PM",
            //              "5/1/2009 6:32:00", "05/01/2009 06:32",
            //              "05/01/2009 06:32:00 PM", "05/01/2009 06:32:00"};
            //DateTime dateValue;

            //if (DateTime.TryParseExact(txtDate, formats,
            //                               new CultureInfo("en-US"),
            //                               DateTimeStyles.None,
            //                               out dateValue))
            //    return true;
            //else
            //    return false;
            DateTime tempDate;
            return DateTime.TryParse(txtDate, out tempDate);
        }

        public static bool IsDateTime2(string txtDate)
        {
            string[] dateFormats = { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(txtDate, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out tempDate);
            if (validDate)
                return true;
            else
                return false;
        }
        public static string IsActive(this HtmlHelper html, string controller = null, string action = null, string url = null)
        {
            const string cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["Controller"];
            var currentUrl = (string)html.ViewContext.RouteData.Values["url"];
            if (string.IsNullOrEmpty(controller))
            {
                controller = currentController;
            }
            else if (string.IsNullOrEmpty(action))
            {
                action = currentAction;
            }
            else if (string.IsNullOrEmpty(url))
            {
                url = currentUrl;
            }
            return ((controller == currentController && action == currentAction && url == currentUrl) ? cssClass : string.Empty);
        }
        public static string MoneyToText(string value1)
        {
            Func<string, string> numToText = delegate (string num)
            {
                if (num == "0")
                {
                    return "không";
                }
                else if (num == "1")
                {
                    return "một";
                }
                else if (num == "2")
                {
                    return "hai";
                }
                else if (num == "3")
                {
                    return "ba";
                }
                else if (num == "4")
                {
                    return "bốn";
                }
                else if (num == "5")
                {
                    return "năm";
                }
                else if (num == "6")
                {
                    return "sáu";
                }
                else if (num == "7")
                {
                    return "bảy";
                }
                else if (num == "8")
                {
                    return "tám";
                }
                else if (num == "9")
                {
                    return "chín";
                }
                else if (num == "10")
                {
                    return "mười";
                }
                return "";
            };

            Func<string, string> docDonVi = null;
            docDonVi = (string value) =>
            {
                if (value.Length == 1)
                {
                    return numToText(value);
                }
                else if (value.Length == 2)
                {
                    if (value == "10")
                    {
                        return numToText(value);
                    }
                    else
                    {
                        if (value[0] == '1')
                        {
                            return "mười " + numToText(value[1].ToString());
                        }
                        var txt = numToText(value[0].ToString()) + " mươi";
                        if (value[1] != '0')
                        {
                            if (value[1] == '1')
                            {
                                return txt + " mốt";
                            }
                            return txt + " " + numToText(value[1].ToString());
                        }
                        return txt;
                    }
                }
                else
                {
                    var txt = "";
                    txt = numToText(value[0].ToString()) + " trăm";
                    if (value[1] == '0')
                    {
                        if (value[2] != '0')
                        {
                            txt += " linh " + numToText(value[2].ToString());
                        }
                    }
                    else
                    {
                        txt += " " + docDonVi(value[1].ToString() + value[2].ToString());
                    }
                    return txt;
                }
            };

            Func<string, int, List<string>> getDonvi = (string value, int boi) =>
            {
                List<string> donvi = new List<string>();
                var temp = "";
                for (var i = value.Length; i > 0; i--)
                {
                    var e = value[i - 1];
                    temp = e + temp;
                    if ((value.Length - i + 1) % boi == 0 || i == 1)
                    {
                        donvi.Insert(0, temp);
                        temp = "";
                    }
                }
                return donvi;
            };

            value1 = !string.IsNullOrWhiteSpace(value1) ? value1 : "0";
            value1 += "";
            var txt_return = "";

            var donvi1 = getDonvi(value1, 3);
            var hangTy = getDonvi(value1, 9);

            for (var i = 0; i < donvi1.Count; i++)
            {
                var txt1 = docDonVi(donvi1[i]);
                switch (donvi1.Count - i - 1)
                {
                    case 0:
                        break;
                    case 1:
                        txt1 += " nghìn";
                        break;
                    case 2:
                        txt1 += " triệu";
                        break;
                    case 3:
                        txt1 += " tỷ";
                        break;
                    case 4:
                        txt1 += " nghìn tỷ";
                        break;
                    case 5:
                        txt1 += " triệu tỷ";
                        break;
                    default:
                        txt1 += " tỷ tỷ";
                        break;
                }
                txt_return += " " + txt1;
                var conlai = donvi1.Skip(i + 1).Take(donvi1.Count - 1).ToList();
                var check = conlai.Count > 0 && int.Parse(string.Join("", conlai)) > 0;
                if (!check)
                {
                    break;
                }
                if (i != donvi1.Count - 1)
                {
                    txt_return += ",";
                }
            }
            txt_return = txt_return.Trim();
            txt_return = txt_return.Substring(0, 1).ToUpper() + txt_return.Substring(1);
            return txt_return;
        }
        public static List<string> GetAllImage(string Thumb)
        {
            try
            {
                var lst = Thumb.Split(',').ToList();
                List<string> lstAll = new List<string>();
                foreach (var item in lst)
                {
                    if (lstAll.Where(t => t == item).Count() == 0)
                    {
                        lstAll.Add(item);
                    }
                }
                return lstAll;
            }
            catch
            {
                return null;
            }

        }
        public static string ConverBase64(string pathfile)
        {
            try
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(pathfile);
                return "data:image/jpg;base64," + Convert.ToBase64String(imageArray);
            }
            catch
            {
                return "";
            }

        }
        public static string ConvertMoneyVND(float? Price)
        {
            return (Price != 0 ? String.Format("{0:0,0₫}", Price) : "0₫");
        }
        public static string ConvertMoneyVND(double? Price)
        {
            return (Price != 0 ? String.Format("{0:0,0₫}", Price) : "0₫");
        }
        public static string ConvertMoney(float? Price)
        {
            return (Price != 0 ? String.Format("{0:0,0}", Price) : "0");
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                return true;
            }

            return source.Any() == false;
        }
        public static bool IsNullOrEmpty<T>(this T source)
        {
            if (source == null)
            {
                return true;
            }

            return false;
        }
       
        #region format datetime
        /// <summary>
        /// Convert string to datetime with current format dd/MM/yyyy or MM/dd/yyyy. input default format dd/MM/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <param name="strSpilt"></param>
        /// <param name="currentformat"></param>
        /// <returns></returns>
        public static DateTime convertDateToDateTimeMDY(string date, char strSpilt, string currentformat = "dd/MM/yyyy")
        {
            try
            {
                var tmpDate = date.Split(strSpilt);

                if (currentformat.ToLower().Equals("dd/mm/yyyy") || currentformat.ToLower().Equals("mm/dd/yyyy"))
                {
                    CultureInfo provider = new CultureInfo("fr-FR");
                    return DateTime.ParseExact(tmpDate[0] + "/" + tmpDate[1] + "/" + tmpDate[2], currentformat, provider);
                }
                else
                {
                    CultureInfo provider = new CultureInfo("en-US");
                    return DateTime.ParseExact(tmpDate[1] + "/" + tmpDate[0] + "/" + tmpDate[2], currentformat, provider);
                }
            }
            catch { return DateTime.Now; }
        }
        public static DateTime? convertToDateTime(string date, char strSpilt = '/', string currentformat = "dd/MM/yyyy")
        {
            try
            {
                if (date.IndexOf("01/01/0001") != -1)
                {
                    return null;
                }
                var tmpDate = date.Split(strSpilt);

                if (currentformat.ToLower().Equals("dd/mm/yyyy") || currentformat.ToLower().Equals("mm/dd/yyyy"))
                {
                    CultureInfo provider = new CultureInfo("fr-FR");
                    return DateTime.ParseExact(tmpDate[0] + "/" + tmpDate[1] + "/" + tmpDate[2], currentformat, provider);
                }
                else
                {
                    CultureInfo provider = new CultureInfo("en-US");
                    return DateTime.ParseExact(tmpDate[1] + "/" + tmpDate[0] + "/" + tmpDate[2], currentformat, provider);
                }
            }
            catch { return null; }
        }
        #endregion
       
        #region upload file

        public static UploadFileClass GetUploadFile(string MediaPath, string strFileName, bool AddDatePath)
        {
            UploadFileClass tempUploadClass = new UploadFileClass();
            System.Text.RegularExpressions.Match matchResults;
            string strAdditionFolder = (AddDatePath ? String.Format(DateTime.Now.ToString("yyyy\\\\MM\\\\")) : "");
            string strSaveFile = strFileName;
            // mac dinh them ngay thang nam trong ten file
            //matchResults = System.Text.RegularExpressions.Regex.Match(strSaveFile, "(?<FileName>.*?)(?:\\((?<AutoNumber>\\d*?)\\))?\\.(?<FileType>\\w*?)(?!.)");
            //strSaveFile = matchResults.Groups["FileName"].Value + "("+ DateTime.Now.ToString("ddMMyyyyHHmmss") + ")." + matchResults.Groups["FileType"].Value;
            string strSaveFolder = MediaPath + strAdditionFolder;
            //Check folder exist
            try
            {
                if (System.IO.Directory.Exists(strSaveFolder) == false)
                {
                    //Create Directory
                    System.IO.Directory.CreateDirectory(strSaveFolder);
                }
                if (System.IO.File.Exists(strSaveFolder + strSaveFile))
                {
                    while (System.IO.File.Exists(strSaveFolder + strSaveFile))
                    {
                        matchResults = System.Text.RegularExpressions.Regex.Match(strSaveFile, "(?<FileName>.*?)(?:\\((?<AutoNumber>\\d*?)\\))?\\.(?<FileType>\\w*?)(?!.)");
                        if (matchResults.Success)
                        {
                            if (matchResults.Groups["AutoNumber"].Value == string.Empty)
                            {
                                strSaveFile = matchResults.Groups["FileName"].Value + "(1)." + matchResults.Groups["FileType"].Value;
                            }
                            else
                            {
                                strSaveFile = matchResults.Groups["FileName"].Value + "(" + (int.Parse(matchResults.Groups["AutoNumber"].Value) + 1).ToString() + ")." + matchResults.Groups["FileType"].Value;
                            }
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            tempUploadClass.Virtualpath = strAdditionFolder.Replace("\\", "/") + strSaveFile;
            tempUploadClass.FileName = strSaveFile;
            tempUploadClass.Fullpath = strSaveFolder + strSaveFile;
            tempUploadClass.FolderPath = strAdditionFolder.Replace("\\", "/");
            tempUploadClass.StrPathTemp = strSaveFolder;
            return tempUploadClass;
        }
        public static UploadFileClass GetUploadFile(string MediaPath, string strFileName, bool AddDatePath, string UID)
        {
            UploadFileClass tempUploadClass = new UploadFileClass();
            System.Text.RegularExpressions.Match matchResults;
            string strAdditionFolder = (AddDatePath ? String.Format(DateTime.Now.ToString("\\\\yyyy\\\\MM\\\\dd\\\\")) : UID);
            string strSaveFile = strFileName;
            string strSaveFolder = MediaPath + strAdditionFolder;
            //Check folder exist
            try
            {
                if (System.IO.Directory.Exists(strSaveFolder) == false)
                {
                    //Create Directory
                    System.IO.Directory.CreateDirectory(strSaveFolder);
                }
                if (System.IO.File.Exists(strSaveFolder + strSaveFile))
                {
                    while (System.IO.File.Exists(strSaveFolder + strSaveFile))
                    {
                        matchResults = System.Text.RegularExpressions.Regex.Match(strSaveFile, "(?<FileName>.*?)(?:\\((?<AutoNumber>\\d*?)\\))?\\.(?<FileType>\\w*?)(?!.)");
                        if (matchResults.Success)
                        {
                            if (matchResults.Groups["AutoNumber"].Value == string.Empty)
                            {
                                strSaveFile = matchResults.Groups["FileName"].Value + "(1)." + matchResults.Groups["FileType"].Value;
                            }
                            else
                            {
                                strSaveFile = matchResults.Groups["FileName"].Value + "(" + (int.Parse(matchResults.Groups["AutoNumber"].Value) + 1).ToString() + ")." + matchResults.Groups["FileType"].Value;
                            }
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            tempUploadClass.Virtualpath = strAdditionFolder.Replace("\\", "/") + strSaveFile;
            tempUploadClass.FileName = strSaveFile;
            tempUploadClass.Fullpath = strSaveFolder + strSaveFile;
            tempUploadClass.FolderPath = strAdditionFolder.Replace("\\", "/");
            tempUploadClass.StrPathTemp = strSaveFolder;
            return tempUploadClass;
        }
        public static bool CheckfileUpload(string fileName)
        {
            bool ret = false;
            string name = "";
            name = Path.GetExtension(fileName.ToLower());
            switch (name.ToLower())
            {
                case ".jpg":
                    ret = true;
                    break;
                case ".png":
                    ret = true;
                    break;
                case ".gif":
                    ret = true;
                    break;
                case ".bmp":
                    ret = true;
                    break;
                case ".doc":
                    ret = true;
                    break;
                case ".docx":
                    ret = true;
                    break;
                case ".xls":
                    ret = true;
                    break;
                case ".xlsx":
                    ret = true;
                    break;
                case ".rar":
                    ret = true;
                    break;
                case ".zip":
                    ret = true;
                    break;
                case ".pdf":
                    ret = true;
                    break;
            }
            return (ret);
        }

        public static bool CheckImageFormat(string filename)
        {
            bool ret = false;
            string name = "";
            name = Path.GetExtension(filename.ToLower());
            switch (name.ToLower())
            {
                case ".jpg":
                    ret = true;
                    break;
                case ".png":
                    ret = true;
                    break;
                case ".gif":
                    ret = true;
                    break;
                case ".bmp":
                    ret = true;
                    break;
            }
            return (ret);
        }


        #endregion

        public static Dictionary<int, string> EnumToDictionary<T>()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("This isn't a enum");
            var dictionary = new Dictionary<int, string>();
            try
            {
                var enumType = typeof(T);
                dictionary = Enum.GetValues(typeof(T))
                                 .Cast<T>()
                                 .ToDictionary(
                                    t => (int)(object)t,
                                    t =>
                                    {
                                        var descriptionString = string.Empty;
                                        try
                                        {
                                            var memberInfo = enumType.GetMember(t.ToString())
                                                                .FirstOrDefault();
                                            var desctiptionAtribute = Equals(memberInfo, null)
                                                                    ? null
                                                                    : memberInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                                            descriptionString = desctiptionAtribute.Description;
                                        }
                                        catch (Exception)
                                        {
                                            descriptionString = "";
                                        }
                                        return descriptionString;
                                    })
                                 ;
            }
            catch (Exception)
            {
                dictionary = new Dictionary<int, string>();
            }

            return dictionary;
        }
        public static string GetDescription<T>(int key)
        {
            var result = string.Empty;
            try
            {
                var enumDictionary = EnumToDictionary<T>();
                var el = enumDictionary.FirstOrDefault(t => t.Key == key);
                return el.Value;
            }
            catch (Exception)
            {
                return "NULL";
            }
        }
        public static object GetPropValue(object _object, string propName)
        {
            try
            {
                return _object.GetType().GetProperty(propName).GetValue(_object, null);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }
        }
        public static dynamic GetExactValue(Type type, object value)
        {
            dynamic result = 0;
            try
            {
                if (type == typeof(string))
                    result = value.ToString();
                else if (type == typeof(char))
                    result = (char)value;
                else if (type == typeof(byte))
                    result = (byte)value;
                else if (type == typeof(int) || type == typeof(int?))
                    result = Convert.ToInt32(value);
                else if (type == typeof(long) || type == typeof(long?))
                    result = Convert.ToInt64(value);
                else if (type == typeof(float) || type == typeof(float?))
                    result = (float)value;
                else if (type == typeof(double) || type == typeof(double?))
                    result = Convert.ToDouble(value);
                else if (type == typeof(bool) || type == typeof(bool?))
                    result = (bool)value;
                else if (type == typeof(DateTime))
                    result = ConvertToDateTime(value.ToString());
                else if (type == typeof(DateTime?) || type == typeof(DateTime))
                {
                    result = ConvertToDateTimeNull(value.ToString());
                }
                else if (type == typeof(List<string>))
                {
                    result = (List<string>)value;
                }
                else if (type == typeof(int[]))
                {

                    result = value.ToString().Split(',').Select(t => int.Parse(t)).ToArray();
                }
                else if (type == typeof(long[]))
                {
                    result = value.ToString().Split(',').Select(t => long.Parse(t)).ToArray();
                }
                else
                {
                    result = null;
                }
            }
            catch (Exception e)
            {
                var mess = e.Message;
                if (type == typeof(string))
                    result = "";
                else if (type == typeof(char))
                    result = "";
                else if (type == typeof(byte))
                    result = 0;
                else if (type == typeof(int))
                    result = 0;
                else if (type == typeof(long))
                    result = 0;
                else if (type == typeof(float))
                    result = 0;
                else if (type == typeof(double))
                    result = 0;
                else if (type == typeof(bool))
                    result = false;
                else if (type == typeof(DateTime))
                    result = DateTime.Now;
                else if (type == typeof(DateTime?))
                    result = null;
                else if (type == typeof(List<string>))
                {
                    result = null;
                }
                else if (type == typeof(int[]))
                {
                    result = null;
                }
                if (type == typeof(long[]))
                {
                    result = null;
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        public static string GetDescription<T>(System.Enum value)
        {
            var descriptionString = string.Empty;
            try
            {
                var enumMember = value.GetType()
                                     .GetMember(value.ToString())
                                     .FirstOrDefault();
                var desctiptionAtribute = Equals(enumMember, null)
                                        ? null
                                        : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                descriptionString = Equals(value, null)
                                      ? value.ToString()
                                      : desctiptionAtribute.Description;
            }
            catch (Exception)
            {

                descriptionString = "";
            }
            return descriptionString;
        }
        public static long GetLong(Dictionary<string, string> _data, string name)
        {
            try
            {
                return long.Parse(_data[name]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static long[] GetLongs(Dictionary<string, string> _data, string name, bool isAjax = false)
        {
            try
            {
                if (isAjax)
                {
                    var dataString = _data[name];
                    if (!dataString.Contains(","))
                    {
                        return new long[] { long.Parse(dataString) };
                    }
                    return JsonConvert.DeserializeObject<long[]>(_data[name]);
                }
                return _data.Where(t => t.Key == name)
                            .Select(t => long.Parse(t.Value)).ToArray();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static int GetInt(Dictionary<string, string> _data, string name)
        {
            try
            {
                return int.Parse(_data[name]);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public static int[] GetInts(Dictionary<string, string> _data, string name, bool isAjax = false)
        {
            try
            {
                if (isAjax)
                {
                    var dataString = _data[name];
                    if (!dataString.Contains(","))
                    {
                        return new int[] { int.Parse(dataString) };
                    }
                    //var arr = dataString.Split(',').ToList();
                    //var result = new List<int>(arr.Count);
                    //arr.ForEach(i => result.Add(Convert.ToInt32(i)));
                    //return result.ToArray();
                    //return JsonConvert.DeserializeObject<int[]>(dataString);
                    return JsonDeserialize<int[]>(dataString);
                }

                var arr = _data.SingleOrDefault(t => t.Key == name).Value.Split(',').ToList();
                var result = new List<int>(arr.Count);
                arr.ForEach(i => result.Add(Convert.ToInt32(i)));
                return result.ToArray();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }
        }

        public static double[] GetDoubles(Dictionary<string, string> _data, string name, bool isAjax = false)
        {
            try
            {
                if (isAjax)
                {
                    var dataString = _data[name];
                    if (!dataString.Contains(","))
                    {
                        return new double[] { double.Parse(dataString) };
                    }
                    return JsonConvert.DeserializeObject<double[]>(dataString);
                }
                return _data.Where(t => t.Key == name)
                            .Select(t => double.Parse(t.Value)).ToArray();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }
        }
        public static string GetString(Dictionary<string, string> _data, string name)
        {
            try
            {
                return _data[name];
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        public static bool GetBool(Dictionary<string, string> _data, string name)
        {
            try
            {
                var result = _data[name];
                if (Equals(result, "1") || Equals(result.ToLower(), "true"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return false;
            }
        }
        public static string[] GetStrings(Dictionary<string, string> _data, string name, bool isAjax = false)
        {
            try
            {
                if (isAjax)
                {
                    var dataString = _data[name];
                    if (!dataString.Contains("\","))
                    {
                        return new string[] { dataString };
                    }
                    return JsonConvert.DeserializeObject<string[]>(_data[name]);
                }
                return _data.Where(t => t.Key == name)
                            .Select(t => t.Value).ToArray();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }
        }
        public static string GetStringJoin(string sep, object[] objects)
        {
            try
            {
                return string.Join(sep, objects);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return "0";
            }
        }
        public static string GetStringJoin(string sep, long[] objects)
        {
            try
            {
                return string.Join(sep, objects);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return "0";
            }
        }
        public static string GetStringParents(string parents, int parent)
        {
            try
            {
                var parentSplits = parents.ToLongSplit('|');
                var resultSplits = parentSplits.ToList();
                if (!resultSplits.Exists(t => t == parent))
                {
                    resultSplits.Add(parent);
                }
                return string.Join("|", resultSplits);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return "0";
            }

        }
        public static List<long> GetLongParents(string parents, int parent = 0)
        {
            try
            {
                var parentSplits = parents.ToLongSplit('|');
                var resultSplits = parentSplits.ToList();
                if (!resultSplits.Exists(t => t == parent))
                {
                    resultSplits.Add(parent);
                }
                return resultSplits;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new List<long> { 0 };
            }

        }
        public static string DateToString(DateTime? datetime, string regex = "dd-MM-yyyy")
        {
            try
            {
                return datetime.HasValue ? datetime.Value.ToString(regex) : string.Empty;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return string.Empty;
            }
        }
        public static string DateToString(DateTime datetime, string regex = "dd-MM-yyyy")
        {
            try
            {
                return datetime.ToString(regex);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return string.Empty;
            }
        }
        public static DateTime ConvertToDateTime(string value)
        {
            try
            {
                return DateTime.ParseExact(value, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return DateTime.MinValue;
            }
        }
        public static DateTime? ConvertToDateTimeNull(string value, string regex = "dd/MM/yyyy HH:mm")
        {
            try
            {
                value = value.Replace("-", "/");
                if (value.Length == "dd/MM/yyyy".Length)
                {
                    regex = "dd/MM/yyyy";
                }
                return DateTime.ParseExact(value, regex, null);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }
        }
        public static bool SaveFile(string filePath, string fileName, string text = "", bool isAppend = false)
        {
            try
            {
                var fullPath = string.Format(@"{0}\{1}", filePath, fileName);
                var streamWriter = new StreamWriter(fullPath, isAppend);
                streamWriter.Write(text);
                streamWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return false;
            }

        }
        public static string UrlFile(string path, string fileName)
        {
            var virtualPath = SystemConfig.GetValueByKey("FileFolder") + @"\" + path;
            var link = "/UpFileNormal/Download?Path=" + virtualPath + "&FileName=" + fileName;
            return link;
        }
        public static int Quater(DateTime date)
        {
            try
            {
                var month = date.Month;
                int quarter = (month + 2) / 3;
                return quarter;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public static int[] GetMonthOfQuater(int quater)
        {
            var months = new int[] { 0 };
            switch (quater)
            {
                case 1:
                    months = new int[] { 1, 2, 3 };
                    break;
                case 2:
                    months = new int[] { 4, 5, 6 };
                    break;
                case 3:
                    months = new int[] { 7, 8, 9 };
                    break;
                case 4:
                    months = new int[] { 10, 11, 12 };
                    break;
                case 5:
                    months = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                    break;
                default:
                    break;
            }
            return months;
        }
        public static string GetStringJoin(string sep, IEnumerable<int> objects)
        {
            try
            {
                return string.Join(sep, objects);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return "0";
            }
        }
        public static string GetStringJoin(string sep, IEnumerable<string> objects)
        {
            try
            {
                return string.Join(sep, objects);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return "0";
            }
        }
        public static string GenLinkExport(string url, dynamic objFillter)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat(url);
                var types = objFillter.GetType();
                var props = new List<PropertyInfo>(types.GetProperties());
                foreach (var prop in props)
                {
                    try
                    {
                        var propValue = prop.GetValue(objFillter, null);
                        var propType = prop.PropertyType;
                        if (propValue != null)
                        {
                            if (propType == typeof(int))
                                if (propValue > 0 || prop.Name == "IDChannel")
                                    sb.AppendFormat(prop.Name + "={0}&", propValue);
                            if (propType == typeof(DateTime) ? true : propType == typeof(DateTime?))
                            {
                                var valueDate = Utils.DateToString(propValue, "dd-MM-yyyy");
                                if (Equals(valueDate, null))
                                    sb.AppendFormat(prop.Name + "={0}&", valueDate);
                            }
                            if (propType == typeof(string))
                                sb.AppendFormat(prop.Name + "={0}&", propValue);
                            if (propType == typeof(bool))
                                sb.AppendFormat(prop.Name + "={0}&", propValue);
                        }
                        if (propType.IsArray)
                        {
                            var arrays = (Array)prop.GetValue(objFillter, null);
                            for (int i = 0; i < arrays.Length; i++)
                            {
                                sb.AppendFormat(prop.Name + "={0}&", arrays.GetValue(i));
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                url = sb.ToString().TrimEnd('&');
            }
            catch (Exception)
            {
                url = "#";
            }
            return url;
        }
    }
    public class UploadFileClass
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        private string fullpath;

        public string Fullpath
        {
            get { return fullpath; }
            set { fullpath = value; }
        }
        private string virtualpath;

        public string Virtualpath
        {
            get { return virtualpath; }
            set { virtualpath = value; }
        }

        private string folderPath;

        public string FolderPath
        {
            get { return folderPath; }
            set { folderPath = value; }
        }

        private string strPathTemp;

        public string StrPathTemp
        {
            get { return strPathTemp; }
            set { strPathTemp = value; }
        }
        public string pathThumb { get; set; }


      
    }
}