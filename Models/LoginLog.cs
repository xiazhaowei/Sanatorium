//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sanatorium.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginLog
    {
        public int Id { get; set; }
        public System.DateTime LoginTime { get; set; }
        public string Ip { get; set; }
        public string Client { get; set; }
        public int ManagerId { get; set; }
    
        public virtual Manager Manager { get; set; }
    }
}
