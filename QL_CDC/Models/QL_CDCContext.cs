using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QL_CDC.Models
{
    public partial class QL_CDCContext : DbContext
    {
        public QL_CDCContext()
        {
        }

        public QL_CDCContext(DbContextOptions<QL_CDCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BINHLUANSANPHAM> BINHLUANSANPHAM { get; set; }
        public virtual DbSet<CHAT> CHAT { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADON { get; set; }
        public virtual DbSet<DANHGIASANPHAM> DANHGIASANPHAM { get; set; }
        public virtual DbSet<GIOHANG> GIOHANG { get; set; }
        public virtual DbSet<HINHANH> HINHANH { get; set; }
        public virtual DbSet<HOADONMUA> HOADONMUA { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAI { get; set; }
        public virtual DbSet<LOAIMATHANG> LOAIMATHANG { get; set; }
        public virtual DbSet<LOAISANPHAM> LOAISANPHAM { get; set; }
        public virtual DbSet<SANPHAM> SANPHAM { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIEN { get; set; }
        public virtual DbSet<TINHTRANGHOADON> TINHTRANGHOADON { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-EHEN21F\\SQLEXPRESS;database=QL_CDC;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BINHLUANSANPHAM>(entity =>
            {
                entity.HasKey(e => new { e.SV_MSSV, e.SP_MSSP })
                    .HasName("PK_BINHLUAN");

                entity.HasIndex(e => e.SV_MSSV, "BINHLUAN_FKA");

                entity.Property(e => e.SV_MSSV)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SP_MSSP)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.BL_NOIDUNG).HasMaxLength(2000);

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.BINHLUANSANPHAM)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BINHLUAN_VE_SANPHAM");

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.BINHLUANSANPHAM)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BINHLUAN_CUA3_SINHVIEN");
            });

            modelBuilder.Entity<CHAT>(entity =>
            {
                entity.HasKey(e => new { e.SV_MSSV_1, e.SV_MSSV_2, e.CHAT_THOIGIAN });

                entity.HasIndex(e => e.SV_MSSV_2, "CHAT2_FK");

                entity.HasIndex(e => e.SV_MSSV_1, "CHAT_FK");

                entity.Property(e => e.SV_MSSV_1)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SV_MSSV_2)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CHAT_THOIGIAN).HasColumnType("datetime");

                entity.Property(e => e.CHAT_NOIDUNG).HasMaxLength(4000);

                entity.HasOne(d => d.SV_MSSV_1Navigation)
                    .WithMany(p => p.CHATSV_MSSV_1Navigation)
                    .HasForeignKey(d => d.SV_MSSV_1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAT_CHAT_SINHVIEN");

                entity.HasOne(d => d.SV_MSSV_2Navigation)
                    .WithMany(p => p.CHATSV_MSSV_2Navigation)
                    .HasForeignKey(d => d.SV_MSSV_2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAT_CHAT2_SINHVIEN");
            });

            modelBuilder.Entity<CHITIETHOADON>(entity =>
            {
                entity.HasKey(e => new { e.SP_MSSP, e.HD_MSHD });

                entity.HasIndex(e => e.HD_MSHD, "CHITIETHOADON2_FK");

                entity.HasIndex(e => e.SP_MSSP, "CHITIETHOADON_FK");

                entity.Property(e => e.SP_MSSP)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HD_MSHD)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.HD_MSHDNavigation)
                    .WithMany(p => p.CHITIETHOADON)
                    .HasForeignKey(d => d.HD_MSHD)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETH_CHITIETHO_HOADONMU");

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.CHITIETHOADON)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETH_CTHD_SANPHAM");
            });

            modelBuilder.Entity<DANHGIASANPHAM>(entity =>
            {
                entity.HasKey(e => new { e.SV_MSSV, e.SP_MSSP })
                    .HasName("PK_DANHGIA");

                entity.HasIndex(e => e.SV_MSSV, "DANHGIA_FK");

                entity.Property(e => e.SV_MSSV)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SP_MSSP)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.DANHGIASANPHAM)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANHGIA_DANHGIA2_SANPHAM");

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.DANHGIASANPHAM)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DANHGIA_DANHGIA_SINHVIEN");
            });

            modelBuilder.Entity<GIOHANG>(entity =>
            {
                entity.HasKey(e => new { e.SV_MSSV, e.SP_MSSP });

                entity.HasIndex(e => e.SV_MSSV, "GIOHANG_FK");

                entity.Property(e => e.SV_MSSV)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SP_MSSP)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.GIOHANG)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GIOHANG_CO_SANPHAM");

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.GIOHANG)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GIOHANG_GIOHANG_SINHVIEN");
            });

            modelBuilder.Entity<HINHANH>(entity =>
            {
                entity.HasKey(e => e.HA_MSHA)
                    .IsClustered(false);

                entity.HasIndex(e => e.SP_MSSP, "CO_FK");

                entity.HasIndex(e => e.SV_MSSV, "DAT_FK");

                entity.Property(e => e.HA_MSHA)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HA_LINK)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SP_MSSP)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SV_MSSV)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.HINHANH)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HINHANH_CUA_SANPHAM");

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.HINHANH)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HINHANH_CUA4_SINHVIEN");
            });

            modelBuilder.Entity<HOADONMUA>(entity =>
            {
                entity.HasKey(e => e.HD_MSHD)
                    .IsClustered(false);

                entity.HasIndex(e => e.TT_MSTT, "CO2_FK");

                entity.HasIndex(e => e.SV_MSSV, "MUA_FK");

                entity.Property(e => e.HD_MSHD)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.HD_NGAYMUA).HasColumnType("datetime");

                entity.Property(e => e.SV_MSSV)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.HOADONMUA)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADONMU_CUA2_SINHVIEN");

                entity.HasOne(d => d.TT_MSTTNavigation)
                    .WithMany(p => p.HOADONMUA)
                    .HasForeignKey(d => d.TT_MSTT)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADONMU_CO2_TINHTRAN");
            });

            modelBuilder.Entity<KHUYENMAI>(entity =>
            {
                entity.HasKey(e => e.KM_MSKM)
                    .IsClustered(false);

                entity.HasIndex(e => e.SP_MSSP, "DUOC_FK");

                entity.Property(e => e.KM_MSKM)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SP_MSSP)
                    .IsRequired()
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.SP_MSSPNavigation)
                    .WithMany(p => p.KHUYENMAI)
                    .HasForeignKey(d => d.SP_MSSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHUYENMA_DUOC_SANPHAM");
            });

            modelBuilder.Entity<LOAIMATHANG>(entity =>
            {
                entity.HasKey(e => e.MH_MAMH);

                entity.Property(e => e.MH_MAMH).ValueGeneratedNever();

                entity.Property(e => e.MH_TENMH).HasMaxLength(200);
            });

            modelBuilder.Entity<LOAISANPHAM>(entity =>
            {
                entity.HasKey(e => e.LOAI_MALOAI)
                    .IsClustered(false);

                entity.Property(e => e.LOAI_MALOAI).ValueGeneratedNever();

                entity.Property(e => e.LOAI_TENLOAI).HasMaxLength(200);

                entity.HasOne(d => d.MH_MAMHNavigation)
                    .WithMany(p => p.LOAISANPHAM)
                    .HasForeignKey(d => d.MH_MAMH)
                    .HasConstraintName("FK_LOAISANPHAM_LOAIMATHANG");
            });

            modelBuilder.Entity<SANPHAM>(entity =>
            {
                entity.HasKey(e => e.SP_MSSP)
                    .IsClustered(false);

                entity.HasIndex(e => e.SV_MSSV, "BAN_FK");

                entity.Property(e => e.SP_MSSP)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SP_HANGSX).HasMaxLength(200);

                entity.Property(e => e.SP_MOTA).HasMaxLength(4000);

                entity.Property(e => e.SP_NGAYDANG).HasColumnType("datetime");

                entity.Property(e => e.SP_TENSP).HasMaxLength(200);

                entity.Property(e => e.SV_MSSV)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.LOAI_MALOAINavigation)
                    .WithMany(p => p.SANPHAM)
                    .HasForeignKey(d => d.LOAI_MALOAI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANPHAM_THUOC_LOAISANP");

                entity.HasOne(d => d.SV_MSSVNavigation)
                    .WithMany(p => p.SANPHAM)
                    .HasForeignKey(d => d.SV_MSSV)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SANPHAM_DO_SINHVIEN");
            });

            modelBuilder.Entity<SINHVIEN>(entity =>
            {
                entity.HasKey(e => e.SV_MSSV)
                    .IsClustered(false);

                entity.Property(e => e.SV_MSSV)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SV_DIACHIGIAOHANG).HasMaxLength(500);

                entity.Property(e => e.SV_EMAIL).HasMaxLength(200);

                entity.Property(e => e.SV_HOTEN).HasMaxLength(200);

                entity.Property(e => e.SV_LANHDCUOI).HasColumnType("datetime");

                entity.Property(e => e.SV_MATKHAU)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SV_NGAYTAOTK).HasColumnType("datetime");

                entity.Property(e => e.SV_SDT)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SV_TENHIENTHI).HasMaxLength(200);
            });

            modelBuilder.Entity<TINHTRANGHOADON>(entity =>
            {
                entity.HasKey(e => e.TT_MSTT)
                    .IsClustered(false);

                entity.Property(e => e.TT_MSTT).ValueGeneratedNever();

                entity.Property(e => e.TT_TRANGTHAI).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
