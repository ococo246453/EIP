//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EIP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class 佈告欄
    {
        public int 佈告欄ID { get; set; }
        public int EmployeeID { get; set; }
        public string 中文姓名 { get; set; }
        public string 佈告欄標題 { get; set; }
        public string 佈告欄內容 { get; set; }
        public System.DateTime 發布日期 { get; set; }
        public string 總筆數 { get; set; }
    }
}
