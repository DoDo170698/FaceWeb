using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static demo1.CodeLogic.Utils;
namespace demo1.CodeLogic
{
    public static class Extensions
    {
        /// <summary>
        ///     hàm xóa bỏ dấu Unicode
        /// </summary>
        /// <param name="text">
        ///     đầu vào là đoạn string cần xóa dấu
        /// </param> 
        /// <returns>
        ///     đầu ra là đoạn string đã bị xóa đấu
        /// </returns>
        public static string RemoveUnicode(this string text, bool isLower = true)
        {
            try
            {
                string[] arr1 = new string[] {
                    "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
                    "đ",
                    "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
                    "í","ì","ỉ","ĩ","ị",
                    "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
                    "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
                    "ý","ỳ","ỷ","ỹ","ỵ",};
                string[] arr2 = new string[] {
                    "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
                    "d",
                    "e","e","e","e","e","e","e","e","e","e","e",
                    "i","i","i","i","i",
                    "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
                    "u","u","u","u","u","u","u","u","u","u","u",
                    "y","y","y","y","y",};
                for (int i = 0; i < arr1.Length; i++)
                {
                    text = text.Replace(arr1[i], arr2[i]);
                    text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
                }
            }
            catch (Exception e)
            {
                var mess = e.Message;
                text = "";
            }
          
            return isLower ? text.ToLower() : text;
        }
        /// <summary>
        ///     hàm xóa dấu và đổi chữ viết thành viết thường hết
        /// </summary>
        /// <param name="text">
        ///     đoạn text cần được
        /// </param>
        /// <param name="isNotLower">
        ///     nếu true thì nó sẽ bỏ dấu và đổi hết chữ hoa thành thường
        ///     nếu false thì nó sẽ chỉ bỏ dấu 
        /// </param>
        /// <returns>
        ///     trả về chuỗi tring đã bị bỏ dấu và đổi hoa thành thường nếu isNotLower = true ,
        ///     trả về chuỗi tring đã bị bỏ dấu nếu isNotLower = false
        /// </returns>
        public static string Reduced(this string text, bool isNotLower = false)
        {
            try
            {
                return isNotLower ? text.RemoveUnicode().Replace(" ", string.Empty)
                                  : text.RemoveUnicode().Replace(" ", string.Empty).ToLower();
            }
            catch (Exception)
            {
                return "NULL";
            }

        }
        /// <summary>
        ///     đổi 1 object thành dạng chuỗi Json 
        /// </summary>
        /// <param name="_object">
        ///     đầu vào là 1 object
        /// </param>
        /// <returns>
        ///     đầu ra là 1 chuỗi Json dạng string
        /// </returns>
        public static string ToJsonString(this object _object)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(_object);
                return json;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Hàm check null hoặc empty cho mảng
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }
        public static bool IsNullOrEmpty(this string str)
        {
            try
            {
                return (Equals(str, null) || Equals(str, string.Empty));
            }
            catch (Exception)
            {
                return true;
            }
        }
        /// <summary>
        /// Hàm convert dữ liệu lấy từ form khi có Request thành kiểu Dictionary 
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(this NameValueCollection col)
        {
            var dict = new Dictionary<string, string>();
            foreach (var key in col.Keys)
            {
                if (IsDateTime2(col[key.ToString()]))
                {
                    dict.Add(key.ToString(), col[key.ToString()].Replace('-','/'));
                }
                else
                {
                    dict.Add(key.ToString(), col[key.ToString()]);
                }
            }
            return dict;
        }
        public static T BindData<T>(this T _object, Dictionary<string, string> _data, bool isCreate = true, bool isReplaceID = true) where T : class
        {
            try
            {
                var type = typeof(T);
                var properties = type.GetProperties();
                var searchMeta = type.GetProperty("SearchMeta");
                var searchMetaString = "";
                foreach (var item in properties)
                {
                    if(!isReplaceID && item.Name.Equals("ID"))
                    {
                        continue;
                    }
                    if (_data.ContainsKey(item.Name))
                    {
                        item.SetValue(_object, GetExactValue(item.PropertyType, _data[item.Name]), null);
                        if(item.PropertyType == typeof(DateTime?))
                        {
                            if(!_data[item.Name].IsNullOrEmpty())
                            {
                                var time = new DateTime?();
                                time = Utils.StringToDateTime(_data[item.Name], '/');
                                //DateTime.TryParse(_data[item.Name], out time);
                                item.SetValue(_object, time, null);
                            }
                        }
                        if (!Equals(searchMeta, null))
                        {
                            var fieldSearchs = (List<string>)GetPropValue(_object, "FieldSearchs");
                            if (fieldSearchs.Contains(item.Name))
                            {
                                searchMetaString += _data[item.Name].RemoveUnicode() + " ";
                            }
                        }
                    }
                    if (Equals(item.Name, "Created") && isCreate)
                    {
                        item.SetValue(_object, GetExactValue(typeof(DateTime), DateTime.Now.ToString("dd-MM-yyyy")), null);
                    }
                    else if (Equals(item.Name, "Updated") && !isCreate)
                        item.SetValue(_object, GetExactValue(typeof(DateTime?), DateTime.Now.ToString("dd-MM-yyyy")), null);
                }
                if (!Equals(searchMeta, null))
                {
                    searchMeta.SetValue(_object, searchMetaString, null);
                }
                return _object;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return (T)new object();
            }

        }
        public static string Serialize(this object obj)
        {
            try
            {
                return new JavaScriptSerializer().Serialize(obj);
            }
            catch (Exception)
            {

                return "NULL";
            }
        }
        public static T DeSerialize<T>(this string objJson) where T : class
        {
            try
            {
                return new JavaScriptSerializer().Deserialize<T>(objJson);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public static string[] ToStringSplit(this string str , char sep)
        {
            try
            {
              return str.Split(sep);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new string[] {"0"};
            }
        }
        public static int[] ToIntSplit(this string str, char sep)
        {
            try
            {
                return str.Trim().Split(sep)
                          .Select(t=>int.Parse(t))
                          .ToArray();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new int[] { 0 };
            }
        }
        public static long[] ToLongSplit(this string str, char sep)
        {
            try
            {
                return str.Trim().Split(sep)
                          .Select(t => long.Parse(t))
                          .ToArray();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new long[] { 0 };
            }
        }
        
        public static Hashtable KeyValues(this object _object)
        {
            var hash = new Hashtable();
            Type objType = _object.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(objType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(_object, null);
                hash.Add(prop.Name, propValue);
            }
            return hash;
        }
    }
}