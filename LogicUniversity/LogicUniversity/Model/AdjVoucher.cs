//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicUniversity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdjVoucher
    {
        public AdjVoucher()
        {
            this.AdjVoucherItems = new HashSet<AdjVoucherItem>();
        }
    
        public int AdjVoucherID { get; set; }
        public string StoreEmployeeID { get; set; }
    
        public virtual StoreEmployee StoreEmployee { get; set; }
        public virtual ICollection<AdjVoucherItem> AdjVoucherItems { get; set; }
    }
}
