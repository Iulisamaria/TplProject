using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace tplProject.Models
{
    public partial class tpl_databaseContext : DbContext
    {
        public tpl_databaseContext()
        {
        }

        public tpl_databaseContext(DbContextOptions<tpl_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<LostItems> LostItems { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Pass> Pass { get; set; }
        public virtual DbSet<PassType> PassType { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<Stations> Stations { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=tpl_database;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>(entity =>
            {
                entity.ToTable("bus");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PassId).HasColumnName("pass_id");

                entity.Property(e => e.Routes).HasColumnName("routes");

                entity.HasOne(d => d.Pass)
                    .WithMany(p => p.Card)
                    .HasForeignKey(d => d.PassId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Card__pass_id__10566F31");
            });

            modelBuilder.Entity<LostItems>(entity =>
            {
                entity.ToTable("LOST_ITEMS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Info)
                    .HasColumnName("INFO")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NrCrt).HasColumnName("NR_CRT");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Pass>(entity =>
            {
                entity.ToTable("PASS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Pass)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PASS__id_type__0D7A0286");
            });

            modelBuilder.Entity<PassType>(entity =>
            {
                entity.ToTable("pass_type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypePass)
                    .HasColumnName("type_pass")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.ToTable("ROUTE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("path")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Stations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nume)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Cnp)
                    .HasName("PK__User__C1FF677C0EA4954A");

                entity.Property(e => e.Cnp)
                    .HasColumnName("CNP")
                    .HasColumnType("numeric(13, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.IdCard).HasColumnName("id_card");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PasswordHash).HasMaxLength(500);

                entity.Property(e => e.PasswordSalt).HasMaxLength(500);

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCardNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdCard)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__User__id_card__1332DBDC");
            });

            modelBuilder.HasSequence("id_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
