using demo1.Controllers;
using demo1.Models.Fitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo1.Models.Admin;
using demo1.Models.Views;
using demo1.CodeLogic.Commons;
using static demo1.CodeLogic.Enums.Enums;
using demo1.CodeLogic.Attributes;
using demo1.Repository;
using demo1.CodeLogic;
using Role = demo1.CodeLogic.Enums.Enums.Role;
using demo1.CodeLogic.Customs;
using demo1.Models;

namespace demo1.Controllers
{
    public class HomeController : BaseController
    {

        [AuthorizeCustom(IRoles = new int[] { (int)Role.Student }, IRoleSystem = (int)SystemRole.System, INullUser = true)]
        public ActionResult Index()
        {
            //var blogNutritions = BlogRepository.UseInstance.GetListByFieldOrDefault("TypeCategory", (int)TypeCategory.Nutrition, (int)TypeObject.Int) ?? new List<Blog>();
            var blogs = BlogRepository.UseInstance.GetListByFieldOrDefault("TypeCategory", (int)TypeCategory.Blog, (int)TypeObject.Int) ?? new List<Blog>();
            var comments = CommentRepository.UseInstance.GetListOrDefault() ?? new List<Comment>();
            var categoryServices = Category.UseInstance.GetListByFieldOrDefault("TypeCategory", (int)TypeCategory.Service, (int)TypeObject.Int) ?? new List<Category>();
            var services = ServiceRepository.UseInstance.GetListByFieldOrDefault("Status", (int)BaseStatus.Active, (int)TypeObject.Int) ?? new List<Service>();
            var users = AccountRepository.UseInstance.GetListOrDefault() ?? new List<User>();
            var contents = ContentsRepository.UseInstance.GetListByFieldOrDefault("Status", (int)BaseStatus.Active, (int)TypeObject.Int);
            var contentImgs = ContentImgRepository.UseInstance.GetListByFieldOrDefault("Status", (int)BaseStatus.Active, (int)TypeObject.Int);

            return GetCustResultOrView(new ViewParam() {
                Data = new HomeModel()
                {
                    User = CUser,
                    ContentImgs = contentImgs,
                    Comments = comments,
                    Users = users,
                    Blogs = blogs,
                    Contents = contents,
                    CategoryServices = categoryServices,
                    BlogNutritions = new List<Blog>(),
                    Services = services,
                },
                ViewName="Index"
            });
        }

        [AuthorizeCustom(IRoles = new int[] { (int)Role.Student }, IRoleSystem = (int)SystemRole.System)]
        //[OutputCache(Duration = 60)]
        public ActionResult Account()
        {
            SetTitle("Tài khoản");
            ViewBag.CUser = CUser;
            var user = AccountRepository.UseInstance.GetById(CUser.ID) ?? new User();
            var userTranning = UserTranningRepository.UseInstance.GetFirstByFieldOrDefault("IDUser", CUser.ID, (int)TypeObject.Int);
            return GetCustResultOrView(new ViewParam()
            {
                Data = new HomeModel()
                {
                    User = user,
                    UserTranning = userTranning,
                },
                ViewName= "Account"
            });
        }

