using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReadBySelenium.Entities;

public partial class TxtPrcContext : DbContext
{
    public TxtPrcContext()
    {
    }

    public TxtPrcContext(DbContextOptions<TxtPrcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EstimateNews> EstimateNews { get; set; }

    public virtual DbSet<EvaluatedResult> EvaluatedResults { get; set; }

    public virtual DbSet<FieldOfUse> FieldOfUses { get; set; }

    public virtual DbSet<KeyWord> KeyWords { get; set; }

    public virtual DbSet<KeyWordsDtl> KeyWordsDtls { get; set; }

    public virtual DbSet<KeyWordsMain> KeyWordsMains { get; set; }

    public virtual DbSet<MedName> MedNames { get; set; }

    public virtual DbSet<NegativeReason> NegativeReasons { get; set; }

    public virtual DbSet<NewsCount> NewsCounts { get; set; }

    public virtual DbSet<NewsInserted> NewsInserteds { get; set; }

    public virtual DbSet<NewsInsertedsCmd> NewsInsertedsCmds { get; set; }

    public virtual DbSet<NewsRssReed> NewsRssReeds { get; set; }

    public virtual DbSet<NewsRssReedProc> NewsRssReedProcs { get; set; }

    public virtual DbSet<NewsSource> NewsSources { get; set; }

    public virtual DbSet<NewsSourceDetail> NewsSourceDetails { get; set; }

    public virtual DbSet<StatisticalSource> StatisticalSources { get; set; }

    public virtual DbSet<TbCaln> TbCalns { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<TbUserRole> TbUserRoles { get; set; }

    public virtual DbSet<TelegramChannel> TelegramChannels { get; set; }

    public virtual DbSet<TelegramPost> TelegramPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = TxtPrc; User Id = sa; Password = M13961221@; TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<EvaluatedResult>(entity =>
        {
            entity.HasIndex(e => e.EstimateId, "IX_EvaluatedResults_EstimateId");

            entity.HasIndex(e => e.FieldOfUseId, "IX_EvaluatedResults_FieldOfUseId");

            entity.HasIndex(e => e.NewsId, "IX_EvaluatedResults_NewsId");

            entity.HasIndex(e => e.StatisticalSourceId, "IX_EvaluatedResults_StatisticalSourceId");

            entity.HasOne(d => d.Estimate).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.EstimateId);

            entity.HasOne(d => d.FieldOfUse).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.FieldOfUseId);

            entity.HasOne(d => d.News).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.NewsId);

            entity.HasOne(d => d.StatisticalSource).WithMany(p => p.EvaluatedResults).HasForeignKey(d => d.StatisticalSourceId);
        });

        modelBuilder.Entity<FieldOfUse>(entity =>
        {
            entity.ToTable("FieldOfUse");
        });

        modelBuilder.Entity<KeyWord>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Par01).HasMaxLength(250);
            entity.Property(e => e.Par02).HasMaxLength(250);
            entity.Property(e => e.Par03).HasMaxLength(250);
            entity.Property(e => e.Par04).HasMaxLength(250);
            entity.Property(e => e.Par05).HasMaxLength(250);
            entity.Property(e => e.Par06).HasMaxLength(250);
            entity.Property(e => e.Par07).HasMaxLength(250);
            entity.Property(e => e.Par08).HasMaxLength(250);
            entity.Property(e => e.Par09).HasMaxLength(250);
            entity.Property(e => e.Par10).HasMaxLength(250);
            entity.Property(e => e.Par11).HasMaxLength(250);
            entity.Property(e => e.Par12).HasMaxLength(250);
            entity.Property(e => e.Par13).HasMaxLength(250);
            entity.Property(e => e.Par14).HasMaxLength(250);
            entity.Property(e => e.Par15).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<KeyWordsDtl>(entity =>
        {
            entity.ToTable("KeyWordsDtl");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Par01).HasMaxLength(250);
            entity.Property(e => e.Par02).HasMaxLength(250);
            entity.Property(e => e.Par03).HasMaxLength(250);
            entity.Property(e => e.Par04).HasMaxLength(250);
            entity.Property(e => e.Par05).HasMaxLength(250);
            entity.Property(e => e.Par06).HasMaxLength(250);
            entity.Property(e => e.Par07).HasMaxLength(250);
            entity.Property(e => e.Par08).HasMaxLength(250);
            entity.Property(e => e.Par09).HasMaxLength(250);
            entity.Property(e => e.Par10).HasMaxLength(250);
            entity.Property(e => e.Par11).HasMaxLength(250);
            entity.Property(e => e.Par12).HasMaxLength(250);
            entity.Property(e => e.Par13).HasMaxLength(250);
            entity.Property(e => e.Par14).HasMaxLength(250);
            entity.Property(e => e.Par15).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<KeyWordsMain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PrimaryKeyWords");

            entity.ToTable("KeyWordsMain");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<MedName>(entity =>
        {
            entity.ToTable("MedName");

            entity.Property(e => e.EnName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FrName).HasMaxLength(200);
        });

        modelBuilder.Entity<NegativeReason>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<NewsCount>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<NewsInserted>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EstimateDscp).HasMaxLength(400);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(20);
            entity.Property(e => e.NewsPublishedDate).HasMaxLength(50);
            entity.Property(e => e.NewsTitle).HasMaxLength(500);
            entity.Property(e => e.NewsUrl)
                .HasMaxLength(150)
                .HasColumnName("NewsURL");
            entity.Property(e => e.UserCreatedIp).HasMaxLength(20);
        });

        modelBuilder.Entity<NewsInsertedsCmd>(entity =>
        {
            entity.ToTable("NewsInsertedsCmd");

            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<NewsRssReed>(entity =>
        {
            entity.ToTable("NewsRssReed");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Enclosure).HasMaxLength(100);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LinkUrl).HasMaxLength(200);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProcDate).HasColumnType("datetime");
            entity.Property(e => e.PublishedDate).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(1000);
        });

        modelBuilder.Entity<NewsRssReedProc>(entity =>
        {
            entity.ToTable("NewsRssReedProc");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.KeyWordsDtlTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsMainTitle).HasMaxLength(200);
            entity.Property(e => e.KeyWordsTitle).HasMaxLength(200);
            entity.Property(e => e.ModifiedIp)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NewsSource>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SiteUri)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SourceDescription).HasMaxLength(1000);
            entity.Property(e => e.SourceTitle).HasMaxLength(200);
        });

        modelBuilder.Entity<NewsSourceDetail>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.SourceTitle).HasMaxLength(200);
            entity.Property(e => e.SourceUrl)
                .HasMaxLength(500)
                .HasColumnName("SourceURL");

            entity.HasOne(d => d.NewsSource).WithMany(p => p.NewsSourceDetails).HasForeignKey(d => d.NewsSourceId);

            entity.HasOne(d => d.SourceDetail).WithMany(p => p.InverseSourceDetail).HasForeignKey(d => d.SourceDetailId);
        });

        modelBuilder.Entity<TbCaln>(entity =>
        {
            entity.ToTable("TbCaln");

            entity.Property(e => e.DateEn).HasColumnType("date");
            entity.Property(e => e.DateEn1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateEn2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateFa1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateFa2)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Mobile).HasMaxLength(20);
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);
            entity.Property(e => e.Username).HasMaxLength(200);
        });

        modelBuilder.Entity<TbUserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_TbUserRoles_RoleId");

            entity.HasIndex(e => e.UserId, "IX_TbUserRoles_UserId");

            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.CreateIp).HasMaxLength(22);
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ModifiedIp).HasMaxLength(22);

            entity.HasOne(d => d.Role).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.TbUserRoles).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<TelegramChannel>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Gid).HasDefaultValueSql("(newid())");
            entity.Property(e => e.TelegramChannelName).HasMaxLength(50);
        });

        modelBuilder.Entity<TelegramPost>(entity =>
        {
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PostDate).HasMaxLength(50);
            entity.Property(e => e.PostEditedDate).HasMaxLength(50);
            entity.Property(e => e.PostUsername).HasMaxLength(50);

            entity.HasOne(d => d.TelegramChannel).WithMany(p => p.TelegramPosts)
                .HasForeignKey(d => d.TelegramChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TelegramPosts_TelegramChannels");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
