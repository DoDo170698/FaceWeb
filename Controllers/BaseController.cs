using ClosedXML.Excel;
using demo1.CodeLogic;
using demo1.CodeLogic.Commons;
using demo1.CodeLogic.Customs;
using demo1.Repository;
using Newtonsoft.Json;

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using demo1.Models.Fitness;

namespace demo1.Controllers
{
    public class BaseController : Controller
    {
        private string _custHTML;
        private bool _isAjax;
        private string _linkRedirect;
        private bool _isCust;
        private bool _isDL;
        private object _wDL;
        private string _htDL;
        private bool _resOnlyData;
        private dynamic _dataRes;
        protected object _addRes;
        private readonly List<string> _warns = new List<string>();
        private readonly List<string> _errors = new List<string>();
        private readonly List<string> _success = new List<string>();
        private readonly List<string> _notifies = new List<string>();
        public bool IsMsg
        {
            get
            {
                return IsError || IsSuccess || IsNotify || IsWarn;
            }
        }
        public bool IsError
        {
            get
            {
                return (Session["Errors"] != null && ((List<string>)Session["Errors"]).Any());
            }
        }
        public bool IsSuccess
        {
            get
            {
                return Session["Success"] != null && ((List<string>)Session["Success"]).Any();
            }
        }
        public bool IsNotify
        {
            get
            {
                return Session["Notifies"] != null && ((List<string>)Session["Notifies"]).Any();
            }
        }
        public bool IsWarn
        {
            get
            {
                return Session["Warns"] != null && ((List<string>)Session["Warns"]).Any();
            }
        }
        protected bool IsAjax
        {
            get
            {
                return Request.IsAjaxRequest();
            }
        }
        // 
        protected Pagination Paging { get; set; }
        public Dictionary<string, string> DATA { get; set; }
        // GET: Base
        /// <summary>
        ///     Điều khiển luồng của Action
        /// </summary>
        /// <param name="filterContext"></param>
        #region Control stream of Action
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // trước khi vào Conttroller nó sẽ đi vào đây
            base.OnActionExecuting(filterContext);
            ResetCache(filterContext);
            SetSession(120);
            SetData();
            SetPaging(DATA);
            ViewBag.Paging = Paging;
        }
        private void ResetCache(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            // vào View xong mới ra đây
            base.OnActionExecuted(filterContext);
        }
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // xon View thì sẽ kết thúc tại đây
            base.OnResultExecuted(filterContext);
        }
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            SetSession();
            return base.BeginExecuteCore(callback, state);
        }
        internal void SetHtmlDialog(string html, object width)
        {
            _isDL = true;
            _wDL = width;
            _htDL = html;
        }
        internal void SetSuccess(string success)
        {
            _success.Add(success);
            Session["Success"] = _success;
        }
        internal void SetSuccess(List<string> success)
        {
            if (!Equals(success, null) && success.Any())
            {
                _success.AddRange(success);
                Session["Success"] = _success;
            }
        }
        internal void SetNotify(string notify)
        {
            _notifies.Add(notify);
            Session["Notifies"] = _notifies;
        }
        internal void SetNotify(List<string> notifies)
        {
            if (!Equals(notifies, null) && notifies.Any())
            {
                _notifies.AddRange(notifies);
                Session["Notifies"] = _notifies;
            }
        }
        /// <summary>
        ///     Set errors
        /// </summary>
        /// <param name="error"></param>
        ///  }
        internal void SetDataResponse(dynamic data = null)
        {
            _dataRes = data;
        }
        internal void SetOnlyDataResponse(dynamic data)
        {
            _resOnlyData = true;
            _dataRes = data;
        }

        /// 
        internal void SetError(string error)
        {
            _errors.Add(error);
            Session["Errors"] = _errors;
        }
        internal void SetErrors(List<string> errors)
        {
            if (!Equals(errors, null) && errors.Any())
            {
                _errors.AddRange(errors);
                Session["Errors"] = _errors;
            }
        }

        /// <summary>
        ///     Set warnings
        /// </summary>
        /// <param name="warn"></param>
        internal void SetWarn(string warn)
        {
            _warns.Add(warn);
            Session["Warns"] = _warns;
        }
        internal bool HasError
        {
            get { return _errors.Any(); }
        }
        internal void SetWarns(List<string> warns)
        {
            if (!Equals(warns, null) && warns.Any())
            {
                _warns.AddRange(warns);
                Session["Warns"] = _warns;
            }
        }
        #endregion
        #region viết lại hàm View
        internal void SetHtmlResponse(string html)
        {
            _isAjax = true;
            _isCust = true;
            _custHTML = html;
        }
        protected JsonResult GetResult()
        {
            if (_resOnlyData)
                return Json(new Hashtable {
                    {"data", _dataRes ?? string.Empty}
                });
            var res = new Dictionary<object, object>();
            res.Add("title", ViewBag.Title ?? string.Empty);
            res.Add("isAjax", _isAjax ? 1 : 0);
            res.Add("linkRedirect", _linkRedirect);
            res.Add("addRes", _addRes);
            res.Add("dataRes", _dataRes);
            if (_isCust)
            {
                res.Add("isCust", 1);
                res.Add("custHTML", _custHTML ?? string.Empty);
            }
            if (_isDL)
            {
                res.Add("isDL", 1);
                res.Add("htDL", _htDL);
                res.Add("wDL", _wDL);
            }
            if (IsError)
            {
                res.Add("isErr", 1);
                res.Add("ctMeg", string.Join(",", _errors));
            }
            if (IsWarn)
            {
                res.Add("isWarn", 1);
                res.Add("ctMeg", string.Join(",", _warns));
            }
            if (IsMsg)
            {
                res.Add("isMsg", 1);
                res.Add("htMsg", GetMessages());
            }
            return Json(res);
        }
        protected string GetMessages()
        {
            return GetView("~/Views/Shared/Message.cshtml");
        }
        protected ActionResult GetViewResult(string viewName, object data = null)
        {
            return View(viewName, string.Format(""), data);

        }
        protected string GetView(string viewName, object data = null)
        {
            try
            {
                using (var sw = new StringWriter())
                {
                    ControllerContext.Controller.ViewData.Model = data;
                    var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                    var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        protected ActionResult GetCustResultOrView(string viewName, string viewAjax, object data = null)
        {
            if (Request.IsAjaxRequest())
            {
                SetHtmlResponse(GetView(viewAjax, data));
                return GetResult();
            }
            return GetViewResult(viewName, data);
        }
        protected ActionResult GetCustResultOrView(ViewParam view)
        {
            if (Request.IsAjaxRequest())
            {
                SetHtmlResponse(GetView(view.ViewNameAjax, view.Data));
                return GetResult();
            }
            return GetViewResult(view.ViewName, view.Data);
        }
        protected ActionResult GetCustRedirect(string link)
        {
            var full_link = string.Format("{0}{1}", Request.UrlReferrer.OriginalString.Replace(Request.Url.AbsolutePath, ""), link);
            if (Request.IsAjaxRequest())
            {
                _isAjax = false;
                _linkRedirect = link;
                return GetResult();
            }
            else
            {
                return Redirect(link);
            }

        }
        protected ActionResult GetDialogResultOrView(ViewParam viewParam)
        {
            if (Request.IsAjaxRequest())
            {
                SetHtmlDialog(GetView(viewParam.ViewNameAjax ?? viewParam.ViewName, viewParam.Data), viewParam.Width ?? 600);
                return GetResult();
            }
            return View(viewParam.ViewName, viewParam.Data);
        }
        protected string GetReferrerOrDefault(string defaultPath)
        {
            if (Equals(Request.UrlReferrer, null))
                return defaultPath;

            return Request.UrlReferrer.ToString();
        }
        protected string GetRedirectOrDefault(string defaultPath)
        {
            var redirectPath = Utils.GetString(DATA, "RedirectPath");
            return string.IsNullOrEmpty(redirectPath)
                ? defaultPath
                : redirectPath;
        }
        protected ActionResult GetResultOrRedirectDefault(string defaultPath)
        {
            if (Request.IsAjaxRequest())
                return GetResult();
            return Redirect(GetRedirectOrDefault(defaultPath));
        }
        protected ActionResult GetResultOrReferrerDefault(string defaultPath)
        {
            if (Request.IsAjaxRequest())
                return GetResult();
            return Redirect(GetReferrerOrDefault(defaultPath));
        }
        protected ActionResult GetResultOrView(string viewName)
        {
            if (Request.IsAjaxRequest())
            {
                return GetResult();
            }
            return View(viewName);
        }
        #endregion
        #region Base Function

        private void SetData()
        {
            if (Request.IsAjaxRequest())
            {
                try
                {
                    var form = Request.Form;
                    DATA = form.ToDictionary(); //JsonConvert.DeserializeObject<Dictionary<string, string>>(form);
                }
                catch (Exception e)
                {
                    var ex = e.Message;
                    DATA = new Dictionary<string, string>();
                }

            }
            else
            {
                DATA = Request.Form.ToDictionary();
            }
            var dataUrls = GetDataFromRawUrl(Request.RawUrl);

            if (!Equals(dataUrls, null))
            {
                foreach (var item in dataUrls)
                {
                    DATA.Add(item.Key, item.Value);
                }
            }

        }
        protected void SetTitle(string _title)
        {
            ViewBag.Title = _title;
        }
        private Dictionary<string, string> GetDataFromRawUrl(string rawUrl)
        {
            var dic = new Dictionary<string, string>();
            try
            {
                var stringDatas = rawUrl.Split('?')[1].Split('&');
                for (int i = 0; i < stringDatas.Length; i++)
                {
                    var entries = stringDatas[i].Split('=');
                    var key = entries[0];
                    var value = entries[1];
                    dic.Add(key, value);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return dic;
        }
        protected void SetPaging(Dictionary<string, string> dic, string target = "", int totalElement = 0)
        {
            var paging = new Pagination
            {
                PageIndex = 1,
                PageSize = 10,
                PageStart = 1,
                PageTotal = 1,
                PageCount = 0,
                Target = target,
                Total = 0,
            };
            try
            {

                // paging.Total = totalElement;
                paging.PageIndex = Utils.GetInt(dic, "page") > 0
                                 ? Utils.GetInt(dic, "page")
                                 : 1;
                paging.PageSize = Utils.GetInt(dic, "np") > 0
                                ? Utils.GetInt(dic, "np")
                                : 10;
                paging.PageCount = totalElement % paging.PageSize;
                //if (totalElement > paging.PageSize)
                //{
                //    paging.PageTotal = totalElement / paging.PageSize;
                //    if (paging.PageCount > 0)
                //        paging.PageTotal++;
                //}
                //else
                //    paging.PageTotal = 1;
                //paging.PageStart = paging.PageSize * (paging.PageTotal - 1);
            }
            catch (Exception)
            {
                throw;
            }
            Paging = paging;
        }
        protected ActionResult FileResult(string path, string fileName)
        {
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(@path);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;
            }

        }
        public string SaveThumb(string base64Avatar, string fileName)
        {
            string PathServer = ControllerContext.HttpContext.Server.MapPath("~");
            string PathSeverNew = ConfigurationManager.AppSettings["AvatarUrl"];
            UploadFileClass objUpload = new UploadFileClass();
            objUpload = Utils.GetUploadFile(Server.MapPath(PathSeverNew), fileName, true);
            Utils.UploadImageWithBase64(base64Avatar, PathServer, PathSeverNew + objUpload.Virtualpath);
            return PathSeverNew + objUpload.Virtualpath;


        }
        protected ActionResult ExportExcelCommon<T>(List<T> items, Dictionary<string, string> headers, bool isshowheader, string teamplate, int rowstart, int colstart, string filename, List<ItemExcel> itemexcels)
        {
            teamplate = HttpContext.Server.MapPath(Path.Combine("~/Templates/", teamplate));
            var ftmp = DateTime.Now.ToString("ddMMyyyssmmhh");
            var down = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads", ftmp, filename);
            XLWorkbook MyWorkBook = new XLWorkbook();
            CUtils.ExportExcel<T>(out MyWorkBook, items, headers, isshowheader, teamplate, rowstart, colstart, itemexcels);
            Directory.CreateDirectory(Path.GetDirectoryName(down));
            MyWorkBook.SaveAs(down);
            return File(down, ".xlsx", filename);
        }
        protected void SetSession(int timeout = 0)
        {
            if (Equals(Session["Base_Users"], null))
            {
                var users = AccountRepository.UseInstance.GetListOrDefault();
                Session["Base_Users"] = users;
            }
            if (timeout > 0)
            {
                Session.Timeout = timeout;
            }
            ViewBag.CUser = Session["CurrentUser"];
        }
        protected void DestroySession()
        {
            Session["Base_Users"] = null;
            Session["LoginMessage"] = null;
        }
        protected User CUser
        {
            get
            {
                return (User)ViewBag.CUser;
            }
        }


        //protected User CUser;


        //protected void GetCUser()
        //{
        //    CUser = (User)Session["CurrentUser"];
        //    ViewBag.CUser = CUser;
        //}

        protected void RefreshSession()
        {
            Session["Base_Users"] = AccountRepository.UseInstance.GetListOrDefault();
        }
        #endregion
    }
}