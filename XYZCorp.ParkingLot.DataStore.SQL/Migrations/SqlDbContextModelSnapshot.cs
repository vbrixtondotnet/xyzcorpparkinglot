// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XYZCorp.ParkingLot.DataStore.SQL;

namespace XYZCorp.ParkingLot.DataStore.SQL.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.BaseRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ExcessRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("FlatRate")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<int>("ResetHours")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("BaseRates");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.EntryPoint", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("EntryPoints");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.Parking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal?>("AmountPaid")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlateNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlotID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SlotID");

                    b.ToTable("Parkings");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.Slot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntryPointID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SlotTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EntryPointID");

                    b.HasIndex("SlotTypeID");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.SlotRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("RatePerHour")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SlotTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SlotTypeID");

                    b.ToTable("SlotRates");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.SlotType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SlotTypes");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.VehicleSlotAssignment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<int>("SlotTypeID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleTypeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SlotTypeID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("VehicleSlotAssignments");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.VehicleType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedBy")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.Parking", b =>
                {
                    b.HasOne("XYZCorp.ParkingLot.Domain.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.Slot", b =>
                {
                    b.HasOne("XYZCorp.ParkingLot.Domain.EntryPoint", "EntryPoint")
                        .WithMany("Slots")
                        .HasForeignKey("EntryPointID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XYZCorp.ParkingLot.Domain.SlotType", "SlotType")
                        .WithMany()
                        .HasForeignKey("SlotTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryPoint");

                    b.Navigation("SlotType");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.SlotRate", b =>
                {
                    b.HasOne("XYZCorp.ParkingLot.Domain.SlotType", "SlotType")
                        .WithMany()
                        .HasForeignKey("SlotTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SlotType");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.VehicleSlotAssignment", b =>
                {
                    b.HasOne("XYZCorp.ParkingLot.Domain.SlotType", "SlotType")
                        .WithMany()
                        .HasForeignKey("SlotTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XYZCorp.ParkingLot.Domain.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SlotType");

                    b.Navigation("VehicleType");
                });

            modelBuilder.Entity("XYZCorp.ParkingLot.Domain.EntryPoint", b =>
                {
                    b.Navigation("Slots");
                });
#pragma warning restore 612, 618
        }
    }
}
