//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pos_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_GetFrontStockByProductDate
    {
        public int FKProduct { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string DateCreate { get; set; }
        public string Barcode { get; set; }
        public int FKProductDetails { get; set; }
        public decimal ActionQty { get; set; }
        public decimal PackSize { get; set; }
        public string DocNo { get; set; }
        public int DocDtlNumber { get; set; }
        public string DocRefer { get; set; }
        public Nullable<int> DocReferDtlNumber { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public bool IsPlus { get; set; }
        public string TransName { get; set; }
        public decimal CostOnlyPerUnit { get; set; }
        public decimal SellPricePerUnit { get; set; }
        public int ProdId { get; set; }
        public string ThaiName { get; set; }
        public int StockId { get; set; }
        public int FKTransactionType { get; set; }
    }
}