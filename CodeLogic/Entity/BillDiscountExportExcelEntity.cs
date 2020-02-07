using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo1.CodeLogic.Entity
{
    public class BillDiscountExportExcelEntity
    {
        public int STT { get; set; }
        public string KhachHang { get; set; }
        public int ChietKhau { get; set; }
        public string SoHoaDon { get; set; }
        public double SoTien { get; set; }
        public double ThanhTien { get; set; }
        public string KhoanChietKhau { get; set; }
        public string ThoiDiem { get; set; }
        public double HoTroEvent { get; set; }
    }
}