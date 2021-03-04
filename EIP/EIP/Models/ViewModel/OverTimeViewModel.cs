using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EIP.Models.ViewModel
{
    public class OverTimeViewModel
    {
        public int EmployeeID { get; set; }
        public string 已用可用 { get; set; }
        public string 開始時間 { get; set; }
        public string 結束時間 { get; set; }
        public string 總共時數 { get; set; }
        public string 加班類別 { get; set; }
        public string 事由說明 { get; set; }

    }
}