using Microsoft.EntityFrameworkCore;

namespace PonderingProgrammer.NTangle.Core
{
    public class NTangleContext : DbContext
    {
        public DbSet<Tip> Tips { get; set; }
        public DbSet<TipSet> TipSets { get; set; }
        public DbSet<Activity> Activities { get; set; }

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
            modelBuilder.Entity<Activity>().Property(a => a.ParentId).HasColumnName("parent_activity_id");
            modelBuilder.Entity<Activity>()
                        .HasOne(a => a.Parent)
                        .WithMany(a => a.Children)
                        .HasForeignKey(a => a.ParentId)
                        .IsRequired(false);
            
            modelBuilder.Entity<TipSet>().ToTable("tip_set").HasKey(ts => ts.Id);
            modelBuilder.Entity<TipSet>().Property(ts => ts.Id).HasColumnName("tip_set_id");
            modelBuilder.Entity<TipSet>().Property(ts => ts.Name).HasColumnName("name").IsRequired();
            modelBuilder.Entity<TipSet>().Property(ts => ts.Summary).HasColumnName("summary");
            modelBuilder.Entity<TipSet>().Property(ts => ts.ReferenceUrl).HasColumnName("reference_url");
            
            modelBuilder.Entity<TipType>().ToTable("tip_type").HasKey(tt => tt.Id);
            modelBuilder.Entity<TipType>().Property(tt => tt.Id).HasColumnName("tip_type_id");
            modelBuilder.Entity<TipType>().Property(tt => tt.Name).HasColumnName("name").IsRequired();

            modelBuilder.Entity<Tip>().ToTable("tip").HasKey(t => t.Id);
            modelBuilder.Entity<Tip>().Property(t => t.Id).HasColumnName("tip_id");
            modelBuilder.Entity<Tip>().Property(t => t.Title).HasColumnName("title").IsRequired();
            modelBuilder.Entity<Tip>().Property(t => t.Summary).HasColumnName("summary");
            modelBuilder.Entity<Tip>().Property(t => t.ReferenceUrl).HasColumnName("reference_url");
            modelBuilder.Entity<Tip>().Property(t => t.TipTypeId).HasColumnName("tip_type_id");
            modelBuilder.Entity<Tip>().Property(t => t.ActivityId).HasColumnName("activity_id");
            modelBuilder.Entity<Tip>()
                        .HasOne(t => t.Activity)
                        .WithMany(a => a.Tips)
                        .HasForeignKey(t => t.ActivityId)
                        .IsRequired(false);
            modelBuilder.Entity<Tip>()
                        .HasOne(t => t.TipType)
                        .WithMany(tt => tt.Tips)
                        .HasForeignKey(t => t.TipTypeId);

            modelBuilder.Entity<TipGrouping>().ToTable("tip_grouping");
            modelBuilder.Entity<TipGrouping>().HasKey(tg => new {tg.TipId, tg.TipSetId});
            modelBuilder.Entity<TipGrouping>().Property(tg => tg.TipId).HasColumnName("tip_id");
            modelBuilder.Entity<TipGrouping>().Property(tg => tg.TipSetId).HasColumnName("tip_set_id");
            modelBuilder.Entity<TipGrouping>()
                        .HasOne(g => g.Tip)
                        .WithMany(t => t.Groupings)
                        .HasForeignKey(g => g.TipId);
            modelBuilder.Entity<TipGrouping>()
                        .HasOne(g => g.TipSet)
                        .WithMany(ts => ts.Groupings)
                        .HasForeignKey(g => g.TipSetId);
        }
    }
}