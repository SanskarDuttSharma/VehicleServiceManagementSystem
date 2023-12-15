using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Models;

public partial class VehicleServiceManagementSystemContext : DbContext
{
    public VehicleServiceManagementSystemContext()
    {
    }

    public VehicleServiceManagementSystemContext(DbContextOptions<VehicleServiceManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=ITT-SANSKARD;Initial Catalog=VehicleServiceManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3213E83F250FA9F3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.EndDateTime)
                .HasColumnType("datetime")
                .HasColumnName("endDateTime");
            entity.Property(e => e.PaymentStatys)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("paymentStatys");
            entity.Property(e => e.PaymentType).HasColumnName("paymentType");
            entity.Property(e => e.ServiceDetailsId).HasColumnName("serviceDetailsID");
            entity.Property(e => e.StartDateTime)
                .HasColumnType("datetime")
                .HasColumnName("startDateTime");

            entity.HasOne(d => d.PaymentTypeNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.PaymentType)
                .HasConstraintName("FK__OrderDeta__payme__0E6E26BF");

            entity.HasOne(d => d.ServiceDetails).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ServiceDetailsId)
                .HasConstraintName("FK__OrderDeta__servi__0D7A0286");
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payement__3213E83F2413A676");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83FE2FCB9B2");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<ServiceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ServiceD__3213E83FC6034F3F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AttendeeId).HasColumnName("attendeeId");
            entity.Property(e => e.EndDateTime)
                .HasColumnType("datetime")
                .HasColumnName("endDateTime");
            entity.Property(e => e.FeedBack)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("feedBack");
            entity.Property(e => e.IssuesMentioned)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issuesMentioned");
            entity.Property(e => e.IssuesResolved)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("issuesResolved");
            entity.Property(e => e.StartDateTime)
                .HasColumnType("datetime")
                .HasColumnName("startDateTime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.VehicleId).HasColumnName("vehicleId");

            entity.HasOne(d => d.Attendee).WithMany(p => p.ServiceDetails)
                .HasForeignKey(d => d.AttendeeId)
                .HasConstraintName("FK__ServiceDe__atten__48CFD27E");

            //entity.HasOne(d => d.Vehicle).WithMany(p => p.ServiceDetails)
            //    .HasForeignKey(d => d.VehicleId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__ServiceDe__vehic__49C3F6B7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83F50CDA7C6");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E61648221D1DA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.MobileNumber).HasColumnName("mobileNumber");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicle__3213E83FD2451489");

            entity.ToTable("Vehicle");

            entity.HasIndex(e => e.VehicleRegistrationPlateNumber, "UQ__Vehicle__DEB4F3580604DA5D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModelName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("modelName");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.VehicleRegistrationPlateNumber)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vehicleRegistrationPlateNumber");

            entity.HasOne(d => d.User).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Vehicle__userID__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
