using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CafeProject.Models;

public partial class CafeteriaDatabaseContext : DbContext
{
    public CafeteriaDatabaseContext()
    {
    }

    public CafeteriaDatabaseContext(DbContextOptions<CafeteriaDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cafe> Caves { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

    public virtual DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }

    public virtual DbSet<CustomerReceipt> CustomerReceipts { get; set; }

    public virtual DbSet<CustomerReceiptView> CustomerReceiptViews { get; set; }

    public virtual DbSet<PaymentMode> PaymentModes { get; set; }

    public virtual DbSet<PaymentPrint> PaymentPrints { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCatView> ProductCatViews { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

    public virtual DbSet<PurchasePrint> PurchasePrints { get; set; }

    public virtual DbSet<PurchaseRecord> PurchaseRecords { get; set; }

    public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }

    public virtual DbSet<PurchaseReturnDetail> PurchaseReturnDetails { get; set; }

    public virtual DbSet<PurchaseReturnPrint> PurchaseReturnPrints { get; set; }

    public virtual DbSet<ReceiptPrint> ReceiptPrints { get; set; }

    public virtual DbSet<ReceiptPrintView> ReceiptPrintViews { get; set; }

    public virtual DbSet<RoleList> RoleLists { get; set; }

    public virtual DbSet<SalesDetail> SalesDetails { get; set; }

    public virtual DbSet<SalesDetailView> SalesDetailViews { get; set; }

    public virtual DbSet<SalesPrint> SalesPrints { get; set; }

    public virtual DbSet<SalesRecord> SalesRecords { get; set; }

    public virtual DbSet<SalesRecordView> SalesRecordViews { get; set; }

    public virtual DbSet<SalesReturn> SalesReturns { get; set; }

    public virtual DbSet<SalesReturnDetail> SalesReturnDetails { get; set; }

    public virtual DbSet<SalesReturnPrint> SalesReturnPrints { get; set; }

    public virtual DbSet<StockEntry> StockEntries { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }

    public virtual DbSet<UserList> UserLists { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserRoleView> UserRoleViews { get; set; }

    public virtual DbSet<UsersRoleSelectView> UsersRoleSelectViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=CafeConndb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cafe>(entity =>
        {
            entity.HasKey(e => e.CafeId).HasName("PK__Cafe__DD4C137D63B190F5");

            entity.ToTable("Cafe");

            entity.Property(e => e.CafeId).HasColumnName("CafeID");
            entity.Property(e => e.CafeAddress).HasMaxLength(50);
            entity.Property(e => e.CafeMoto).HasMaxLength(255);
            entity.Property(e => e.CafeName).HasMaxLength(100);
            entity.Property(e => e.CafePhone).HasMaxLength(30);
            entity.Property(e => e.CurrentDate).HasColumnType("date");
            entity.Property(e => e.CurrentFiscalYear).HasMaxLength(30);
            entity.Property(e => e.Website).HasMaxLength(255);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8FBEE0163");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerEmail).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPan).HasMaxLength(50);
            entity.Property(e => e.CustomerPhone).HasMaxLength(30);
            entity.Property(e => e.CustomerStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<CustomerOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Customer__C3905BCFCB66173E");

            entity.ToTable("CustomerOrder");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.CustomerReference).HasMaxLength(50);
            entity.Property(e => e.CustomerType).HasMaxLength(20);
            entity.Property(e => e.FisicalYear).HasMaxLength(20);
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderTime).HasMaxLength(20);

            entity.HasOne(d => d.OrderUser).WithMany(p => p.CustomerOrders)
                .HasForeignKey(d => d.OrderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerO__Order__08B54D69");
        });

        modelBuilder.Entity<CustomerOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__Customer__08D097A36425742A");

            entity.ToTable("CustomerOrderDetail");

            entity.Property(e => e.ActionDate).HasColumnType("date");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Ordered')");
            entity.Property(e => e.Quatity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ActionUser).WithMany(p => p.CustomerOrderDetails)
                .HasForeignKey(d => d.ActionUserId)
                .HasConstraintName("FK__CustomerO__Actio__0F624AF8");

            entity.HasOne(d => d.Order).WithMany(p => p.CustomerOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerO__Order__0B91BA14");

            entity.HasOne(d => d.Product).WithMany(p => p.CustomerOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerO__Produ__0C85DE4D");

            entity.HasOne(d => d.Sales).WithMany(p => p.CustomerOrderDetails)
                .HasForeignKey(d => d.SalesId)
                .HasConstraintName("FK__CustomerO__Sales__10566F31");
        });

        modelBuilder.Entity<CustomerReceipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__Customer__CC08C4202BC89D44");

            entity.ToTable("CustomerReceipt");

            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.ReceiptDate).HasColumnType("date");
            entity.Property(e => e.ReceiptTime).HasMaxLength(20);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CancelUser).WithMany(p => p.CustomerReceiptCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__CustomerR__Cance__44FF419A");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerReceipts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerR__Custo__4316F928");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.CustomerReceiptEntryUsers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerR__Entry__440B1D61");

            entity.HasOne(d => d.Mode).WithMany(p => p.CustomerReceipts)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CustomerR__ModeI__4222D4EF");
        });

        modelBuilder.Entity<CustomerReceiptView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CustomerReceiptView");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancelEntryUser).HasMaxLength(50);
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPan).HasMaxLength(50);
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntryUser).HasMaxLength(50);
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.ReceiptDate).HasColumnType("date");
            entity.Property(e => e.ReceiptTime).HasMaxLength(20);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(19, 2)");
        });

        modelBuilder.Entity<PaymentMode>(entity =>
        {
            entity.HasKey(e => e.ModeId).HasName("PK__PaymentM__D83F75C4080D007F");

            entity.ToTable("PaymentMode");

            entity.HasIndex(e => e.PaymentMethod, "UQ__PaymentM__4D355D492FFC299B").IsUnique();

            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentPrint>(entity =>
        {
            entity.HasKey(e => new { e.PaymentId, e.PrintDate, e.PrintTime }).HasName("PK__PaymentP__DC80C510A9741538");

            entity.ToTable("PaymentPrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentPrints)
                .HasForeignKey(d => d.PaymentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentPr__Payme__3E52440B");

            entity.HasOne(d => d.PrintUser).WithMany(p => p.PaymentPrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentPr__Print__3F466844");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CDFBF6C29A");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductCode, "UQ__Product__2F4E024FE342A9DD").IsUnique();

            entity.HasIndex(e => e.ProductName, "UQ__Product__DD5A978AEB83DE48").IsUnique();

            entity.Property(e => e.IsAvailable)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ProductCode).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.RackNumber).HasMaxLength(30);
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(10);
            entity.Property(e => e.WaitingTime).HasMaxLength(100);

            entity.HasOne(d => d.ProductCat).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Product__5165187F");
        });

        modelBuilder.Entity<ProductCatView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProductCatView");

            entity.Property(e => e.CatName).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.RackNumber).HasMaxLength(30);
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(10);
            entity.Property(e => e.WaitingTime).HasMaxLength(100);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__ProductC__6A1C8AFA20182397");

            entity.ToTable("ProductCategory");

            entity.HasIndex(e => e.CatName, "UQ__ProductC__9C61AB262549D02C").IsUnique();

            entity.Property(e => e.CatName).HasMaxLength(50);
        });

        modelBuilder.Entity<PurchaseDetail>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseId, e.ProductId }).HasName("PK__Purchase__A04AA7D2C1A6B28F");

            entity.ToTable("PurchaseDetail");

            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__Produ__5AEE82B9");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseDetails)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseD__Purch__59FA5E80");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Purchase__C3905BCFD3D2AD5B");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderTime).HasMaxLength(20);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Entry__5EBF139D");

            entity.HasOne(d => d.Supplier).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Suppl__5DCAEF64");
        });

        modelBuilder.Entity<PurchaseOrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK__Purchase__08D097A39C554A79");

            entity.ToTable("PurchaseOrderDetail");

            entity.Property(e => e.Quatity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Order__619B8048");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseO__Produ__628FA481");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseOrderDetails)
                .HasForeignKey(d => d.PurchaseId)
                .HasConstraintName("FK__PurchaseO__Purch__6383C8BA");
        });

        modelBuilder.Entity<PurchasePrint>(entity =>
        {
            entity.HasKey(e => new { e.PurchaseId, e.PrintDate, e.PrintTime }).HasName("PK__Purchase__2CDFC496C6B1F617");

            entity.ToTable("PurchasePrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.PrintUser).WithMany(p => p.PurchasePrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseP__Print__6754599E");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchasePrints)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseP__Purch__66603565");
        });

        modelBuilder.Entity<PurchaseRecord>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BBE525C4B18");

            entity.ToTable("PurchaseRecord");

            entity.Property(e => e.PurchaseId).ValueGeneratedNever();
            entity.Property(e => e.AdditionalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntryDate).HasColumnType("date");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.PurchaseTime).HasMaxLength(20);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatableAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CancelUser).WithMany(p => p.PurchaseRecordCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__PurchaseR__Cance__5629CD9C");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.PurchaseRecordEntryUsers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Entry__571DF1D5");

            entity.HasOne(d => d.Mode).WithMany(p => p.PurchaseRecords)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__ModeI__5535A963");
        });

        modelBuilder.Entity<PurchaseReturn>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__Purchase__F445E9A86520B6EA");

            entity.ToTable("PurchaseReturn");

            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.ReturnTime).HasMaxLength(20);

            entity.HasOne(d => d.CancelUser).WithMany(p => p.PurchaseReturnCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__PurchaseR__Cance__6D0D32F4");

            entity.HasOne(d => d.Mode).WithMany(p => p.PurchaseReturns)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__ModeI__6B24EA82");

            entity.HasOne(d => d.Purchase).WithMany(p => p.PurchaseReturns)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Purch__6A30C649");

            entity.HasOne(d => d.ReturnUser).WithMany(p => p.PurchaseReturnReturnUsers)
                .HasForeignKey(d => d.ReturnUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Retur__6C190EBB");
        });

        modelBuilder.Entity<PurchaseReturnDetail>(entity =>
        {
            entity.HasKey(e => new { e.ReturnId, e.ProductId }).HasName("PK__Purchase__3F0525C45D4094F3");

            entity.ToTable("PurchaseReturnDetail");

            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.PurchaseReturnDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Produ__6FE99F9F");
        });

        modelBuilder.Entity<PurchaseReturnPrint>(entity =>
        {
            entity.HasKey(e => new { e.ReturnId, e.PrintDate, e.PrintTime }).HasName("PK__Purchase__B3904680FACAFA56");

            entity.ToTable("PurchaseReturnPrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.PrintUser).WithMany(p => p.PurchaseReturnPrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Print__73BA3083");

            entity.HasOne(d => d.Return).WithMany(p => p.PurchaseReturnPrints)
                .HasForeignKey(d => d.ReturnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PurchaseR__Retur__72C60C4A");
        });

        modelBuilder.Entity<ReceiptPrint>(entity =>
        {
            entity.HasKey(e => e.PrintId).HasName("PK__ReceiptP__26C7BA7DDC970681");

            entity.ToTable("ReceiptPrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.PrintUser).WithMany(p => p.ReceiptPrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReceiptPr__Print__09746778");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptPrints)
                .HasForeignKey(d => d.ReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ReceiptPr__Recei__0880433F");
        });

        modelBuilder.Entity<ReceiptPrintView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReceiptPrintView");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPan).HasMaxLength(50);
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);
            entity.Property(e => e.PrintUser).HasMaxLength(50);
            entity.Property(e => e.ReceiptDate).HasColumnType("date");
            entity.Property(e => e.ReceiptTime).HasMaxLength(20);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(19, 2)");
        });

        modelBuilder.Entity<RoleList>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleList__8AFACE1A8E053267");

            entity.ToTable("RoleList");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<SalesDetail>(entity =>
        {
            entity.HasKey(e => e.SalesDetailId).HasName("PK__SalesDet__391C577270EDBB73");

            entity.ToTable("SalesDetail");

            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesDeta__Produ__308E3499");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesDeta__Sales__2F9A1060");
        });

        modelBuilder.Entity<SalesDetailView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SalesDetailView");

            entity.Property(e => e.AdditionalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.CancelledUser).HasMaxLength(50);
            entity.Property(e => e.CatName).HasMaxLength(50);
            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPan).HasMaxLength(50);
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntryDate).HasColumnType("date");
            entity.Property(e => e.EntryUser).HasMaxLength(50);
            entity.Property(e => e.FisicalYear).HasMaxLength(30);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ProductCode).HasMaxLength(100);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.RackNumber).HasMaxLength(30);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.SalesTime).HasMaxLength(20);
            entity.Property(e => e.SalseDate).HasColumnType("date");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(10);
            entity.Property(e => e.VatAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatableAmt).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SalesPrint>(entity =>
        {
            entity.HasKey(e => new { e.SalesId, e.PrintDate, e.PrintTime }).HasName("PK__SalesPri__8E87541A14D9ABDE");

            entity.ToTable("SalesPrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.PrintUser).WithMany(p => p.SalesPrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesPrin__Print__04E4BC85");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesPrints)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesPrin__Sales__03F0984C");
        });

        modelBuilder.Entity<SalesRecord>(entity =>
        {
            entity.HasKey(e => e.SalesId).HasName("PK__SalesRec__C952FB3296B7EB21");

            entity.ToTable("SalesRecord");

            entity.Property(e => e.AdditionalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntryDate).HasColumnType("date");
            entity.Property(e => e.FisicalYear).HasMaxLength(30);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SalesTime).HasMaxLength(20);
            entity.Property(e => e.SalseDate).HasColumnType("date");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatableAmt).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CancelledUser).WithMany(p => p.SalesRecordCancelledUsers)
                .HasForeignKey(d => d.CancelledUserId)
                .HasConstraintName("FK__SalesReco__Cance__7C4F7684");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesRecords)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__SalesReco__Custo__7B5B524B");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.SalesRecordEntryUsers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesReco__Entry__7D439ABD");

            entity.HasOne(d => d.Mode).WithMany(p => p.SalesRecords)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesReco__ModeI__76969D2E");
        });

        modelBuilder.Entity<SalesRecordView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SalesRecordView");

            entity.Property(e => e.AdditionalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.CancelledUser).HasMaxLength(50);
            entity.Property(e => e.CustomerAddress).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.CustomerPan).HasMaxLength(50);
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntryDate).HasColumnType("date");
            entity.Property(e => e.EntryUser).HasMaxLength(50);
            entity.Property(e => e.FisicalYear).HasMaxLength(30);
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.SalesTime).HasMaxLength(20);
            entity.Property(e => e.SalseDate).HasColumnType("date");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VatableAmt).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<SalesReturn>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__SalesRet__F445E9A82C6060E7");

            entity.ToTable("SalesReturn");

            entity.Property(e => e.ReturnId).ValueGeneratedNever();
            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.ReturnDate).HasColumnType("date");
            entity.Property(e => e.ReturnTime).HasMaxLength(20);

            entity.HasOne(d => d.CancelUser).WithMany(p => p.SalesReturnCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__SalesRetu__Cance__160F4887");

            entity.HasOne(d => d.Mode).WithMany(p => p.SalesReturns)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__ModeI__1332DBDC");

            entity.HasOne(d => d.ReturnUser).WithMany(p => p.SalesReturnReturnUsers)
                .HasForeignKey(d => d.ReturnUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Retur__14270015");

            entity.HasOne(d => d.Sales).WithMany(p => p.SalesReturns)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Sales__151B244E");
        });

        modelBuilder.Entity<SalesReturnDetail>(entity =>
        {
            entity.HasKey(e => new { e.ReturnId, e.ProductId }).HasName("PK__SalesRet__3F0525C4B5AB0152");

            entity.ToTable("SalesReturnDetail");

            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SalesReturnDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Produ__19DFD96B");

            entity.HasOne(d => d.Return).WithMany(p => p.SalesReturnDetails)
                .HasForeignKey(d => d.ReturnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Retur__18EBB532");
        });

        modelBuilder.Entity<SalesReturnPrint>(entity =>
        {
            entity.HasKey(e => new { e.ReturnId, e.PrintDate, e.PrintTime }).HasName("PK__SalesRet__B39046807F5E31F2");

            entity.ToTable("SalesReturnPrint");

            entity.Property(e => e.PrintDate).HasColumnType("date");
            entity.Property(e => e.PrintTime).HasMaxLength(20);

            entity.HasOne(d => d.PrintUser).WithMany(p => p.SalesReturnPrints)
                .HasForeignKey(d => d.PrintUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Print__1DB06A4F");

            entity.HasOne(d => d.Return).WithMany(p => p.SalesReturnPrints)
                .HasForeignKey(d => d.ReturnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SalesRetu__Retur__1CBC4616");
        });

        modelBuilder.Entity<StockEntry>(entity =>
        {
            entity.HasKey(e => e.EntryId).HasName("PK__StockEnt__F57BD2F73C2AB653");

            entity.ToTable("StockEntry");

            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.EntryDate).HasColumnType("date");
            entity.Property(e => e.FisicalYear).HasMaxLength(30);
            entity.Property(e => e.Quantity).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.StockStatus).HasMaxLength(20);

            entity.HasOne(d => d.CancelUser).WithMany(p => p.StockEntryCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__StockEntr__Cance__236943A5");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.StockEntryEntryUsers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockEntr__Entry__2180FB33");

            entity.HasOne(d => d.Product).WithMany(p => p.StockEntries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__StockEntr__Produ__208CD6FA");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B42AA06C8A");

            entity.ToTable("Supplier");

            entity.Property(e => e.SupplierAddress).HasMaxLength(50);
            entity.Property(e => e.SupplierEmail).HasMaxLength(50);
            entity.Property(e => e.SupplierName).HasMaxLength(100);
            entity.Property(e => e.SupplierPan).HasMaxLength(50);
            entity.Property(e => e.SupplierPhone).HasMaxLength(30);
            entity.Property(e => e.SupplierStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<SupplierPayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Supplier__9B556A3817E84AB6");

            entity.ToTable("SupplierPayment");

            entity.Property(e => e.CancelledDate).HasColumnType("date");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FiscalYear).HasMaxLength(30);
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.PaymentTime).HasMaxLength(20);
            entity.Property(e => e.ReasonForCancel).HasMaxLength(255);
            entity.Property(e => e.Remarks).HasMaxLength(255);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CancelUser).WithMany(p => p.SupplierPaymentCancelUsers)
                .HasForeignKey(d => d.CancelUserId)
                .HasConstraintName("FK__SupplierP__Cance__3B75D760");

            entity.HasOne(d => d.EntryUser).WithMany(p => p.SupplierPaymentEntryUsers)
                .HasForeignKey(d => d.EntryUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupplierP__Entry__3A81B327");

            entity.HasOne(d => d.Mode).WithMany(p => p.SupplierPayments)
                .HasForeignKey(d => d.ModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupplierP__ModeI__38996AB5");

            entity.HasOne(d => d.Suppliers).WithMany(p => p.SupplierPayments)
                .HasForeignKey(d => d.SuppliersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SupplierP__Suppl__398D8EEE");
        });

        modelBuilder.Entity<UserList>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserList__1788CC4C6B37853C");

            entity.ToTable("UserList");

            entity.HasIndex(e => e.LoginName, "UQ__UserList__DB8464FF8EF1C0BA").IsUnique();

            entity.Property(e => e.LoginName).HasMaxLength(50);
            entity.Property(e => e.LoginPassword).HasMaxLength(50);
            entity.Property(e => e.LoginStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UserAddress).HasMaxLength(50);
            entity.Property(e => e.UserEmail).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.UserPhone).HasMaxLength(30);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Rn).HasName("PK__UserRole__AF2760AD35AA3649");

            entity.ToTable("UserRole");

            entity.HasIndex(e => new { e.UserId, e.RoleId }, "IX_UserRole").IsUnique();

            entity.Property(e => e.Rn).ValueGeneratedNever();

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRole__RoleId__2D27B809");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRole__UserId__2C3393D0");
        });

        modelBuilder.Entity<UserRoleView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserRoleView");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<UsersRoleSelectView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UsersRoleSelectView");

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
