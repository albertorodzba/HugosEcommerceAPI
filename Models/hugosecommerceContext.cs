using System;
using System.Collections.Generic;
using hugosEcommerce_api.Utils.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace hugosEcommerce_api.Models
{
    public partial class hugosecommerceContext : DbContext
    {
        public hugosecommerceContext()
        {
        }

        public hugosecommerceContext(DbContextOptions<hugosecommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Bronchure> Bronchures { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Coating> Coatings { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<ContactInfo> ContactInfos { get; set; } = null!;
        public virtual DbSet<Fabric> Fabrics { get; set; } = null!;
        public virtual DbSet<Flyer> Flyers { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Postcard> Postcards { get; set; } = null!;
        public virtual DbSet<Process> Processes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Runsize> Runsizes { get; set; } = null!;
        public virtual DbSet<Shirt> Shirts { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;
        public virtual DbSet<Tablesinfo> Tablesinfos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL(EnvironmentVariables.MysqlConnection);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.PkBrand)
                    .HasName("PRIMARY");

                entity.ToTable("brand");

                entity.HasIndex(e => e.BrandName, "brand_name")
                    .IsUnique();

                entity.HasIndex(e => e.Sku, "sku")
                    .IsUnique();

                entity.Property(e => e.PkBrand)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_brand");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(20)
                    .HasColumnName("brand_name");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .HasColumnName("sku")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Bronchure>(entity =>
            {
                entity.HasKey(e => e.PkCard)
                    .HasName("PRIMARY");

                entity.ToTable("bronchure");

                entity.HasIndex(e => e.FkCoating, "FK_coating");

                entity.HasIndex(e => e.FkColor, "FK_color");

                entity.HasIndex(e => e.FkMaterial, "FK_material");

                entity.HasIndex(e => e.FkRunsize, "FK_runsize");

                entity.HasIndex(e => e.FkSize, "FK_size");

                entity.HasIndex(e => e.ProductStatus, "product_status");

                entity.Property(e => e.PkCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_card");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkCoating)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_coating")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_color")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkFolding)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_folding")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_material")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkRunsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_runsize")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLocation)
                    .HasMaxLength(300)
                    .HasColumnName("image_location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkCoatingNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.FkCoating)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_4");

                entity.HasOne(d => d.FkColorNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.FkColor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_3");

                entity.HasOne(d => d.FkMaterialNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.FkMaterial)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_2");

                entity.HasOne(d => d.FkRunsizeNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.FkRunsize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_5");

                entity.HasOne(d => d.FkSizeNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.FkSize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_1");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.Bronchures)
                    .HasForeignKey(d => d.ProductStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bronchure_ibfk_6");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.PkCard)
                    .HasName("PRIMARY");

                entity.ToTable("card");

                entity.HasIndex(e => e.FkCoating, "FK_coating");

                entity.HasIndex(e => e.FkColor, "FK_color");

                entity.HasIndex(e => e.FkMaterial, "FK_material");

                entity.HasIndex(e => e.FkRunsize, "FK_runsize");

                entity.HasIndex(e => e.FkSize, "FK_size");

                entity.HasIndex(e => e.ProductStatus, "product_status");

                entity.Property(e => e.PkCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_card");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkCoating)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_coating")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_color")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_material")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkRunsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_runsize")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLocation)
                    .HasMaxLength(300)
                    .HasColumnName("image_location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkCoatingNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.FkCoating)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_4");

                entity.HasOne(d => d.FkColorNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.FkColor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_3");

                entity.HasOne(d => d.FkMaterialNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.FkMaterial)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_2");

                entity.HasOne(d => d.FkRunsizeNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.FkRunsize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_5");

                entity.HasOne(d => d.FkSizeNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.FkSize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_1");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.ProductStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("card_ibfk_6");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.PkCategory)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.HasIndex(e => e.CategoryName, "category_name")
                    .IsUnique();

                entity.Property(e => e.PkCategory)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(30)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Coating>(entity =>
            {
                entity.HasKey(e => e.PkCoating)
                    .HasName("PRIMARY");

                entity.ToTable("coating");

                entity.HasIndex(e => e.CoatingName, "coating_name")
                    .IsUnique();

                entity.Property(e => e.PkCoating)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_coating");

                entity.Property(e => e.CoatingName)
                    .HasMaxLength(40)
                    .HasColumnName("coating_name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.PkColor)
                    .HasName("PRIMARY");

                entity.ToTable("color");

                entity.HasIndex(e => e.ColorName, "color_name")
                    .IsUnique();

                entity.Property(e => e.PkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_color");

                entity.Property(e => e.ColorName)
                    .HasMaxLength(20)
                    .HasColumnName("color_name");
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.HasKey(e => e.PkContactInfo)
                    .HasName("PRIMARY");

                entity.ToTable("contact_info");

                entity.Property(e => e.PkContactInfo)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_contact_info");

                entity.Property(e => e.BusinessName)
                    .HasMaxLength(70)
                    .HasColumnName("business_name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'current_timestamp()'");

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(300)
                    .HasColumnName("image_url")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Message)
                    .HasMaxLength(400)
                    .HasColumnName("message")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Name)
                    .HasMaxLength(70)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Fabric>(entity =>
            {
                entity.HasKey(e => e.PkFabric)
                    .HasName("PRIMARY");

                entity.ToTable("fabric");

                entity.HasIndex(e => e.FabricName, "fabric_name")
                    .IsUnique();

                entity.Property(e => e.PkFabric)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_fabric");

                entity.Property(e => e.FabricName)
                    .HasMaxLength(30)
                    .HasColumnName("fabric_name");
            });

            modelBuilder.Entity<Flyer>(entity =>
            {
                entity.HasKey(e => e.PkCard)
                    .HasName("PRIMARY");

                entity.ToTable("flyer");

                entity.HasIndex(e => e.FkCoating, "FK_coating");

                entity.HasIndex(e => e.FkColor, "FK_color");

                entity.HasIndex(e => e.FkMaterial, "FK_material");

                entity.HasIndex(e => e.FkRunsize, "FK_runsize");

                entity.HasIndex(e => e.FkSize, "FK_size");

                entity.HasIndex(e => e.ProductStatus, "product_status");

                entity.Property(e => e.PkCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_card");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkCoating)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_coating")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_color")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_material")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkRunsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_runsize")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLocation)
                    .HasMaxLength(300)
                    .HasColumnName("image_location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkCoatingNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.FkCoating)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_4");

                entity.HasOne(d => d.FkColorNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.FkColor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_3");

                entity.HasOne(d => d.FkMaterialNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.FkMaterial)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_2");

                entity.HasOne(d => d.FkRunsizeNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.FkRunsize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_5");

                entity.HasOne(d => d.FkSizeNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.FkSize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_1");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.Flyers)
                    .HasForeignKey(d => d.ProductStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("flyer_ibfk_6");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.PkMaterial)
                    .HasName("PRIMARY");

                entity.ToTable("material");

                entity.HasIndex(e => e.MaterialName, "material_name")
                    .IsUnique();

                entity.Property(e => e.PkMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_material");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(50)
                    .HasColumnName("material_name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Postcard>(entity =>
            {
                entity.HasKey(e => e.PkCard)
                    .HasName("PRIMARY");

                entity.ToTable("postcard");

                entity.HasIndex(e => e.FkCoating, "FK_coating");

                entity.HasIndex(e => e.FkColor, "FK_color");

                entity.HasIndex(e => e.FkMaterial, "FK_material");

                entity.HasIndex(e => e.FkRunsize, "FK_runsize");

                entity.HasIndex(e => e.FkSize, "FK_size");

                entity.HasIndex(e => e.ProductStatus, "product_status");

                entity.Property(e => e.PkCard)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_card");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkCoating)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_coating")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_color")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkMaterial)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_material")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkRunsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_runsize")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLocation)
                    .HasMaxLength(300)
                    .HasColumnName("image_location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkCoatingNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.FkCoating)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_4");

                entity.HasOne(d => d.FkColorNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.FkColor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_3");

                entity.HasOne(d => d.FkMaterialNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.FkMaterial)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_2");

                entity.HasOne(d => d.FkRunsizeNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.FkRunsize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_5");

                entity.HasOne(d => d.FkSizeNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.FkSize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_1");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.Postcards)
                    .HasForeignKey(d => d.ProductStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("postcard_ibfk_6");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.HasKey(e => e.PkProcess)
                    .HasName("PRIMARY");

                entity.ToTable("process");

                entity.HasIndex(e => e.ProcessName, "process_name")
                    .IsUnique();

                entity.Property(e => e.PkProcess)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_process");

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(30)
                    .HasColumnName("process_name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PkProducts)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.ProductName, "product_name")
                    .IsUnique();

                entity.Property(e => e.PkProducts)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_products");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .HasColumnName("product_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.PkRole)
                    .HasName("PRIMARY");

                entity.ToTable("role");

                entity.HasIndex(e => e.RoleName, "role_name")
                    .IsUnique();

                entity.Property(e => e.PkRole)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Runsize>(entity =>
            {
                entity.HasKey(e => e.PkRunsize)
                    .HasName("PRIMARY");

                entity.ToTable("runsize");

                entity.HasIndex(e => e.Quantity, "quantity")
                    .IsUnique();

                entity.Property(e => e.PkRunsize)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_runsize");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Shirt>(entity =>
            {
                entity.HasKey(e => e.PkShirt)
                    .HasName("PRIMARY");

                entity.ToTable("shirt");

                entity.HasIndex(e => e.FkBrand, "FK_brand");

                entity.HasIndex(e => e.FkCategory, "FK_category");

                entity.HasIndex(e => e.FkColor, "FK_color");

                entity.HasIndex(e => e.FkFabric, "FK_fabric");

                entity.HasIndex(e => e.FkProcess, "FK_process");

                entity.HasIndex(e => e.FkSize, "FK_size");

                entity.HasIndex(e => e.FkStyle, "FK_style");

                entity.HasIndex(e => e.ProductStatus, "product_status");

                entity.Property(e => e.PkShirt)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_shirt");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Description)
                    .HasMaxLength(300)
                    .HasColumnName("description")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkBrand)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_brand")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkCategory)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_category")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkColor)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_color")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkFabric)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_fabric")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkProcess)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_process")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_size")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("FK_style")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ImageLocation)
                    .HasMaxLength(300)
                    .HasColumnName("image_location")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProductStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("product_status")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkBrandNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkBrand)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_1");

                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkCategory)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_5");

                entity.HasOne(d => d.FkColorNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkColor)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_4");

                entity.HasOne(d => d.FkFabricNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkFabric)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_3");

                entity.HasOne(d => d.FkProcessNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkProcess)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_7");

                entity.HasOne(d => d.FkSizeNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkSize)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_2");

                entity.HasOne(d => d.FkStyleNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.FkStyle)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_6");

                entity.HasOne(d => d.ProductStatusNavigation)
                    .WithMany(p => p.Shirts)
                    .HasForeignKey(d => d.ProductStatus)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("shirt_ibfk_8");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(e => e.PkSize)
                    .HasName("PRIMARY");

                entity.ToTable("size");

                entity.HasIndex(e => e.SizeName, "size_name")
                    .IsUnique();

                entity.Property(e => e.PkSize)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_size");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(15)
                    .HasColumnName("size_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.PkStatus)
                    .HasName("PRIMARY");

                entity.ToTable("status");

                entity.HasIndex(e => e.StatusName, "status_name")
                    .IsUnique();

                entity.Property(e => e.PkStatus)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_status");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(20)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.HasKey(e => e.PkStyle)
                    .HasName("PRIMARY");

                entity.ToTable("style");

                entity.HasIndex(e => e.SytleName, "sytle_name")
                    .IsUnique();

                entity.Property(e => e.PkStyle)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_style");

                entity.Property(e => e.SytleName)
                    .HasMaxLength(30)
                    .HasColumnName("sytle_name");
            });

            modelBuilder.Entity<Tablesinfo>(entity =>
            {
                entity.HasKey(e => e.PkTablesInfo)
                    .HasName("PRIMARY");

                entity.ToTable("tablesinfo");

                entity.Property(e => e.PkTablesInfo)
                    .HasColumnType("int(11)")
                    .HasColumnName("PK_tablesInfo");

                entity.Property(e => e.Columns)
                    .HasColumnName("columns")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.TableName)
                    .HasMaxLength(50)
                    .HasColumnName("table_name")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PkUser)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.Role, "role");

                entity.HasIndex(e => e.Username, "username")
                    .IsUnique();

                entity.Property(e => e.PkUser)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("PK_user");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("date")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .HasColumnName("email")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Role)
                    .HasColumnType("int(11)")
                    .HasColumnName("role")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("date")
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .HasColumnName("username")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
