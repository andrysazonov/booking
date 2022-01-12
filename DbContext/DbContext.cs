using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HostBooking
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext()
        {
        }

        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql(
                    "Host=ella.db.elephantsql.com;Database=jmluhjvi;Username=jmluhjvi;Password=IQ2k_i9cDXCvKo4daRFpu-jez5RjSriZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("btree_gin")
                .HasPostgresExtension("btree_gist")
                .HasPostgresExtension("citext")
                .HasPostgresExtension("cube")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("dict_int")
                .HasPostgresExtension("dict_xsyn")
                .HasPostgresExtension("earthdistance")
                .HasPostgresExtension("fuzzystrmatch")
                .HasPostgresExtension("hstore")
                .HasPostgresExtension("intarray")
                .HasPostgresExtension("ltree")
                .HasPostgresExtension("pg_stat_statements")
                .HasPostgresExtension("pg_trgm")
                .HasPostgresExtension("pgcrypto")
                .HasPostgresExtension("pgrowlocks")
                .HasPostgresExtension("pgstattuple")
                .HasPostgresExtension("tablefunc")
                .HasPostgresExtension("unaccent")
                .HasPostgresExtension("uuid-ossp")
                .HasPostgresExtension("xml2")
                .HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.Idadmin)
                    .HasName("admins_pkey");

                entity.ToTable("admins");

                entity.Property(e => e.Idadmin)
                    .ValueGeneratedNever()
                    .HasColumnName("idadmin");

                entity.Property(e => e.AdminSurname)
                    .HasMaxLength(15)
                    .HasColumnName("admin_surname");

                entity.Property(e => e.Adminlogin)
                    .HasMaxLength(20)
                    .HasColumnName("adminlogin");

                entity.Property(e => e.Adminname)
                    .HasMaxLength(15)
                    .HasColumnName("adminname");

                entity.Property(e => e.Adminpassword)
                    .HasMaxLength(30)
                    .HasColumnName("adminpassword");

                entity.Property(e => e.Adminsecondname)
                    .HasMaxLength(20)
                    .HasColumnName("adminsecondname");
            });

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.HasKey(e => e.IdEntry)
                    .HasName("entries_pkey");

                entity.ToTable("entries");

                entity.Property(e => e.IdEntry).ValueGeneratedNever();
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("reservations");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");

                entity.Property(e => e.TableId)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.ToTable("tables");

                entity.Property(e => e.Id)
                    .HasColumnType("character varying")
                    .HasColumnName("id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnType("character varying");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("character varying");

                entity.Property(e => e.SecondName).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}