using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BTL.Models
{
    public partial class QLBanSachContext : DbContext
    {
        public QLBanSachContext()
        {
        }

        public QLBanSachContext(DbContextOptions<QLBanSachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctdondh> Ctdondhs { get; set; }
        public virtual DbSet<Cthoadon> Cthoadons { get; set; }
        public virtual DbSet<Ctpnhap> Ctpnhaps { get; set; }
        public virtual DbSet<Dondh> Dondhs { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Loaisach> Loaisaches { get; set; }
        public virtual DbSet<Nhacc> Nhaccs { get; set; }
        public virtual DbSet<Pnhap> Pnhaps { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-E7KV63R;Initial Catalog=QLBanSach;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ctdondh>(entity =>
            {
                entity.HasKey(e => new { e.MaDonDh, e.MaSach })
                    .HasName("PK__CTDONDH__1687C58916BE1DB3");

                entity.ToTable("CTDONDH");

                entity.Property(e => e.MaDonDh).HasColumnName("MaDonDH");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.MaDonDhNavigation)
                    .WithMany(p => p.Ctdondhs)
                    .HasForeignKey(d => d.MaDonDh)
                    .HasConstraintName("FK_CTDONDH_DONDH");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Ctdondhs)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTDONDH_SACH");
            });

            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => new { e.MaHd, e.MaSach })
                    .HasName("PK__CTHOADON__EC06F1A21A176800");

                entity.ToTable("CTHOADON");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.ThanhTien).HasColumnType("money");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.MaHd)
                    .HasConstraintName("FK_CTHOADON_HOADON");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHOADON_SACH");
            });

            modelBuilder.Entity<Ctpnhap>(entity =>
            {
                entity.HasKey(e => new { e.MaPn, e.MaSach })
                    .HasName("PK__CTPNHAP__EC06B0B2CA3574E1");

                entity.ToTable("CTPNHAP");

                entity.Property(e => e.MaPn).HasColumnName("MaPN");

                entity.Property(e => e.DgNhap).HasColumnType("money");

                entity.HasOne(d => d.MaPnNavigation)
                    .WithMany(p => p.Ctpnhaps)
                    .HasForeignKey(d => d.MaPn)
                    .HasConstraintName("FK_CTPNHAP_PNHAP");

                entity.HasOne(d => d.MaSachNavigation)
                    .WithMany(p => p.Ctpnhaps)
                    .HasForeignKey(d => d.MaSach)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTPNHAP_SACH");
            });

            modelBuilder.Entity<Dondh>(entity =>
            {
                entity.HasKey(e => e.MaDonDh)
                    .HasName("PK__DONDH__DDA492CB449EF060");

                entity.ToTable("DONDH");

                entity.Property(e => e.MaDonDh).HasColumnName("MaDonDH");

                entity.Property(e => e.NgayDh).HasColumnType("datetime");

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.MaNhaCcNavigation)
                    .WithMany(p => p.Dondhs)
                    .HasForeignKey(d => d.MaNhaCc)
                    .HasConstraintName("FK_NHACC_DONDH");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HOADON__2725A6E06D885C2B");

                entity.ToTable("HOADON");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.MaTk).HasColumnName("MaTK");

                entity.Property(e => e.NgayLap)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_HOADON_KHACHHANG");

                entity.HasOne(d => d.MaTkNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaTk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_HOADON_TAIKHOAN");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KHACHHAN__2725CF1E2978C753");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SoDt)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SoDT");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<Loaisach>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LOAISACH__730A57590D1E5390");

                entity.ToTable("LOAISACH");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Nhacc>(entity =>
            {
                entity.HasKey(e => e.MaNhaCc)
                    .HasName("PK__NHACC__C87CD31144AA9323");

                entity.ToTable("NHACC");

                entity.Property(e => e.DiaChi)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhaCc)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pnhap>(entity =>
            {
                entity.HasKey(e => e.MaPn)
                    .HasName("PK__PNHAP__2725E7F05E35475C");

                entity.ToTable("PNHAP");

                entity.Property(e => e.MaPn).HasColumnName("MaPN");

                entity.Property(e => e.MaDonDh).HasColumnName("MaDonDH");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.HasOne(d => d.MaDonDhNavigation)
                    .WithMany(p => p.Pnhaps)
                    .HasForeignKey(d => d.MaDonDh)
                    .HasConstraintName("FK_PNHAP_DONDH");
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.MaSach)
                    .HasName("PK__SACH__B235742DB5BEF1AC");

                entity.ToTable("SACH");

                entity.Property(e => e.DonGiaBan).HasColumnType("money");

                entity.Property(e => e.DonGiaNhap).HasColumnType("money");

                entity.Property(e => e.NhaXuatBan)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TacGia)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.TenSach)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaLoaiNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.MaLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_MaLoai");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.MaTk)
                    .HasName("PK__TAIKHOAN__27250070B8B476AF");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.MaTk).HasColumnName("MaTK");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LoaiTk).HasColumnName("LoaiTK");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
