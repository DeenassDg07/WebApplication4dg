using Microsoft.EntityFrameworkCore;

namespace WebApplication4dg.DB
{
    public class MagazinEptContext : DbContext
    {
        public MagazinEptContext()
        {
        }

        public MagazinEptContext(DbContextOptions<MagazinEptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("userid=student;password=student;database=MagazinEpt;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasIndex(e => e.ProductId, "FK_Items_Product_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.Count).HasColumnType("int(110)");
                entity.Property(e => e.ProductId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Product_id");

                entity.HasOne(d => d.Product).WithMany(p => p.Items)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Items_Product_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.HasIndex(e => e.ItemsId, "FK_Orders_Items_Id");

                entity.HasIndex(e => e.UserId, "FK_Orders_User_Id");

                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.City).HasMaxLength(255);
                entity.Property(e => e.House).HasColumnType("int(11)");
                entity.Property(e => e.ItemsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("Items_id");
                entity.Property(e => e.PaymentMethod).HasMaxLength(255);
                entity.Property(e => e.PostalCode).HasColumnType("int(11)");
                entity.Property(e => e.Street).HasMaxLength(255);
                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("User_id");

                entity.HasOne(d => d.Items).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ItemsId)
                    .HasConstraintName("FK_Orders_Items_Id");

                entity.HasOne(d => d.User).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Orders_User_Id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnType("int(11)");
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FirstName).HasMaxLength(255);
                entity.Property(e => e.Info).HasMaxLength(255);
                entity.Property(e => e.LastName).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
