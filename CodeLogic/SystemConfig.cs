
using demo1.Models.Fitness;
using demo1.Repository;
using System;
using System.Configuration;
using System.Linq;
using static demo1.CodeLogic.Enums.Enums;

namespace demo1.CodeLogic
{
    public class SystemConfig
    {
        public static string GetValueByKey(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key]; ;
            }
            catch (Exception)
            {

                return "0";
            }
        }
        public static string GetConnectString(string key)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception)
            {

                return "NULL";
            }
        }

        //check quyền

        public static bool IsRole(User user, int role)
        {
            try
            {
                var userRoles = UserRoleRepository.UseInstance.GetListByFieldOrDefault("IDUser", user.ID, (int)TypeObject.Int);
                //if (role.Any(x => userRoles.Select(n => n.IDRole).Contains(x))
                if ((userRoles.Select(n => n.IDRole)).Contains(role))
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

        public static bool IsRole(User user, int[] role)
        {
            try
            {
                var userRoles = UserRoleRepository.UseInstance.GetListByFieldOrDefault("IDUser", user.ID, (int)TypeObject.Int);
                //if (role.Any(x => userRoles.Select(n => n.IDRole).Contains(x))
                if (role.Intersect(userRoles.Select(n => n.IDRole)).Any())
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

        //public static bool IsRole(Account account,int role)
        //{
        //    try
        //    {
        //        var roles = account.Roles.ToIntSplit(',');
        //        if (account.IsAdmin)
        //        {
        //            return true;
        //        }
        //        if (roles.Contains(role))
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        var mess = e.Message;
        //        return false;
        //    }

        //}
    }
}
