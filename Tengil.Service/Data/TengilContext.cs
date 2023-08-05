using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tngcmd.Data;

// Created using EF Core Scaffolding:
// dotnet ef dbcontext scaffold "server=tanner.tanto-system.se;database=tngEsaro;uid=mattias;pwd=naftalen1;" MySql.EntityFrameworkCore -o Data -c TengilContext

public partial class TengilContext : DbContext
{
    //public TengilContext()
    //{
    //}

    public TengilContext(DbContextOptions<TengilContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<TngAssignment> TngAssignments { get; set; }

    public virtual DbSet<TngAttachment> TngAttachments { get; set; }

    public virtual DbSet<TngBankAccount> TngBankAccounts { get; set; }

    public virtual DbSet<TngChore> TngChores { get; set; }

    public virtual DbSet<TngCurrency> TngCurrencies { get; set; }

    public virtual DbSet<TngCustContact> TngCustContacts { get; set; }

    public virtual DbSet<TngCustomer> TngCustomers { get; set; }

    public virtual DbSet<TngCustomerGroup> TngCustomerGroups { get; set; }

    public virtual DbSet<TngEvent> TngEvents { get; set; }

    public virtual DbSet<TngInvoice> TngInvoices { get; set; }

    public virtual DbSet<TngInvoiceRow> TngInvoiceRows { get; set; }

    public virtual DbSet<TngIssueReport> TngIssueReports { get; set; }

    public virtual DbSet<TngJournalItem> TngJournalItems { get; set; }

    public virtual DbSet<TngJournalRow> TngJournalRows { get; set; }

    public virtual DbSet<TngMessage> TngMessages { get; set; }

    public virtual DbSet<TngPoIn> TngPoins { get; set; }

    public virtual DbSet<TngPoOut> TngPoouts { get; set; }

    public virtual DbSet<TngPoOutRow> TngPooutRows { get; set; }

    public virtual DbSet<TngPrice> TngPrices { get; set; }

    public virtual DbSet<TngProject> TngProjects { get; set; }

    public virtual DbSet<TngProjectItem> TngProjectItems { get; set; }

    public virtual DbSet<TngProperty> TngProperties { get; set; }

    public virtual DbSet<TngResourceGroup> TngResourceGroups { get; set; }

    public virtual DbSet<TngSkeletonFolder> TngSkeletonFolders { get; set; }

    public virtual DbSet<TngStatusValue> TngStatusValues { get; set; }

    public virtual DbSet<TngTaxClass> TngTaxClasses { get; set; }

    public virtual DbSet<TngTest> TngTests { get; set; }

    public virtual DbSet<TngTimer> TngTimers { get; set; }

    public virtual DbSet<TngTimerChunk> TngTimerChunks { get; set; }

    public virtual DbSet<TngUnit> TngUnits { get; set; }

    public virtual DbSet<TngUser> TngUsers { get; set; }

    public virtual DbSet<TngWorkorderRow> TngWorkorderRows { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TngAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngAssignments");

            entity.HasIndex(e => e.DateOut, "DateOut");

            entity.HasIndex(e => e.Owner, "Owner");

            entity.HasIndex(e => e.PoId, "PO_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(255)
                .HasColumnName("Contact_Email");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            // den här kan vi ta bort, den är alltid null
            entity.Property(e => e.CustomerNameNOTUSED)
                .HasMaxLength(255)
                .HasColumnName("Customer_Name");
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.DateOut).HasColumnType("datetime");
            entity.Property(e => e.Deadline).HasColumnType("datetime");
            entity.Property(e => e.ExtentApprox).HasColumnType("int(11)");
            entity.Property(e => e.Folder).HasMaxLength(255);
            entity.Property(e => e.InvoiceText)
                .HasMaxLength(255)
                .HasColumnName("Invoice_Text");
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.PoId)
                .HasColumnType("int(11)")
                .HasColumnName("PO_ID");
            entity.Property(e => e.PoText)
                .HasMaxLength(255)
                .HasColumnName("PO_Text");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.StatusId)
                .HasColumnType("int(11)")
                .HasColumnName("Status_ID");
        });

        modelBuilder.Entity<TngAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngAttachments");

            entity.HasIndex(e => e.ObjectId, "Object_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.DataBytes).HasColumnType("mediumblob");
            entity.Property(e => e.ObjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Object_ID");
            entity.Property(e => e.ObjectTable).HasMaxLength(65);
            entity.Property(e => e.Type).HasMaxLength(65);
        });

        modelBuilder.Entity<TngBankAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngBankAccounts");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AccountHolder).HasMaxLength(128);
            entity.Property(e => e.AccountNr).HasMaxLength(12);
            entity.Property(e => e.BankAddr1).HasMaxLength(128);
            entity.Property(e => e.BankAddr2).HasMaxLength(128);
            entity.Property(e => e.BankAddr3).HasMaxLength(128);
            entity.Property(e => e.BankName).HasMaxLength(24);
            entity.Property(e => e.BankSortCode).HasMaxLength(16);
            entity.Property(e => e.Bic)
                .HasMaxLength(11)
                .HasColumnName("BIC");
            entity.Property(e => e.Clearing).HasMaxLength(5);
            entity.Property(e => e.Iban)
                .HasMaxLength(25)
                .HasColumnName("IBAN");
        });

        modelBuilder.Entity<TngChore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngChores");

            entity.HasIndex(e => e.AssignmentId, "Assignment_ID");

            entity.HasIndex(e => e.UserId, "User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(11)")
                .HasColumnName("Currency_ID");
            entity.Property(e => e.PricePerUnit).HasPrecision(9, 3);
            entity.Property(e => e.Progress).HasColumnType("int(11)");
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
            entity.Property(e => e.WorkorderRowId)
                .HasColumnType("int(11)")
                .HasColumnName("WorkorderRow_ID");
        });

        modelBuilder.Entity<TngCurrency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngCurrencies");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rate).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<TngCustContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngCustContacts");

            entity.HasIndex(e => e.Email, "Email");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AltEmail).HasMaxLength(64);
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PhoneCell).HasMaxLength(255);
            entity.Property(e => e.PhoneWork).HasMaxLength(255);
            entity.Property(e => e.Reserved).HasMaxLength(255);
        });

        modelBuilder.Entity<TngCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngCustomers");

            entity.HasIndex(e => e.GroupId, "Group_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Active)
                .IsRequired()
                .HasDefaultValueSql("'1'");
            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.CountryCode).HasMaxLength(3);
            entity.Property(e => e.DefaultCurrency)
                .HasMaxLength(3)
                .HasDefaultValueSql("'SEK'");
            entity.Property(e => e.DefaultPosting)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.DefaultVat).HasColumnName("DefaultVAT");
            entity.Property(e => e.EmailInv).HasMaxLength(80);
            entity.Property(e => e.Folder).HasMaxLength(255);
            entity.Property(e => e.GroupId)
                .HasColumnType("int(11)")
                .HasColumnName("Group_ID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NoInvoiceRounding).HasColumnType("int(11)");
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.PaymentTerms).HasColumnType("int(11)");
            entity.Property(e => e.Popattern)
                .HasMaxLength(128)
                .HasColumnName("POPattern");
            entity.Property(e => e.PostalCode).HasMaxLength(255);
            entity.Property(e => e.ShortName).HasMaxLength(255);
            entity.Property(e => e.Vatcode)
                .HasMaxLength(60)
                .HasColumnName("VATCode");
        });

        modelBuilder.Entity<TngCustomerGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngCustomerGroups");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.ReservedText).HasMaxLength(255);
        });

        modelBuilder.Entity<TngEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngEvents");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Reserved).HasMaxLength(255);
            entity.Property(e => e.TableId)
                .HasColumnType("int(11)")
                .HasColumnName("Table_ID");
            entity.Property(e => e.TargetId)
                .HasColumnType("int(11)")
                .HasColumnName("Target_ID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Type).HasColumnType("int(11)");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngInvoices");

            entity.HasIndex(e => e.CreatedById, "CreatedBy_ID");

            entity.HasIndex(e => e.CustomerId, "Customer_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Address1).HasMaxLength(255);
            entity.Property(e => e.Address2).HasMaxLength(255);
            entity.Property(e => e.Amount).HasPrecision(12, 3);
            entity.Property(e => e.City).HasMaxLength(256);
            entity.Property(e => e.Country).HasMaxLength(256);
            entity.Property(e => e.CreatedById)
                .HasColumnType("int(11)")
                .HasColumnName("CreatedBy_ID");
            entity.Property(e => e.CurrencyName).HasMaxLength(64);
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.DateDue).HasColumnType("datetime");
            entity.Property(e => e.DateIssued).HasColumnType("datetime");
            entity.Property(e => e.DatePaid).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasPrecision(12, 3);
            entity.Property(e => e.InvoiceText).HasMaxLength(255);
            entity.Property(e => e.PostalCode).HasMaxLength(256);
            entity.Property(e => e.Rate).HasDefaultValueSql("'1'");
            entity.Property(e => e.Recipient).HasMaxLength(255);
            entity.Property(e => e.RefOurs).HasMaxLength(256);
            entity.Property(e => e.RefYours).HasMaxLength(256);
            entity.Property(e => e.Rounding).HasPrecision(3, 3);
            entity.Property(e => e.TemplateId)
                .HasColumnType("int(11)")
                .HasColumnName("Template_ID");
            entity.Property(e => e.Vat)
                .HasPrecision(12, 3)
                .HasColumnName("VAT");
            entity.Property(e => e.Vatcode)
                .HasMaxLength(256)
                .HasColumnName("VATCode");
        });

        modelBuilder.Entity<TngInvoiceRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngInvoiceRows");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ChoreId)
                .HasColumnType("int(11)")
                .HasColumnName("Chore_ID");
            entity.Property(e => e.Discount).HasDefaultValueSql("'0'");
            entity.Property(e => e.Extent)
                .HasPrecision(12, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.InvoiceId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Invoice_ID");
            entity.Property(e => e.PricePerUnit)
                .HasPrecision(9, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.RowText)
                .HasMaxLength(65)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TemplateId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Template_ID");
            entity.Property(e => e.UnitId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.Vat)
                .HasDefaultValueSql("'0'")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<TngIssueReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngIssueReports");

            entity.HasIndex(e => e.AssignmentId, "Assignment_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.Cause).HasMaxLength(64);
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngJournalItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngJournalItems");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Activity).HasMaxLength(255);
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.ChoreId)
                .HasColumnType("int(11)")
                .HasColumnName("Chore_ID");
            entity.Property(e => e.CommentText).HasColumnType("text");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Extent)
                .HasPrecision(9)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.ItemDate).HasColumnType("datetime");
            entity.Property(e => e.ItemEnd).HasColumnType("datetime");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.RowId)
                .HasColumnType("int(11)")
                .HasColumnName("Row_ID");
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngJournalRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngJournalRows");

            entity.HasIndex(e => e.Id, "ID").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Activity).HasMaxLength(255);
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.ChoreId)
                .HasColumnType("int(11)")
                .HasColumnName("Chore_ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.ExtFriday).HasPrecision(9);
            entity.Property(e => e.ExtMonday).HasPrecision(9);
            entity.Property(e => e.ExtSaturday).HasPrecision(9);
            entity.Property(e => e.ExtSunday).HasPrecision(9);
            entity.Property(e => e.ExtThursday).HasPrecision(9);
            entity.Property(e => e.ExtTuesday).HasPrecision(9);
            entity.Property(e => e.ExtWednesday).HasPrecision(9);
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
            entity.Property(e => e.Weekstart).HasColumnType("datetime");
        });

        modelBuilder.Entity<TngMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngMessages");

            entity.HasIndex(e => e.TargetUser, "Target_User");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Created).HasColumnType("datetime");
            entity.Property(e => e.Origin).HasColumnType("int(11)");
            entity.Property(e => e.Status).HasColumnType("int(11)");
            entity.Property(e => e.TargetUser)
                .HasColumnType("int(11)")
                .HasColumnName("Target_User");
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<TngPoIn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngPOIn");

            entity.HasIndex(e => e.CustomerId, "Customer_ID");

            entity.HasIndex(e => e.Reserved, "Customer_Name");

            entity.HasIndex(e => e.InvoiceId, "Invoice_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AddedById)
                .HasColumnType("int(11)")
                .HasColumnName("AddedBy_ID");
            entity.Property(e => e.Amount).HasPrecision(9, 3);
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.CurrencyName).HasMaxLength(255);
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.DateIn).HasColumnType("datetime");
            entity.Property(e => e.Filename).HasMaxLength(255);
            entity.Property(e => e.InvoiceId)
                .HasColumnType("int(11)")
                .HasColumnName("Invoice_ID");
            entity.Property(e => e.InvoiceName)
                .HasMaxLength(255)
                .HasColumnName("Invoice_Name");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.NameText).HasMaxLength(255);

            entity.HasMany(e => e.Rows).WithOne().HasForeignKey(x => x.InvoiceId);
        });

        modelBuilder.Entity<TngPoOut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngPOOut");

            entity.HasIndex(e => e.UserId, "User_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Amount).HasPrecision(9, 3);
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.CurrencyName).HasMaxLength(255);
            entity.Property(e => e.DateInvoiced).HasColumnType("datetime");
            entity.Property(e => e.DateIssued).HasColumnType("datetime");
            entity.Property(e => e.IssuedById)
                .HasColumnType("int(11)")
                .HasColumnName("IssuedBy_ID");
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngPoOutRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngPOOutRows");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ChoreId)
                .HasColumnType("int(11)")
                .HasColumnName("Chore_ID");
            entity.Property(e => e.Discount).HasDefaultValueSql("'0'");
            entity.Property(e => e.Extent)
                .HasPrecision(12, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.PooutId)
                .HasColumnType("int(11)")
                .HasColumnName("POOut_ID");
            entity.Property(e => e.PricePerUnit)
                .HasPrecision(9, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.RowText)
                .HasMaxLength(65)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TemplateId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Template_ID");
            entity.Property(e => e.UnitId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.Vat)
                .HasDefaultValueSql("'0'")
                .HasColumnName("VAT");
        });

        modelBuilder.Entity<TngPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngPrices");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(11)")
                .HasColumnName("Currency_ID");
            entity.Property(e => e.CurrencyName).HasMaxLength(40);
            entity.Property(e => e.DateAgreed).HasColumnType("datetime");
            entity.Property(e => e.ObjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Object_ID");
            entity.Property(e => e.ObjectType).HasColumnType("int(11)");
            entity.Property(e => e.Price).HasPrecision(9, 4);
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
        });

        modelBuilder.Entity<TngProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngProjects");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FolderInfix).HasMaxLength(255);
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.OwnerId)
                .HasColumnType("int(11)")
                .HasColumnName("Owner_ID");
            entity.Property(e => e.ParentId)
                .HasColumnType("int(11)")
                .HasColumnName("Parent_ID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TngProjectItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngProjectItems");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ApprovedById)
                .HasColumnType("int(11)")
                .HasColumnName("ApprovedBy_ID");
            entity.Property(e => e.CurrencyId)
                .HasColumnType("int(11)")
                .HasColumnName("Currency_ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Extent).HasColumnType("int(11)");
            entity.Property(e => e.PricePerUnit).HasPrecision(9, 3);
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
        });

        modelBuilder.Entity<TngProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngProperties");

            entity.HasIndex(e => e.ObjectId, "Object_ID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.DataBytes).HasColumnType("mediumblob");
            entity.Property(e => e.ObjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Object_ID");
            entity.Property(e => e.ObjectTable).HasMaxLength(65);
            entity.Property(e => e.PropertyName).HasMaxLength(65);
        });

        modelBuilder.Entity<TngResourceGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngResourceGroups");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.ReservedText).HasMaxLength(255);
        });

        modelBuilder.Entity<TngSkeletonFolder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngSkeletonFolders");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.NameText).HasMaxLength(255);
            entity.Property(e => e.Path).HasColumnType("text");
            entity.Property(e => e.Res1).HasMaxLength(255);
            entity.Property(e => e.Res2).HasMaxLength(255);
        });

        modelBuilder.Entity<TngStatusValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngStatusValues");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<TngTaxClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngTaxClasses");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Text).HasMaxLength(255);
        });

        modelBuilder.Entity<TngTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngTest");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.Activity).HasMaxLength(255);
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.ChoreId)
                .HasColumnType("int(11)")
                .HasColumnName("Chore_ID");
            entity.Property(e => e.CommentText).HasColumnType("text");
            entity.Property(e => e.CustomerId)
                .HasColumnType("int(11)")
                .HasColumnName("Customer_ID");
            entity.Property(e => e.Extent)
                .HasPrecision(9)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.ItemDate).HasColumnType("datetime");
            entity.Property(e => e.ItemEnd).HasColumnType("datetime");
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.RowId)
                .HasColumnType("int(11)")
                .HasColumnName("Row_ID");
            entity.Property(e => e.UnitId)
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngTimer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngTimers");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AssignmentId)
                .HasMaxLength(255)
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.CommentText).HasMaxLength(255);
            entity.Property(e => e.OwnerId)
                .HasColumnType("int(11)")
                .HasColumnName("Owner_ID");
            entity.Property(e => e.Running).HasColumnType("int(11)");
        });

        modelBuilder.Entity<TngTimerChunk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngTimerChunks");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.AssignmentId)
                .HasColumnType("int(11)")
                .HasColumnName("Assignment_ID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.ProjectId)
                .HasColumnType("int(11)")
                .HasColumnName("Project_ID");
            entity.Property(e => e.Running).HasColumnType("int(11)");
            entity.Property(e => e.Start).HasColumnType("datetime");
            entity.Property(e => e.Stop).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("User_ID");
        });

        modelBuilder.Entity<TngUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngUnits");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.DescriptionText).HasMaxLength(255);
            entity.Property(e => e.NameText).HasMaxLength(50);
            entity.Property(e => e.Weight).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<TngUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngUsers");

            entity.HasIndex(e => e.Active, "Active");

            entity.HasIndex(e => e.Username, "Username");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Active).HasDefaultValueSql("'1'");
            entity.Property(e => e.Addr1).HasMaxLength(255);
            entity.Property(e => e.Addr2).HasMaxLength(255);
            entity.Property(e => e.AltEmail).HasMaxLength(255);
            entity.Property(e => e.BankAccountId)
                .HasColumnType("int(11)")
                .HasColumnName("BankAccount_ID");
            entity.Property(e => e.Category)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Country).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.GroupId)
                .HasColumnType("int(11)")
                .HasColumnName("Group_ID");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.MidName).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneCell).HasMaxLength(255);
            entity.Property(e => e.PhoneHome).HasMaxLength(255);
            entity.Property(e => e.PhoneWork).HasMaxLength(255);
            entity.Property(e => e.PostalNo).HasMaxLength(255);
            entity.Property(e => e.Salary).HasColumnType("tinyint(4)");
            entity.Property(e => e.TaxClass).HasColumnType("int(11)");
            entity.Property(e => e.UserPrivs)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
        });

        modelBuilder.Entity<TngWorkorderRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tngWorkorderRows");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Discount).HasDefaultValueSql("'0'");
            entity.Property(e => e.Extent)
                .HasPrecision(12, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.PooutId)
                .HasColumnType("int(11)")
                .HasColumnName("POOut_ID");
            entity.Property(e => e.PricePerUnit)
                .HasPrecision(9, 3)
                .HasDefaultValueSql("'0.000'");
            entity.Property(e => e.Reserved).HasColumnType("int(11)");
            entity.Property(e => e.RowText)
                .HasMaxLength(65)
                .HasDefaultValueSql("''");
            entity.Property(e => e.TemplateId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Template_ID");
            entity.Property(e => e.UnitId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("Unit_ID");
            entity.Property(e => e.Vat)
                .HasDefaultValueSql("'0'")
                .HasColumnName("VAT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
