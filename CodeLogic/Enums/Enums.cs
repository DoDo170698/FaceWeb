using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Enums
{
    public class Enums
    {
        public enum Role
        {
            [Description("Học viên")]
            Student = 1,
            [Description("Huấn luyện viên")]
            Coach = 2,
            [Description("Quản trị")]
            Admin = 3,
        }

        public enum SystemRole
        {
            [Description("Hệ thống")]
            System = 4,
        }

        public enum BaseStatus
        {
            [Description("Khóa")]
            UnActive = 1,
            [Description("Đã kích hoạt")]
            Active = 2,
        }


        public enum TypePath
        {
            [Description("Hình ảnh")]
            Image = 1,
            [Description("Video")]
            Video = 2,
        }


        public enum TypeContent
        {
            [Description("Lời chào")]
            LoiChao = 1,
            [Description("Nội dung Footer")]
            NoiDungFooter = 2,
            [Description("Mô tả dịch vụ")]
            MoTaDichVu = 3,
            //[Description("Mô tả chế độ dinh dưỡng")]
            //MoTaCDDD = 4,
            [Description("Mô tả đánh giá khách hàng")]
            MoTaDGKH = 5,
            [Description("Mô tả dịch vụ phổ biến")]
            MoTaDVPB = 6,
            [Description("Mô tả bài viết tiêu biểu")]
            MoTaBVTB = 7,
            [Description("Thông tin dãy số")]
            ThongTinDaySo = 8,
        }

        public enum TypeContentImg
        {
            [Description("Slide chính")]
            SlideMain = 1,
            [Description("Video chính")]
            VideoMain = 2,
            [Description("Hình ảnh Footer")]
            ImgFooter = 3,
            [Description("Hình ảnh thông tin dãy số")]
            ImgTTDS = 4,
            [Description("Hình ảnh đánh giá của khách hàng")]
            ImgDGKH = 5,
            [Description("Hình ảnh trang dịch vụ")]
            ImgDichVu = 6,
            [Description("Hình ảnh trang bài viết")]
            ImgBaiViet = 7,
            [Description("Hình ảnh trang chế độ dinh dưỡng")]
            ImgCDDD = 8,
            [Description("Hình ảnh trang lịch tập")]
            ImgLichTap = 9,
            [Description("Hình ảnh trang đăng ký tập thử")]
            ImgDKTT = 10,
            [Description("Hình ảnh trang góp ý phản hồi")]
            ImgGYPH = 11,
            [Description("Hình ảnh trang tài khoản")]
            ImgTaiKhoan = 12,
        }

        public enum WorkoutScheduleStatus
        {
            [Description("Chưa tập")]
            ChuaTap = 1,
            [Description("Đã tập")]
            DaTap = 2,
        }

        public enum PracticeDemoStatus
        {
            [Description("Chưa liên hệ")]
            ChuaLienHe = 1,
            [Description("Đã liên hệ, chưa đến tập")]
            DaLienHe = 2,
            [Description("Đã đến tập")]
            DaDenTap = 3,
        }
        public enum CommentStatus
        {
            [Description("Khóa")]
            NoActive = 1,
            [Description("Kích hoạt")]
            Active = 2,
            [Description("Đặc biệt")]
            YesActive = 3,
        }
        public enum TypeCategory
        {
            Blog = 1,
            //Nutrition = 2,
            Service = 2,
        }

        public enum Day
        {
            [Description("Thứ hai")]
            Hai = 2,
            [Description("Thứ ba")]
            Ba = 3,
            [Description("Thứ tư")]
            Bon = 4,
            [Description("Thứ năm")]
            Nam = 5,
            [Description("Thứ sáu")]
            Sau = 6,
            [Description("Thứ bảy")]
            Bay = 7,
            [Description("Chủ nhật")]
            CN = 8,
        }

        public enum TypeWorkoutSchedule
        {
            [Description("Tập nhóm")]
            Nhom = 1,
            [Description("Tập cá nhân")]
            CaNhan = 2,
        }

        public enum UserSessionStatus
        {

        }
        public enum CompareTypes
        {
            Equal = 1,
            NotEqual = 2,
            GreaterThan = 3,
            LowerThan = 4,
            In = 5,
            NotIn = 6,
            Like = 7,
        }
        public enum TypeSQl
        {
            String = 1,
            Number = 2
        }
        public enum TypeObject
        {
            Byte = 0,
            Int = 1,
            Long = 2,
            String = 3,
            Char = 4,
            Float = 5,
            Double = 7,
            DateTime = 8,
            DateTimeNull = 9,
            Bool = 10,
        }
        public enum OrderStatus
        {
            [Description("Nhận đơn")]
            Receive = 1,
            [Description("Giao hàng")]
            Delivery = 2,
            [Description("Trả phiếu nhập kho")]
            IRVReturn = 3,
            [Description("Thu thập chứng từ")]
            CollectVouchers = 4,
            [Description("Đã lập hóa đơn")]
            AccountingDept = 5,
        }
        public enum MvcStringRender
        {
            OrderStatus = 1,
            BillStatus = 2,
            OrderType = 3,
            Quater = 4
        }
        public enum ActionStatus
        {
            [Description("Tạo mới")]
            Create = 1,
            [Description("Cập nhật")]
            Update = 2,
            [Description("Xóa")]
            Delete = 3,
            [Description("Xem")]
            View = 4,
        }
        public enum OrderFileType
        {
            [Description("File trả PNK")]
            IRV = 1,
            [Description("File đơn hàng")]
            Order = 2,
            [Description("File bảng kê")]
            Declaration = 3,
            [Description("File hóa đơn")]
            Bill = 4,
            [Description("File hóa đơn chiết khấu")]
            BillDiscount = 5,
        }
        public enum AccountingDeptStatus
        {
            [Description("Đã nhận")]
            Receive = 1,
            [Description("Đã trả lại")]
            Reject = 2,
            [Description("Đã xác nhận")]
            Confirm = 3,
        }
        public enum OrderType
        {
            [Description("Đơn hàng")]
            Order = 1,
            [Description("Số lượng")]
            Amount = 2,
        }
        public enum Quater
        {
            [Description("Quý 1")]
            Quater1 = 1,
            [Description("Quý 2")]
            Quater2 = 2,
            [Description("Quý 3")]
            Quater3 = 3,
            [Description("Quý 4")]
            Quater4 = 4,
            [Description("Cả năm")]
            All = 5,
        }
        public enum IModule
        {
            [Description("Quản trị hệ thống")]
            QLHD_Manage = 1,
            [Description("Quản lý danh mục")]
            QLHD_Catalog = 2,
            [Description("Bán hàng theo đơn hàng")]
            QLHD_Order = 3,
            [Description("Bán hàng theo số lượng")]
            QLHD_AmountOrder = 4,
            [Description("Phòng kế toán")]
            QLHD_AccountingDept = 5,
            [Description("Chiết khấu")]
            QLHD_Discount = 6,

        }
        public enum IAccess
        {
            [Description("Quản lý hoá đơn")]
            QLHD = 1,
        }
        public enum BillStatus
        {
            [Description("Chưa thanh toán")]
            NotPay = 1,
            [Description("Đã thanh toán")]
            Payed = 2,
            [Description("Xác nhận thanh toán")]
            PayedConfirm = 3
        }

    }
}