//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER_ORDERS
    {
        public int CUSTID { get; set; }
        public string PRODID { get; set; }
        public string DESCRIPTION { get; set; }
        public string SER_NUM { get; set; }
        public Nullable<System.DateTime> BUY_DATE { get; set; }
        public Nullable<System.DateTime> PAID_DATE { get; set; }
        public int LIST_PRICE { get; set; }
        public Nullable<int> PRICE { get; set; }
        public decimal DISCOUNT { get; set; }
        public Nullable<System.DateTime> SVC_START { get; set; }
        public Nullable<System.DateTime> SVC_END { get; set; }
        public Nullable<int> SVC_PRICE { get; set; }
        public Nullable<System.DateTime> SVC_PAID_DATE { get; set; }
        public decimal C_ASSOC_ROW { get; set; }
    
        public virtual CUSTOMER CUSTOMER { get; set; }
    }
}
