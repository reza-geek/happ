﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Models;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(Hospital_DBN2))]
    partial class Hospital_DBN2ModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("backend.Models.Catheter", b =>
                {
                    b.Property<int>("Catheter_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Catheter_ID"), 1L, 1);

                    b.Property<string>("Catheter_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Catheter_ID");

                    b.ToTable("Catheter");
                });

            modelBuilder.Entity("backend.Models.Catheter_event", b =>
                {
                    b.Property<long>("CatheterisationEvent_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CatheterisationEvent_ID"), 1L, 1);

                    b.Property<long>("Catheterisation_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Event_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Event_Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Event_ID")
                        .HasColumnType("int");

                    b.HasKey("CatheterisationEvent_ID");

                    b.HasIndex("Catheterisation_ID");

                    b.HasIndex("Event_ID");

                    b.ToTable("Catheter_event");
                });

            modelBuilder.Entity("backend.Models.CatheterEject", b =>
                {
                    b.Property<int>("CatheterEject_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatheterEject_ID"), 1L, 1);

                    b.Property<string>("EjectReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatheterEject_ID");

                    b.ToTable("CatheterEject");
                });

            modelBuilder.Entity("backend.Models.Catheterisation", b =>
                {
                    b.Property<long>("Catheterisation_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Catheterisation_ID"), 1L, 1);

                    b.Property<int?>("CatheterEject_ID")
                        .HasColumnType("int");

                    b.Property<string>("Catheterisation_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Catheterisation_DateEn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Catheterisation_EjectDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Catheterisation_EjectDateEn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorDr_ID")
                        .HasColumnType("int");

                    b.Property<string>("Event_Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Has_Event")
                        .HasColumnType("bit");

                    b.Property<long>("Reception_ID")
                        .HasColumnType("bigint");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Catheterisation_ID");

                    b.HasIndex("CatheterEject_ID");

                    b.HasIndex("DoctorDr_ID");

                    b.HasIndex("Reception_ID");

                    b.ToTable("Catheterisation");
                });

            modelBuilder.Entity("backend.Models.Clearance", b =>
                {
                    b.Property<int>("Clearance_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Clearance_ID"), 1L, 1);

                    b.Property<string>("Clearance_Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Clearance_ID");

                    b.ToTable("Clearance");
                });

            modelBuilder.Entity("backend.Models.Doctor", b =>
                {
                    b.Property<int>("Dr_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Dr_ID"), 1L, 1);

                    b.Property<string>("Dr_Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dr_Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dr_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dr_NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insert_date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Other_Center")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Dr_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("backend.Models.Event", b =>
                {
                    b.Property<int>("Event_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Event_ID"), 1L, 1);

                    b.Property<string>("Event_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Event_ID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("backend.Models.Part", b =>
                {
                    b.Property<int>("Part_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Part_ID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Part_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Part_ID");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("backend.Models.Patient", b =>
                {
                    b.Property<long>("Patient_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Patient_ID"), 1L, 1);

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Insert_Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("National_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Patient_ID");

                    b.HasIndex("National_Code")
                        .IsUnique();

                    b.HasIndex("User_ID");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("backend.Models.Reception", b =>
                {
                    b.Property<long>("Reception_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Reception_ID"), 1L, 1);

                    b.Property<string>("Clearance_DESC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clearance_DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Clearance_ID")
                        .HasColumnType("int");

                    b.Property<int>("Part_ID")
                        .HasColumnType("int");

                    b.Property<long>("Patient_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Rec_DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recognization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Reception_ID");

                    b.HasIndex("Clearance_ID");

                    b.HasIndex("Part_ID");

                    b.HasIndex("Patient_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Reception");
                });

            modelBuilder.Entity("backend.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"), 1L, 1);

                    b.Property<string>("Create_DateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Is_Active")
                        .HasColumnType("bit");

                    b.Property<string>("LastLoginDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoginFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("National_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_ID");

                    b.ToTable("user_tbl");
                });

            modelBuilder.Entity("backend.Models.Catheter_event", b =>
                {
                    b.HasOne("backend.Models.Catheterisation", "Catheterisation")
                        .WithMany()
                        .HasForeignKey("Catheterisation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("Event_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catheterisation");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("backend.Models.Catheterisation", b =>
                {
                    b.HasOne("backend.Models.CatheterEject", "CatheterEject")
                        .WithMany()
                        .HasForeignKey("CatheterEject_ID");

                    b.HasOne("backend.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorDr_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Reception", "Reception")
                        .WithMany()
                        .HasForeignKey("Reception_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatheterEject");

                    b.Navigation("Doctor");

                    b.Navigation("Reception");
                });

            modelBuilder.Entity("backend.Models.Doctor", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.Patient", b =>
                {
                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("backend.Models.Reception", b =>
                {
                    b.HasOne("backend.Models.Clearance", "Clearance")
                        .WithMany()
                        .HasForeignKey("Clearance_ID");

                    b.HasOne("backend.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("Part_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("Patient_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clearance");

                    b.Navigation("Part");

                    b.Navigation("Patient");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
