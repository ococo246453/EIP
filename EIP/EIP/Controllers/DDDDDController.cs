using EIP.Models;
using EIP.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EIP.Controllers
{
    public class DDDDDController : Controller
    {
        dbEIPEntities db = new dbEIPEntities();
        // GET: DDDDD
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AskFor()
        {
            return View();
        }
        [HttpPost]
        public string AskForAjax(請假細項 k)  //
        {
            請假細項 a = new 請假細項
            {
                申請表編號 = k.申請表編號,
                EmployeeID = k.EmployeeID,
                信箱 = k.信箱,
                部門 = k.部門,
                假別ID = k.假別ID,
                請假時數 = (int)k.請假時數,
                開始日期 = k.開始日期,
                結束日期 = k.結束日期,
                申請日期 = k.申請日期,
                中文姓名 = k.中文姓名,
                職稱 = k.職稱,
                請假班別 = k.請假班別,
                代理人 = k.代理人,
                審核狀態 = k.審核狀態,               
            };
            db.請假細項.Add(a);
            db.SaveChanges();
            return "ok";
        }
        public ActionResult AskforList()
        {
            return View();
        }
        public JsonResult AskForListAjax()
        {
            var leaveform = db.請假細項.ToList().
                            Select(m=> new 
                            {
                                申請表編號 = m.申請表編號,
                                EmployeeID = m.EmployeeID,
                                信箱 = m.信箱,
                                部門 = m.部門,
                                假別ID = m.假別ID,
                                請假時數 = (int)m.請假時數,
                                開始日期 = m.開始日期,
                                結束日期 = m.結束日期,
                                申請日期 = m.申請日期,
                                中文姓名 = m.中文姓名,
                                職稱 = m.職稱,
                                請假班別 = m.請假班別,
                                代理人 = m.代理人,
                                審核狀態 = m.審核狀態,
                                假別1 = m.假別.假別1
                            });
            return Json(leaveform, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FindSingleData()
        {
            return View();
        }
        public JsonResult FindSingleDataAjax(int id)
        {
            var mm = db.請假細項.Select(x => new
            {
                申請表編號 = x.申請表編號,
                EmployeeID = x.EmployeeID,
                信箱 = x.信箱,
                部門 = x.部門,
                假別ID = x.假別ID,
                請假時數 = (int)x.請假時數,
                開始日期 = x.開始日期,
                結束日期 = x.結束日期,
                申請日期 = x.申請日期,
                中文姓名 = x.中文姓名,
                職稱 = x.職稱,
                請假班別 = x.請假班別,
                代理人 = x.代理人,
                審核狀態 = x.審核狀態,
                假別 = x.假別.假別1,                
            }).FirstOrDefault(C => C.EmployeeID == id);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteData(int id)
        {
            var deleteuser = db.請假細項.FirstOrDefault(m => m.EmployeeID == id);
            db.請假細項.Remove(deleteuser);
            db.SaveChanges();
            return Json(deleteuser, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateData()  //why
        {
            return View();
        }
        public JsonResult GetUpdateData(int? id)  //why
        {
            var mm = db.請假細項.Select(x => new
            {
                申請表編號 = x.申請表編號,
                EmployeeID = x.EmployeeID,
                信箱 = x.信箱,
                部門 = x.部門,
                假別ID = x.假別ID,
                請假時數 = (int)x.請假時數,
                開始日期 = x.開始日期,
                結束日期 = x.結束日期,
                申請日期 = x.申請日期,
                中文姓名 = x.中文姓名,
                職稱 = x.職稱,
                請假班別 = x.請假班別,
                代理人 = x.代理人,
                審核狀態 = x.審核狀態,              
            }).FirstOrDefault(C => C.EmployeeID == id);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UpdateDataAjax(AskForLeave mb)  //
        {
            請假細項 dba = new 請假細項()
            {
                申請表編號 = mb.申請表編號, 
                EmployeeID = mb.EmployeeID,
                信箱 = mb.信箱,
                部門 = mb.部門,
                假別ID = mb.假別ID,
                請假時數 = (int)mb.請假時數,
                開始日期 = mb.開始日期,
                結束日期 = mb.結束日期,
                申請日期 = mb.申請日期,
                中文姓名 = mb.中文姓名,
                職稱 = mb.職稱,
                請假班別 = mb.請假班別,
                代理人 = mb.代理人,
                審核狀態 = mb.審核狀態,
            };
            db.Entry<請假細項>(dba).State = EntityState.Modified;  //why
            db.SaveChanges();
            return Json(dba, JsonRequestBehavior.AllowGet);
        }


        public ActionResult 出缺勤系統()
        {
            return View();
        }
    }
}