        [AuthorizeCustom(IRoleSystem = (int)SystemRole.System, INullUser = true)]
        public ActionResult Login()
        {
            SetUserLogin();
            ViewBag.CUser = CUser;
            var contentImg = ContentImgRepository.UseInstance.GetFirstByFieldsOrDefault(new List<CondParam>
            {
                new CondParam { Field = "Status", Value =(int)BaseStatus.Active, CompareType = (int)CompareTypes.Equal, TypeSQL = (int)TypeSQl.Number},
                new CondParam { Field = "Type", Value =(int)TypeContentImg.ImgTaiKhoan, CompareType = (int)CompareTypes.Equal, TypeSQL = (int)TypeSQl.Number},
            });
            SetTitle("Tài khoản");
            return GetCustResultOrView(new ViewParam()
            {
                Data = new HomeModel()
                {
                    ContentImg = contentImg,
                },
                ViewName = "Login"
            });
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if(Equals(user.Username,null) || Equals(user.Password, null))
            {
                SetError("Chưa nhập đủ tên đăng nhập và mật khẩu");
                return GetResultOrReferrerDefault("dang-nhap");
            }
            else
            {
                var userCheck = AccountRepository.UseInstance.GetFirstByFieldsOrDefault(new List<CondParam>
                {
                    new CondParam { Sql = string.Format("UserName = N'{0}' Or Phone = '{1}'",user.Username,user.Username) },
                    new CondParam { Field = "Password" , Value = user.Password, CompareType = (int)CompareTypes.Equal, TypeSQL = (int)TypeSQl.String }
                });
                if(userCheck.ID == 0)
                {
                    SetError("Sai tên đăng nhập, số điện thoại hoặc mật khẩu");
                    SetDataResponse("/dang-nhap");
                    return GetResultOrReferrerDefault("/dang-nhap");
                }
                else if(userCheck.Status == (int)BaseStatus.UnActive)
                {
                    SetWarn("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ với phòng tập");
                    SetDataResponse("/dang-nhap");
                    return GetResultOrReferrerDefault("/dang-nhap");
                }
                else
                {
                    if(SystemConfig.IsRole(userCheck,new int[] { (int)Role.Student }))
                    {
                        SetUserSession(userCheck);
                        SetSuccess("Đăng nhập thành công");
                        SetDataResponse("/trang-chu");
                        return GetResultOrReferrerDefault("/trang-chu");
                    }
                    else if (SystemConfig.IsRole(userCheck, new int[] { (int)Role.Admin, (int)SystemRole.System }))
                    {
                        SetUserSession(userCheck);
                        SetSuccess("Đăng nhập thành công");
                        SetDataResponse("/quan-tri");
                        return GetResultOrReferrerDefault("/quan-tri");
                    }
                    else
                    {
                        SetUserSession(userCheck);
                        SetSuccess("Đăng nhập thành công");
                        SetDataResponse("/quan-tri/lich-dang-ki-ca-nhan");
                        return GetResultOrReferrerDefault("/quan-tri/lich-dang-ki-ca-nhan");
                    }
                }
            }

        }

        [AuthorizeCustom(IRoles = new int[] { (int)Role.Student }, IRoleSystem = (int)SystemRole.System)]
        public ActionResult LogOut(User user)
        {
            DestroySessionUser(user);
            return RedirectToAction("Login");
        }

        [AuthorizeCustom(IRoles = new int[] { (int)Role.Student }, IRoleSystem = (int)SystemRole.System, INullUser = true)]
        public ActionResult SignIn()
        {

            var user = new User().BindData(DATA);
            user.Status = (int)BaseStatus.Active;
            user.Created = DateTime.Now;
            user.CreatedBy = CUser == null ? 0 : CUser.ID;

            var (check, mess) = IsValidate(user);
            if (check)
            {
                SetError(mess);
            }
            else if (AccountRepository.UseInstance.Insert(user))
            {
                SetSuccess("Đăng ký tài khoản thành công");
                UserRoleRepository.UseInstance.Insert(new UserRole
                {
                    IDRole = (int)Role.Student,
                    IDUser = user.ID,
                    Created = DateTime.Now,
                    CreatedBy = CUser.ID,
                });

            }
            else
            {
                SetError("Đăng ký tài khoản không thành công");
            }
            SetDataResponse("/dang-nhap");
            return GetResultOrRedirectDefault("/dang-nhap");
        }

        public ActionResult Change()
        {

            var ID = Utils.GetInt(DATA, "ID");
            var user = AccountRepository.UseInstance.GetById(ID);
            user = user.BindData(DATA, false);
            user.Updated = DateTime.Now;
            user.UpdatedBy = CUser == null ? 0 : CUser.ID;

            var (check, mess) = IsValidate(user);
            if (check)
            {
                SetError(mess);
            }
            else if (AccountRepository.UseInstance.Update(user))
            {
                SetUserSession(user);
                SetSuccess("Cập nhật tài khoản thành công");
            }
            else
            {
                SetError("Cập nhật tài khoản không thành công");
            }
            SetDataResponse("/tai-khoan");
            return GetResultOrRedirectDefault("/tai-khoan");
        }

