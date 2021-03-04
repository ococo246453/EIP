using EIP.Models;
using EIP.Models.GenericRepository;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class BulletinBoardController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        EIPRepository<佈告欄> er = new EIPRepository<佈告欄>();
        // GET: BulletinBoard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BulletinBoard()
        {
            return View();
        }


        // 佈告欄總表
        public JsonResult BulletinBoardList()
        {
            var 佈告欄 = (from b in db.佈告欄
                        orderby b.佈告欄ID descending
                        select new
                        {
                            佈告欄ID = b.佈告欄ID,
                            EmployeeID = b.EmployeeID,
                            中文姓名 = b.中文姓名,
                            佈告欄標題 = b.佈告欄標題,
                            佈告欄內容 = b.佈告欄內容,
                            發布日期 = b.發布日期,
                            總比數 = db.佈告欄.Count()
                        }).ToList();

            return Json(佈告欄.Take(10), JsonRequestBehavior.AllowGet);
        }


        // 新增佈告欄
        public JsonResult CreateBulletinBoard(BulletinBoardViewModel CBB)
        {
            佈告欄 BB = new 佈告欄()
            {
                EmployeeID = Convert.ToInt32(Request.Cookies["AutoLg"]["id"]),
                中文姓名 = Server.UrlDecode(Request.Cookies["AutoLg"]["Name"]),
                佈告欄標題 = CBB.佈告欄標題,
                佈告欄內容 = CBB.佈告欄內容,
                發布日期 = CBB.發布日期,
            };
            er.Create(BB);
            return Json(BB, JsonRequestBehavior.AllowGet);
        }


        // 搜尋指定佈告欄

        [HttpGet]
        public JsonResult SearchOneBulletinBoard(int id)
        {
            佈告欄 sobb = db.佈告欄.FirstOrDefault(m=>m.佈告欄ID==id);
            BulletinBoardViewModel bb = new BulletinBoardViewModel
            {
                佈告欄ID = sobb.佈告欄ID,
                EmployeeID = sobb.EmployeeID,
                中文姓名 = sobb.中文姓名,
                佈告欄標題 = sobb.佈告欄標題,
                佈告欄內容 = sobb.佈告欄內容,
                發布日期 = sobb.發布日期
            };
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        // 修改佈告欄

        [HttpPost]
        public JsonResult BulletinBoardEdit(BulletinBoardViewModel bbvm)
        {
            佈告欄 bb = new 佈告欄()
            {
                佈告欄ID = bbvm.佈告欄ID,
                EmployeeID = bbvm.EmployeeID,
                中文姓名 = bbvm.中文姓名,
                佈告欄標題 = bbvm.佈告欄標題,
                佈告欄內容 = bbvm.佈告欄內容,
                發布日期 = bbvm.發布日期
            };
            er.Update(bb);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }

        // 刪除佈告欄

        [HttpGet]
        public JsonResult BulletinBoardDelete(int id)
        {
            佈告欄 bb = db.佈告欄.Find(id);
            er.Delete(id);
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        // 搜尋佈告欄
        public JsonResult BulletinBoardSearch(string name)
        {

            var bb = from b in db.佈告欄
                     select b;
            if (!String.IsNullOrEmpty(name))
            {
                bb = bb.Where(a => a.中文姓名.Contains(name));
            }

            //佈告欄 bb = db.佈告欄.FirstOrDefault(m => m.中文姓名.Contains(name));
            return Json(bb, JsonRequestBehavior.AllowGet);
        }


        public JsonResult BBPage(int arrow)
        {

            var bb = from b in db.佈告欄
                     orderby b.佈告欄ID descending
                      select new BulletinBoardViewModel
                      {
                          佈告欄ID = b.佈告欄ID,
                          EmployeeID = b.EmployeeID,
                          中文姓名 = b.中文姓名,
                          佈告欄標題 = b.佈告欄標題,
                          佈告欄內容 = b.佈告欄內容,
                          發布日期 = b.發布日期
                      };
            var bbvm = bb.Skip((arrow - 1) * 10).Take(10);
            return Json(bbvm, JsonRequestBehavior.AllowGet);
        }
    }
}