using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class HangController : Controller
    {
        // GET: Hang       
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListSach()
        {
            var all_sach = from ss in data.Hangs select ss;
            return View(all_sach);
        }
        public ActionResult Detail(int id)
        {
            var D_sach = data.Hangs.Where(m => m.mahang == id).First();
            return View(D_sach);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, Hang s)
        {
            var E_tenhang = collection["tenhang"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]); 
            var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycapnhat"]); 
            var E_soluongton = Convert.ToInt32(collection["soluongton"]); 
            if (string.IsNullOrEmpty(E_tenhang))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tenhang = E_tenhang.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_giaban;
                s.ngaycapnhat = E_ngaycapnhat;
                s.soluongton = E_soluongton;
                data.Hangs.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListSach");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_sach = data.Hangs.First(m => m.mahang == id);
            return View(E_sach);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)

        {
            var E_hang = data.Hangs.First(m => m.mahang == id);
            var E_tenhang = collection["tenhang"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]); var E_ngaycapnhat = Convert.ToDateTime(collection["ngaycatnhat"]); var E_soluongton = Convert.ToInt32(collection["soluongton"]); E_hang.mahang = id;
            if (string.IsNullOrEmpty(E_tenhang))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_hang.tenhang = E_tenhang;
                E_hang.hinh = E_hinh;
                E_hang.giaban = E_giaban;
                E_hang.ngaycapnhat = E_ngaycapnhat;
                E_hang.soluongton = E_soluongton;
                UpdateModel(E_hang);
                data.SubmitChanges();
                return RedirectToAction("ListSach");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_sach = data.Hangs.First(m => m.mahang == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sach = data.Hangs.Where(m => m.mahang == id).First(); data.Hangs.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("ListSach");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

    }
}