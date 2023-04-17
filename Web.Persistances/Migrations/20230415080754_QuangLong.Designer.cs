﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Persistances;

#nullable disable

namespace Web.Persistances.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230415080754_QuangLong")]
    partial class QuangLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web.Entities.CauHinh", b =>
                {
                    b.Property<string>("Id_CauHinh")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CameraSau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraTruoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoPhanGiai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_CauHinh");

                    b.ToTable("CauHinh");
                });

            modelBuilder.Entity("Web.Entities.ChiTietHoaDon", b =>
                {
                    b.Property<string>("Id_HoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_SanPham")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("Id_HoaDon", "Id_SanPham");

                    b.ToTable("ChiTietHoaDon");
                });

            modelBuilder.Entity("Web.Entities.ChiTietNhapHang", b =>
                {
                    b.Property<string>("Id_SanPham")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_NhapHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<double>("ThanhTien")
                        .HasColumnType("float");

                    b.HasKey("Id_SanPham", "Id_NhapHang");

                    b.ToTable("ChiTietNhapHang");
                });

            modelBuilder.Entity("Web.Entities.DanhMucCon", b =>
                {
                    b.Property<string>("Id_DanhMucCon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_CauHinh")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_DanhMucCon");

                    b.HasIndex("Id_CauHinh");

                    b.ToTable("DanhMucCon");
                });

            modelBuilder.Entity("Web.Entities.HoaDon", b =>
                {
                    b.Property<string>("Id_HoaDon")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_NhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_khachhang")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayLapHoaDon")
                        .HasColumnType("datetime2");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.HasKey("Id_HoaDon");

                    b.HasIndex("Id_NhanVien");

                    b.HasIndex("Id_khachhang");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("Web.Entities.KhachHang", b =>
                {
                    b.Property<string>("Id_KhacHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_KhacHang");

                    b.ToTable("KhachHang");
                });

            modelBuilder.Entity("Web.Entities.LoaiSanPham", b =>
                {
                    b.Property<string>("Id_loai")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_DanhMucCon")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_MauSac")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_loai");

                    b.HasIndex("Id_DanhMucCon");

                    b.HasIndex("Id_MauSac");

                    b.ToTable("LoaiSanPham");
                });

            modelBuilder.Entity("Web.Entities.MauSac", b =>
                {
                    b.Property<string>("Id_MauSac")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TenMauSac")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_MauSac");

                    b.ToTable("MauSac");
                });

            modelBuilder.Entity("Web.Entities.NhaCungCap", b =>
                {
                    b.Property<string>("Id_NhaCungCap")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_NhaCungCap");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("Web.Entities.NhanVien", b =>
                {
                    b.Property<string>("Id_NhanVien")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_NhanVien");

                    b.ToTable("NhanVien");
                });

            modelBuilder.Entity("Web.Entities.NhapHang", b =>
                {
                    b.Property<string>("Id_NhapHang")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GhiChu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Id_NhaCungCap")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_NhanVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Id_SanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("NgayGiao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<int>("TongSoLuong")
                        .HasColumnType("int");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.Property<int>("TrangThaiNhapHang")
                        .HasColumnType("int");

                    b.HasKey("Id_NhapHang");

                    b.HasIndex("Id_NhaCungCap");

                    b.HasIndex("Id_NhanVien");

                    b.HasIndex("Id_SanPham");

                    b.ToTable("NhapHang");
                });

            modelBuilder.Entity("Web.Entities.SanPham", b =>
                {
                    b.Property<string>("Id_SanPham")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("GiaTien")
                        .HasColumnType("float");

                    b.Property<string>("Id_loai")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Ten_SanPham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_SanPham");

                    b.HasIndex("Id_loai");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("Web.Entities.DanhMucCon", b =>
                {
                    b.HasOne("Web.Entities.CauHinh", "CauHinh")
                        .WithMany()
                        .HasForeignKey("Id_CauHinh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CauHinh");
                });

            modelBuilder.Entity("Web.Entities.HoaDon", b =>
                {
                    b.HasOne("Web.Entities.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("Id_NhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entities.KhachHang", "KhachHang")
                        .WithMany()
                        .HasForeignKey("Id_khachhang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");

                    b.Navigation("NhanVien");
                });

            modelBuilder.Entity("Web.Entities.LoaiSanPham", b =>
                {
                    b.HasOne("Web.Entities.DanhMucCon", "DanhMucCon")
                        .WithMany()
                        .HasForeignKey("Id_DanhMucCon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entities.MauSac", "MauSac")
                        .WithMany()
                        .HasForeignKey("Id_MauSac")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucCon");

                    b.Navigation("MauSac");
                });

            modelBuilder.Entity("Web.Entities.NhapHang", b =>
                {
                    b.HasOne("Web.Entities.NhaCungCap", "NhaCungCap")
                        .WithMany()
                        .HasForeignKey("Id_NhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entities.NhanVien", "NhanVien")
                        .WithMany()
                        .HasForeignKey("Id_NhanVien")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web.Entities.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("Id_SanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCap");

                    b.Navigation("NhanVien");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("Web.Entities.SanPham", b =>
                {
                    b.HasOne("Web.Entities.LoaiSanPham", "LoaiSanPham")
                        .WithMany()
                        .HasForeignKey("Id_loai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiSanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
