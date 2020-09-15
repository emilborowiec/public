using Microsoft.EntityFrameworkCore;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.DataAccess
{
    public class NTangleContext : DbContext
    {
        internal DbSet<Tip> Tips { get; set; }
        internal DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=db\data\ntangle.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().ToTable("activity").HasKey(a => a.Id);
            modelBuilder.Entity<Activity>().Property(a => a.Id).HasColumnName("activity_id");
            modelBuilder.Entity<Activity>().Property(a => a.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Activity>().Property(a => a.Description).HasColumnName("description");
            modelBuilder.Entity<Activity>().Property<int?>("ParentId").HasColumnName("parent_activity_id");
            modelBuilder.Entity<Activity>()
                        .HasOne(a => a.Parent)
                        .WithMany(a => a.Children)
                        .HasForeignKey("ParentId")
                        .IsRequired(false);
            
            modelBuilder.Entity<Tip>().ToTable("tip").HasKey(t => t.Id);
            modelBuilder.Entity<Tip>().Property(t => t.Id).HasColumnName("tip_id");
            modelBuilder.Entity<Tip>().Property(t => t.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<Tip>().Property(t => t.Summary).HasColumnName("summary");
            modelBuilder.Entity<Tip>().Property(t => t.ReferenceUrl).HasColumnName("reference_url");
            modelBuilder.Entity<Tip>().Property(t => t.TipType).HasConversion<string>().HasColumnName("tip_type");
            modelBuilder.Entity<Tip>().Property<int?>("ActivityId").HasColumnName("activity_id");
            modelBuilder.Entity<Tip>()
                        .HasOne(t => t.Activity)
                        .WithMany(a => a.Tips)
                        .HasForeignKey("ActivityId")
                        .IsRequired(false);

            modelBuilder.Entity<TipRelation>().ToTable("tip_relation");
            modelBuilder.Entity<TipRelation>().Property(tr => tr.SourceTipId).HasColumnName("source_tip_id");
            modelBuilder.Entity<TipRelation>().Property(tr => tr.TargetTipId).HasColumnName("target_tip_id");
            modelBuilder.Entity<TipRelation>()
                        .Property(tr => tr.RelationType)
                        .HasConversion<string>()
                        .HasColumnName("relation_type");
            modelBuilder.Entity<TipRelation>().HasKey(tr => new {SourceTipId = tr.SourceTipId, TargetTipId = tr.TargetTipId});
            modelBuilder.Entity<TipRelation>()
                        .HasOne(tr => tr.Source)
                        .WithMany(t => t.Relations)
                        .HasForeignKey(tr => tr.SourceTipId);
            modelBuilder.Entity<TipRelation>()
                        .HasOne(tr => tr.Target)
                        .WithMany()
                        .HasForeignKey(tr => tr.TargetTipId);
        }
    }
}