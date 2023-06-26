using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeProject.Models;

public partial class UserList
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserPhone { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string LoginName { get; set; } = null!;

    public string LoginPassword { get; set; } = null!;

    public bool? LoginStatus { get; set; }

    public virtual ICollection<CustomerOrderDetail> CustomerOrderDetails { get; } = new List<CustomerOrderDetail>();

    public virtual ICollection<CustomerOrder> CustomerOrders { get; } = new List<CustomerOrder>();

    public virtual ICollection<CustomerReceipt> CustomerReceiptCancelUsers { get; } = new List<CustomerReceipt>();

    public virtual ICollection<CustomerReceipt> CustomerReceiptEntryUsers { get; } = new List<CustomerReceipt>();

    public virtual ICollection<PaymentPrint> PaymentPrints { get; } = new List<PaymentPrint>();

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchasePrint> PurchasePrints { get; } = new List<PurchasePrint>();

    public virtual ICollection<PurchaseRecord> PurchaseRecordCancelUsers { get; } = new List<PurchaseRecord>();

    public virtual ICollection<PurchaseRecord> PurchaseRecordEntryUsers { get; } = new List<PurchaseRecord>();

    public virtual ICollection<PurchaseReturn> PurchaseReturnCancelUsers { get; } = new List<PurchaseReturn>();

    public virtual ICollection<PurchaseReturnPrint> PurchaseReturnPrints { get; } = new List<PurchaseReturnPrint>();

    public virtual ICollection<PurchaseReturn> PurchaseReturnReturnUsers { get; } = new List<PurchaseReturn>();

    public virtual ICollection<ReceiptPrint> ReceiptPrints { get; } = new List<ReceiptPrint>();

    public virtual ICollection<SalesPrint> SalesPrints { get; } = new List<SalesPrint>();

    public virtual ICollection<SalesRecord> SalesRecordCancelledUsers { get; } = new List<SalesRecord>();

    public virtual ICollection<SalesRecord> SalesRecordEntryUsers { get; } = new List<SalesRecord>();

    public virtual ICollection<SalesReturn> SalesReturnCancelUsers { get; } = new List<SalesReturn>();

    public virtual ICollection<SalesReturnPrint> SalesReturnPrints { get; } = new List<SalesReturnPrint>();

    public virtual ICollection<SalesReturn> SalesReturnReturnUsers { get; } = new List<SalesReturn>();

    public virtual ICollection<StockEntry> StockEntryCancelUsers { get; } = new List<StockEntry>();

    public virtual ICollection<StockEntry> StockEntryEntryUsers { get; } = new List<StockEntry>();

    public virtual ICollection<SupplierPayment> SupplierPaymentCancelUsers { get; } = new List<SupplierPayment>();

    public virtual ICollection<SupplierPayment> SupplierPaymentEntryUsers { get; } = new List<SupplierPayment>();

    public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
}
public class UserRegister : UserList
{
    [Compare("LoginPassword", ErrorMessage = "password didn't match")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Required]
    public string ConfirmPassword { get; set; } = null!;
}
