using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebsiteBanHang.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int mahang { get; set; }

        [Display(Name = "Tên hàng")]
        public string tenhang { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public Double giaban { get; set; }
        [Display(Name = "Số lượng")]
        public int isoluong { get; set; }
        [Display(Name = "Thành tiền")]
        public double dthanhtien
        {
            get { return isoluong * giaban; }
        }
        public GioHang(int id)
        {
            mahang = id;
            Hang hang = data.Hangs.Single(n => n.mahang == mahang);
            tenhang = hang.tenhang;
            hinh = hang.hinh;
            giaban = double.Parse(hang.giaban.ToString());
            isoluong = 1;
        }
    }
}