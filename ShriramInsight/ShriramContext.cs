using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShriramInsight;

public partial class ShriramContext : DbContext
{
    public ShriramContext()
    {
    }

    public ShriramContext(DbContextOptions<ShriramContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblFuelType> TblFuelTypes { get; set; }

    public virtual DbSet<TblFuelTypeLog> TblFuelTypeLogs { get; set; }

    public virtual DbSet<TblGiPolicyBook> TblGiPolicyBooks { get; set; }

    public virtual DbSet<TblMemberType> TblMemberTypes { get; set; }

    public virtual DbSet<TblPolicyNature> TblPolicyNatures { get; set; }

    public virtual DbSet<TblPolicyType> TblPolicyTypes { get; set; }

    public virtual DbSet<TblProposedInsurer> TblProposedInsurers { get; set; }

    public virtual DbSet<TblState> TblStates { get; set; }

    public virtual DbSet<TblVehicleType> TblVehicleTypes { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblFuelType>(entity =>
        {
            entity.HasKey(e => e.FuelTypeId).HasName("PK__tbl_fuel__048BEE373F6F3DDE");

            entity.ToTable("tbl_fuel_type");

            entity.HasIndex(e => e.FuelTypeDesc, "UQ_FuelTypeDesc").IsUnique();

            entity.Property(e => e.FuelTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FuelTypeDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblFuelTypeLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__tbl_fuel__5E54864857D5ADAD");

            entity.ToTable("tbl_fuel_type_logs");

            entity.Property(e => e.Action).HasMaxLength(20);
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.PerformedBy).HasMaxLength(50);
            entity.Property(e => e.PerformedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<TblGiPolicyBook>(entity =>
        {
            entity.HasKey(e => e.OrderNo);

            entity.ToTable("tbl_gi_policy_book");

            entity.HasIndex(e => e.AgentTypeId, "IX_tbl_gi_policy_book_AgentTypeId");

            entity.HasIndex(e => e.CentreNo, "IX_tbl_gi_policy_book_CentreNo");

            entity.HasIndex(e => e.PolicyStatusNo, "IX_tbl_gi_policy_book_PolicyStatusNo");

            entity.HasIndex(e => e.ProcessDateTime, "IX_tbl_gi_policy_book_ProcessDateTime");

            entity.Property(e => e.OrderNo).HasColumnType("decimal(24, 0)");
            entity.Property(e => e.AddOnservice).HasColumnName("addOnservice");
            entity.Property(e => e.AdditionalInfo).HasMaxLength(500);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AmountRecvFromParty).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BankDetails).HasMaxLength(200);
            entity.Property(e => e.ChassisNo).HasMaxLength(30);
            entity.Property(e => e.CommissionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommissionPayoutInCash).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommissionPer).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ContactNo).HasMaxLength(15);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.DamagePremiumAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.EngineNo).HasMaxLength(30);
            entity.Property(e => e.FuelType).HasColumnName("fuelType");
            entity.Property(e => e.GuardianDetails).HasMaxLength(200);
            entity.Property(e => e.HypothecatedBy).HasColumnName("hypothecatedBy");
            entity.Property(e => e.Idv)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("IDV");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MemberType).HasColumnName("memberType");
            entity.Property(e => e.ModifiedDateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.MoneyRecptDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Ncbdiscount)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("NCBDiscount");
            entity.Property(e => e.NomineeDetails).HasMaxLength(200);
            entity.Property(e => e.PersonalAccident).HasColumnName("personalAccident");
            entity.Property(e => e.PolicyDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PolicyExpDate).HasColumnType("smalldatetime");
            entity.Property(e => e.PolicyNo).HasMaxLength(50);
            entity.Property(e => e.PrevNcb)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Prev_NCB");
            entity.Property(e => e.PreviousInsuranceCompany).HasMaxLength(100);
            entity.Property(e => e.PreviousPolicyNo).HasMaxLength(50);
            entity.Property(e => e.ProcessDateTime).HasColumnType("smalldatetime");
            entity.Property(e => e.RelationWithNominee).HasMaxLength(50);
            entity.Property(e => e.Remarks).HasMaxLength(500);
            entity.Property(e => e.RoadSideAssistance).HasColumnName("roadSideAssistance");
            entity.Property(e => e.Rtocode)
                .HasMaxLength(10)
                .HasColumnName("RTOCode");
            entity.Property(e => e.ThirdPartyPremiumAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalPremiumAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
            entity.Property(e => e.VehicleMake).HasMaxLength(50);
            entity.Property(e => e.VehicleModel).HasMaxLength(50);
            entity.Property(e => e.VehicleNo).HasMaxLength(20);
            entity.Property(e => e.VehicleVariant).HasMaxLength(50);
        });

        modelBuilder.Entity<TblMemberType>(entity =>
        {
            entity.HasKey(e => e.MemberTypeId).HasName("PK__tbl_memb__5D8AFD1F30F41CDA");

            entity.ToTable("tbl_member_type");

            entity.Property(e => e.MemberTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MemberTypeDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPolicyNature>(entity =>
        {
            entity.HasKey(e => e.PolicyNatureId).HasName("PK__tbl_poli__F7B6244DC5EF0DF2");

            entity.ToTable("tbl_policy_nature");

            entity.Property(e => e.PolicyNatureId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PolicyNatureDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPolicyType>(entity =>
        {
            entity.HasKey(e => e.PolicyTypeId).HasName("PK__tbl_poli__90DE2D7EF62ACB15");

            entity.ToTable("tbl_policy_type");

            entity.Property(e => e.PolicyTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PolicyTypeDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblProposedInsurer>(entity =>
        {
            entity.HasKey(e => e.InsurerId).HasName("PK__tbl_prop__7E508CE6BB1525D5");

            entity.ToTable("tbl_proposed_insurer");

            entity.Property(e => e.InsurerId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InsurerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK__tbl_stat__C3BA3B3AEBA4439A");

            entity.ToTable("tbl_state");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StateDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblVehicleType>(entity =>
        {
            entity.HasKey(e => e.VehicleTypeId).HasName("PK__tbl_vehi__9F449643517B0B96");

            entity.ToTable("tbl_vehicle_type");

            entity.Property(e => e.VehicleTypeId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedWhen)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            entity.Property(e => e.UpdatedWhen).HasColumnType("datetime");
            entity.Property(e => e.VehicleTypeDesc)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
