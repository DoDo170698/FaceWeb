using NPoco;
using demo1.CodeLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static demo1.CodeLogic.Enums.Enums;

namespace demo1.Models.PurchaseManage
{
    public class PurchaseManageDataContext<T> where T : class, new()
    {
        public static Database Instance { get; set; }
        public static string ConnectString = "PurchaseManageConnecString";
        public static PurchaseManageDataContext<T> UseInstance
        {
            get
            {
                return new PurchaseManageDataContext<T>(ConnectString);
            }
        }
        public PurchaseManageDataContext(string connectString = "PurchaseManageConnecString")
        {
            ConnectString = connectString;
        }
        public static Database GetInStance()
        {
            try
            {
                Instance = Equals(Instance, null) ? new Database(ConnectString) : Instance;
                return Instance;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<T> GetListOrDefault(string sql = "")
        {
            try
            {
                Instance = GetInStance();
                sql = Equals(sql, "") ? string.Format("SELECT * FROM {0}", GetTableName()) : sql;
                var list = Instance.Fetch<T>(sql);
                return list;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<T> GetListOrDefault(Sql sql)
        {
            try
            {
                Instance = GetInStance();
                var list = Instance.Fetch<T>(sql);
                return list;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<T> GetListOrDefault(string sql, Pagination paging)
        {
            try
            {
                Instance = GetInStance();
                sql = Equals(sql, null) ? string.Format("SELECT * FROM {0}", GetTableName()) : sql;
                var list = Instance.Fetch<T>(paging.PageIndex, paging.PageSize, sql);
                // tính toán lại Paging sau khi lấy được số lượng list
                if (list.Count > 0)
                {
                    paging.PageCount = list.Count % paging.PageSize;
                    if (list.Count > paging.PageSize)
                    {
                        paging.PageTotal = list.Count / paging.PageSize;
                        if (paging.PageCount > 0)
                            paging.PageTotal++;
                    }
                    else
                        paging.PageTotal = 1;
                    paging.PageStart = paging.PageSize * (paging.PageTotal - 1);
                }
                return list;
            }
            catch (Exception e)
            {
                var x = e.Message;
                return null;
            }

        }
        public List<T> GetListOrDefault(Sql sql, Pagination paging)
        {
            try
            {
                Instance = GetInStance();
                if(Equals(paging,null))
                {
                    return Instance.Fetch<T>(sql) ?? new List<T>();
                }
                var page = Instance.Page<T>(paging.PageIndex, paging.PageSize, sql);
                var list = page.Items;
                paging.Total = (int)page.TotalItems;
                paging.PageStart = paging.PageSize * (paging.PageTotal - 1);
                paging.PageTotal = (int)page.TotalPages;
                paging.PageStart = paging.PageSize * ((int)page.CurrentPage - 1);
                return list ?? new List<T>();
            }
            catch (Exception e)
            {
                var x = e.Message;
                return new List<T>();
            }

        }
        public List<T> GetListByFieldOrDefault(string field, string value, int type)
        {
            try
            {
                Instance = GetInStance();
                var sql = string.Format("SELECT * FROM {0} ", GetTableName());

                switch (type)
                {
                    case (int)TypeObject.Byte:
                    case (int)TypeObject.Int:
                    case (int)TypeObject.Long:
                    case (int)TypeObject.Float:
                    case (int)TypeObject.Double:
                        sql += string.Format("WHERE {0}= {1}", field, value);
                        break;
                    case (int)TypeObject.Char:
                    case (int)TypeObject.String:
                        sql += string.Format("WHERE {0}= N'{1}'", field, value);
                        break;
                    default:
                        sql += string.Format("WHERE {0}= '{1}'", field, Equals(value, null) ? "null" : value);
                        break;
                }
                var list = Instance.Fetch<T>(sql);
                return list;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<T> GetListByFieldsOrDefault(List<CondParam> condParams)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder;
                if (Equals(condParams, null))
                {
                    return new List<T>();
                }
                condParams.ForEach(t =>
                {
                    if (t.CompareType == (int)CompareTypes.In)
                    {
                        sql.Where(string.Format("{0} IN ({1})", t.Field,Utils.GetStringJoin(",",t.Value)));
                    }
                    else
                    {
                        if (t.TypeSQL == (int)TypeSQl.String)
                        {
                            sql.Where(string.Format(" {0} {1} N'{2}' ", t.Field, t.CompareTypeString, t.Value));
                        }
                        else if (t.TypeSQL == (int)TypeSQl.Number)
                        {
                            sql.Where(string.Format(" {0} {1} {2} ", t.Field, t.CompareTypeString, t.Value));
                        }
                    }
                    if (!t.Sql.IsNullOrEmpty())
                    {
                        sql.Where(t.Sql);
                    }
                });

                return Instance.Fetch<T>(sql) ?? new List<T>();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new List<T>();
            }

        }
        public T GetFirstByFields(List<CondParam> condParams)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder;
                if (Equals(condParams, null))
                {
                    return new T();
                }
                condParams.ForEach(t =>
                {
                    if (t.CompareType == (int)CompareTypes.In)
                    {
                        sql.Where(string.Format("{0} IN ({1})", t.Field, Utils.GetStringJoin(",", t.Value)));
                    }
                    else
                    {
                        if (t.TypeSQL == (int)TypeSQl.String)
                        {
                            sql.Where(string.Format(" {0} {1} N'{2}' ", t.Field, t.CompareTypeString, t.Value));
                        }
                        else if (t.TypeSQL == (int)TypeSQl.Number)
                        {
                            sql.Where(string.Format(" {0} {1} {2} ", t.Field, t.CompareTypeString, t.Value));
                        }
                    }
                    if (!t.Sql.IsNullOrEmpty())
                    {
                        sql.Where(t.Sql);
                    }
                });

                return Instance.FirstOrDefault<T>(sql);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }

        }
        public T GetFirstByFieldsOrDefault(List<CondParam> condParams)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder;
                if (Equals(condParams, null))
                {
                    return new T();
                }
                condParams.ForEach(t =>
                {
                    if (t.CompareType == (int)CompareTypes.In)
                    {
                        sql.Where(string.Format("{0} IN ({1})", t.Field, Utils.GetStringJoin(",", t.Value)));
                    }
                    else
                    {
                        if (t.TypeSQL == (int)TypeSQl.String)
                        {
                            sql.Where(string.Format(" {0} {1} N'{2}' ", t.Field, t.CompareTypeString, t.Value));
                        }
                        else if (t.TypeSQL == (int)TypeSQl.Number)
                        {
                            sql.Where(string.Format(" {0} {1} {2} ", t.Field, t.CompareTypeString, t.Value));
                        }
                    }
                    if (!t.Sql.IsNullOrEmpty())
                    {
                        sql.Where(t.Sql);
                    }
                });

                return Instance.FirstOrDefault<T>(sql) ?? new T();
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new T();
            }

        }
        public T GetById(int id, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var typeName = typeof(T).Name;
                if (string.IsNullOrEmpty(typeName))
                    return null;
                var db_Name = SystemConfig.GetValueByKey(dbName);
                var table = string.IsNullOrEmpty(dbName)
                                   ? string.Format("[dbo].[{0}]", typeName)
                                   : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
                var sql = string.Format("SELECT * FROM {0} WHERE ID = {1}", table, id);
                var objectT = Instance.SingleOrDefault<T>(sql);
                return objectT;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }

        }
        public T GetById(long id, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var typeName = typeof(T).Name;
                if (string.IsNullOrEmpty(typeName))
                    return null;
                var db_Name = SystemConfig.GetValueByKey(dbName);
                var table = string.IsNullOrEmpty(dbName)
                                   ? string.Format("[dbo].[{0}]", typeName)
                                   : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
                var sql = string.Format("SELECT * FROM {0} WHERE ID = {1}", table, id);
                var objectT = Instance.SingleOrDefault<T>(sql);
                return objectT;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }

        }
        public T GetByIdOrDefault(int id, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var typeName = typeof(T).Name;
                if (string.IsNullOrEmpty(typeName))
                    return null;
                var db_Name = SystemConfig.GetValueByKey(dbName);
                var table = string.IsNullOrEmpty(dbName)
                                   ? string.Format("[dbo].[{0}]", typeName)
                                   : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
                var sql = string.Format("SELECT * FROM {0} WHERE ID = {1}", table, id);
                var objectT = Instance.SingleOrDefault<T>(sql) ?? new T();
                return objectT;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new T();
            }

        }
        public T GetByIdOrDefault(long id, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var typeName = typeof(T).Name;
                if (string.IsNullOrEmpty(typeName))
                    return null;
                var db_Name = SystemConfig.GetValueByKey(dbName);
                var table = string.IsNullOrEmpty(dbName)
                                   ? string.Format("[dbo].[{0}]", typeName)
                                   : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
                var sql = string.Format("SELECT * FROM {0} WHERE ID = {1}", table, id);
                var objectT = Instance.SingleOrDefault<T>(sql) ?? new T();
                return objectT;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new T();
            }

        }
        public List<T> GetByIdsOrDefault(long[] ids, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var typeName = typeof(T).Name;
                if (string.IsNullOrEmpty(typeName))
                    return null;
                var db_Name = SystemConfig.GetValueByKey(dbName);
                var table = string.IsNullOrEmpty(dbName)
                                   ? string.Format("[dbo].[{0}]", typeName)
                                   : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
                var sql = string.Format("SELECT * FROM {0} WHERE ID in ({1})", table, Utils.GetStringJoin(",", ids));
                var objectT = Instance.Fetch<T>(sql) ?? new List<T>();
                return objectT;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new List<T>();
            }

        }
        public T GetSingleByField(string field, string value, int type, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder
                        .Select("*")
                        .From(GetTableName(dbName));
                switch (type)
                {
                    case (int)TypeObject.Byte:
                    case (int)TypeObject.Int:
                    case (int)TypeObject.Long:
                    case (int)TypeObject.Float:
                    case (int)TypeObject.Double:
                        sql.Where(string.Format(" {0}= {1}", field, value));
                        break;
                    case (int)TypeObject.Char:
                    case (int)TypeObject.String:
                        sql.Where(string.Format(" {0}= N'{1}'", field, value));
                        break;
                    default:
                        sql.Where(string.Format(" {0}= '{1}'", field, Equals(value, null) ? "null" : value));
                        break;
                }
                return Instance.SingleOrDefault<T>(sql);
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return null;
            }

        }
        public bool Insert(T _object, string id = "ID", string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var newObject = Instance.Insert<T>(GetTableName(dbName), id, _object);
                return Equals(newObject, null) ? false : true;

            }
            catch (Exception e)
            {
                var message = e.Message;
                return false;
            }

        }
        public void BulkInserts(IEnumerable<T> _objects, string id = "ID", string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                Instance.InsertBulk(_objects);
            }
            catch (Exception e)
            {
                var message = e.Message;
            }

        }
        public bool Update(T _object, string dbName = null)
        {
            try
            {
                Instance = GetInStance();
                var x = typeof(T).GetProperty("FieldSearchs");
                return Instance.Update(_object) > 0 ? true : false;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return false;
            }

        }
        public bool Deletes(long[] ids, string dbName = null)
        {
            try
            {
                ids = ids.IsNullOrEmpty() ? new long[] { 0 } : ids;
                Instance = GetInStance();
                var joinString = Utils.GetStringJoin(",", ids);
                var sql = string.Format("Delete {0} where ID IN ({1})", GetTableName(), joinString);
                return Instance.Execute(sql) > 0 ? true : false;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return false;
            }

        }
        public bool Delete(int id)
        {
            try
            {
                Instance = GetInStance();
                return Instance.Delete<T>(id) > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                Instance = GetInStance();
                return Instance.Delete<T>(id) > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteByField(string field, string value, int type)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder;
                switch (type)
                {
                    case (int)TypeObject.Byte:
                    case (int)TypeObject.Int:
                    case (int)TypeObject.Long:
                    case (int)TypeObject.Float:
                    case (int)TypeObject.Double:
                        sql.Where(string.Format(" {0}= {1}", field, value));
                        break;
                    case (int)TypeObject.Char:
                    case (int)TypeObject.String:
                        sql.Where(string.Format(" {0}= N'{1}'", field, value));
                        break;
                    default:
                        sql.Where(string.Format(" {0}= '{1}'", field, Equals(value, null) ? "null" : value));
                        break;
                }
                return Instance.Delete<T>(sql) > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteByField(string field, long[] values)
        {
            try
            {
                Instance = GetInStance();
                var stringValues = Utils.GetStringJoin(",", values);
                var sql = Sql.Builder
                             .Where("{0} in({1})", field, values);
                return Instance.Delete<T>(sql) > 0 ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Exists(int id)
        {
            try
            {
                Instance = GetInStance();
                return Instance.Exists<T>(id);
            }
            catch
            {
                return false;
            }
        }
        public string GetTableName(string dbName = null)
        {
            var typeName = typeof(T).Name;
            if (string.IsNullOrEmpty(typeName))
                return null;
            var db_Name = SystemConfig.GetValueByKey(dbName);
            var table = string.IsNullOrEmpty(dbName)
                               ? string.Format("[dbo].[{0}]", typeName)
                               : string.Format("[{0}].[dbo].[{1}]", db_Name, typeName);
            return table;
        }
        public bool FieldExist(string field, object value, long id = 0, int idChannel = 0)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder
                             .Select("ID").From(GetTableName());
                var typeValue = value.GetType();
                var exactValue = Utils.GetExactValue(typeValue, value);
                if (typeValue == typeof(float) || typeValue == typeof(int) || typeValue == typeof(double) ||
                    typeValue == typeof(byte) || typeValue == typeof(long))
                    sql.Append(string.Format("WHERE {0} = {1}", field, exactValue));
                else if (typeValue == typeof(string) || value.GetType() == typeof(char))
                    sql.Append(string.Format("WHERE {0} = N'{1}'", field, exactValue));
                else if (typeValue == typeof(DateTime))
                    sql.Append(string.Format("WHERE {0} = '{1}'", field, exactValue.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                else if (typeValue == typeof(DateTime?))
                    sql.Append(string.Format("WHERE {0} = '{1}'", field, Equals(exactValue, null) ? null : exactValue.ToString("yyyy-MM-dd HH:mm:ss.fff")));
                else if (typeValue == typeof(bool))
                    sql.Append(string.Format("WHERE {0} = {1}", field, exactValue ? 1 : 0));
                if (id > 0)
                {
                    sql.Append(string.Format(" AND ID <> {0}", id));
                }
                var _object = Equals(Instance, null)
                            ? new Database(ConnectString).FirstOrDefault<T>(sql)
                            : Instance.FirstOrDefault<T>(sql);
                return Equals(_object, null) ? false : true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public T GetFirstByFieldOrdefault(Sql sql)
        {
            try
            {
                Instance = GetInStance();
                var _object = Instance.FirstOrDefault<T>(sql);
                return Equals(_object, null) ? new T() : _object;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return new T();
            }
        }
        public bool DeleteByField(List<CondParam> condParams)
        {
            try
            {
                Instance = GetInStance();
                var sql = Sql.Builder;
                if (Equals(condParams, null))
                {
                    return false;
                }
                condParams.ForEach(t =>
                {
                    if (t.CompareType == (int)CompareTypes.In)
                    {

                        sql.Where(" {0} IN (@1)", t.Field, t.Value);

                    }
                    else
                    {
                        if (t.TypeSQL == (int)TypeSQl.String)
                        {
                            sql.Where(string.Format(" {0} {1} N'{2}' ", t.Field, t.CompareTypeString, t.Value));
                        }
                        else if (t.TypeSQL == (int)TypeSQl.Number)
                        {
                         //   sqlFind += string.Format("@0 @1 @2 ", t.Field, t.CompareTypeString, t.Value);
                            sql.Where(string.Format(" {0} {1} {2} ", t.Field, t.CompareTypeString, t.Value));
                        }
                    }
                    if (!t.Sql.IsNullOrEmpty())
                    {
                        sql.Where(t.Sql);
                    }
                });
                
                return Instance.Delete<T>(sql) > 0 ? true : false;
            }
            catch (Exception e)
            {
                var mess = e.Message;
                return false;
            }
        }
    }
    public class CondParam
    {
        public string Field { get; set; }
        public dynamic Value { get; set; }
        public int CompareType { get; set; }
        public string Sql { get; set; }
        public string CompareTypeString
        {
            get
            {
                var compareString = "";
                switch (CompareType)
                {
                    case (int)CompareTypes.Equal:
                        compareString = "=";
                        break;
                    case (int)CompareTypes.NotEqual:
                        compareString = "!=";
                        break;
                    case (int)CompareTypes.GreaterThan:
                        compareString = ">=";
                        break;
                    case (int)CompareTypes.LowerThan:
                        compareString = ">=";
                        break;
                }
                return compareString;
            }
            set { }
        }
        public int TypeSQL { get; set; }
    }

}