        [AuthorizeCustom(IRoles = new int[] { (int)Role.Student }, IRoleSystem = (int)SystemRole.System)]
        public ActionResult ChangePassword()
        {

            var ID = Utils.GetInt(DATA, "ID");
            var user = AccountRepository.UseInstance.GetById(ID);
            var password = Utils.GetString(DATA, "Password");
            var passwordOld = Utils.GetString(DATA, "PasswordOld");
            var passwordConf = Utils.GetString(DATA, "PasswordConf");
            if (password.IsNullOrEmpty() || passwordOld.IsNullOrEmpty() || passwordConf.IsNullOrEmpty())
            {
                SetError("Không được để trống");
                SetDataResponse("/tai-khoan");
                return GetResultOrRedirectDefault("/tai-khoan");
            }
            else if (CUtils.CheckUtf8(password) || CUtils.CheckUtf8(passwordOld) || CUtils.CheckUtf8(passwordConf))
            {
                SetError("Không được viết kí tự đặc biệt");
                SetDataResponse("/tai-khoan");
                return GetResultOrRedirectDefault("/tai-khoan");
            }
            else if (!passwordConf.Equals(password))
            {
                SetError("Xác nhận mật khẩu không giống mật khẩu mới");
                SetDataResponse("/tai-khoan");
                return GetResultOrRedirectDefault("/tai-khoan");
            }
            else if (!user.Password.Equals(passwordOld))
            {
                SetError("Mật khẩu cũ không chính xác");
                SetDataResponse("/tai-khoan");
                return GetResultOrRedirectDefault("/tai-khoan");
            }
            user.Password = password;
            user.Updated = DateTime.Now;
            user.UpdatedBy = CUser == null ? 0 : CUser.ID;

            
            if (AccountRepository.UseInstance.Update(user))
            {
                SetSuccess("Đổi mật khẩu thành công");
            }
            else
            {
                SetError("Đổi mật khẩu không thành công");
            }
            SetDataResponse("/tai-khoan");
            return GetResultOrRedirectDefault("/tai-khoan");
        }

        private (bool,string) IsValidate(User user, bool isUpdated = false)
        {
            if ((user.Password.IsNullOrEmpty() || user.Username.IsNullOrEmpty()) && isUpdated)
            {
                return (true, "Không được để trống tên đăng nhập và mật khẩu");
            }
            else if ((CUtils.CheckUtf8(user.Password) || CUtils.CheckUtf8(user.Username)) && isUpdated)
            {
                return (true, "Mật khẩu không được viết kí tự đặc biệt");
            }
            else if ((user.Name.IsNullOrEmpty())&& isUpdated)
            {
                return (true, "Không được để trống tên người dùng");
            }
            else if (user.Phone.IsNullOrEmpty())
            {
                return (true, "Không được để trống số điện thoại");
            }
            if (!isUpdated)
            {
                var checkUsername = AccountRepository.UseInstance.GetFirstByFieldsOrDefault(new List<CondParam>
                {
                     new CondParam { Field="UserName", Value=user.Username.Trim(), CompareType= (int)CompareTypes.Equal, TypeSQL = (int)TypeSQl.String },
                    new CondParam { Field="ID", Value=user.ID, CompareType= (int)CompareTypes.NotEqual, TypeSQL = (int)TypeSQl.Number, NotUsed = user.ID == 0 },
                });
                if (checkUsername.ID > 0)
                {
                    return (true, "Tên đăng nhập đã tồn tại");
                }
            }
            var checkPhone = AccountRepository.UseInstance.GetFirstByFieldsOrDefault(new List<CondParam>
            {
                new CondParam { Field="Phone", Value=user.Phone.Trim(), CompareType= (int)CompareTypes.Equal, TypeSQL = (int)TypeSQl.String },
                new CondParam { Field="ID", Value=user.ID, CompareType= (int)CompareTypes.NotEqual, TypeSQL = (int)TypeSQl.Number, NotUsed = user.ID == 0 },
            });
            if (checkPhone.ID > 0)
            {
                return (true, "Số điện thoại đã được đăng ký");
            }


            return (false,string.Empty);
        }

        protected void SetUserSession(User user)
        {
            Session["CurrentUser"] = user;
            ViewBag.CUser = user;
        }
        protected void SetUserLogin()
        {
            ViewBag.LoginMessage = Session["LoginMessage"];
            ViewBag.CUser = Session["CurrentUser"];
        }
        protected void DestroySessionUser(User user)
        {
            Session["CurrentUser"] = null;
            Session["LoginMessage"] = null;
            Session["Base_Users"] = null;
            ViewBag.CUser = null;
        }
    }
}