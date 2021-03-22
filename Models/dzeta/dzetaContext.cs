using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace mD_WPF_chSheet_01.Models.dzeta
{
    public partial class dzetaContext : DbContext
    {
        public dzetaContext()
        {
        }

        public dzetaContext(DbContextOptions<dzetaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abilitybonus> Abilitybonus { get; set; }
        public virtual DbSet<Characters> Characters { get; set; }
        public virtual DbSet<Charactersskills> Charactersskills { get; set; }
        public virtual DbSet<Charisms> Charisms { get; set; }
        public virtual DbSet<Dexteritys> Dexteritys { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Intuitions> Intuitions { get; set; }
        public virtual DbSet<Races> Races { get; set; }
        public virtual DbSet<Racesskills> Racesskills { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Vitalitys> Vitalitys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=dzeta;uid=root");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abilitybonus>(entity =>
            {
                entity.ToTable("abilitybonus");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbilityValue).HasColumnType("int(11)");

                entity.Property(e => e.Active).HasColumnType("int(11)");

                entity.Property(e => e.Passive).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Characters>(entity =>
            {
                entity.ToTable("characters");

                entity.HasIndex(e => e.RaceId)
                    .HasName("RaceId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Agility).HasColumnType("int(11)");

                entity.Property(e => e.Appearance).HasColumnType("int(11)");

                entity.Property(e => e.Charisma).HasColumnType("int(11)");

                entity.Property(e => e.Dexterity).HasColumnType("int(11)");

                entity.Property(e => e.Endurance).HasColumnType("int(11)");

                entity.Property(e => e.Influence).HasColumnType("int(11)");

                entity.Property(e => e.Intelligence).HasColumnType("int(11)");

                entity.Property(e => e.Intuition).HasColumnType("int(11)");

                entity.Property(e => e.Luck).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Perception).HasColumnType("int(11)");

                entity.Property(e => e.Quickness).HasColumnType("int(11)");

                entity.Property(e => e.RaceId).HasColumnType("int(11)");

                entity.Property(e => e.Resourcefull).HasColumnType("int(11)");

                entity.Property(e => e.SkillId).HasColumnType("int(11)");

                entity.Property(e => e.Strength).HasColumnType("int(11)");

                entity.Property(e => e.Toughtness).HasColumnType("int(11)");

                entity.Property(e => e.Vitality).HasColumnType("int(11)");

                entity.Property(e => e.Wisdom).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Charactersskills>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("charactersskills");

                entity.HasIndex(e => e.CharacterId)
                    .HasName("CharacterId");

                entity.HasIndex(e => e.SkillId)
                    .HasName("SkillId");

                entity.Property(e => e.CharacterId).HasColumnType("int(11)");

                entity.Property(e => e.SkillId).HasColumnType("int(11)");

                entity.HasOne(d => d.Character)
                    .WithMany()
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("charactersskills_ibfk_5");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("charactersskills_ibfk_6");
            });

            modelBuilder.Entity<Charisms>(entity =>
            {
                entity.ToTable("charisms");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AppearanceDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AppearanceMax).HasColumnType("int(11)");

                entity.Property(e => e.AppearanceMin).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.InfluenceDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.InfluenceMax).HasColumnType("int(11)");

                entity.Property(e => e.InfluenceMin).HasColumnType("int(11)");

                entity.Property(e => e.LuckDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LuckMax).HasColumnType("int(11)");

                entity.Property(e => e.LuckMin).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Dexteritys>(entity =>
            {
                entity.ToTable("dexteritys");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgilityDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AgilityMax).HasColumnType("int(11)");

                entity.Property(e => e.AgilityMin).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PerceptionDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PerceptionMax).HasColumnType("int(11)");

                entity.Property(e => e.PerceptionMin).HasColumnType("int(11)");

                entity.Property(e => e.QuicknessDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.QuicknessMax).HasColumnType("int(11)");

                entity.Property(e => e.QuicknessMin).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Intuitions>(entity =>
            {
                entity.ToTable("intuitions");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IntelligenceDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IntelligenceMax).HasColumnType("int(11)");

                entity.Property(e => e.IntelligenceMin).HasColumnType("int(11)");

                entity.Property(e => e.ResourcefullDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ResourcefullMax).HasColumnType("int(11)");

                entity.Property(e => e.ResourcefullMin).HasColumnType("int(11)");

                entity.Property(e => e.WisdomDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.WisdomMax).HasColumnType("int(11)");

                entity.Property(e => e.WisdomMin).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Races>(entity =>
            {
                entity.ToTable("races");

                entity.HasIndex(e => e.CharismaId)
                    .HasName("CharismaId");

                entity.HasIndex(e => e.DexterityId)
                    .HasName("DexterityId");

                entity.HasIndex(e => e.IntuitionId)
                    .HasName("IntuitionId");

                entity.HasIndex(e => e.VitalityId)
                    .HasName("VitalityId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharismaId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.DexterityId).HasColumnType("int(11)");

                entity.Property(e => e.Gender)
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.IntuitionId).HasColumnType("int(11)");

                entity.Property(e => e.RaceName)
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.VitalityId).HasColumnType("int(11)");

                entity.HasOne(d => d.Charisma)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.CharismaId)
                    .HasConstraintName("races_ibfk_10");

                entity.HasOne(d => d.Dexterity)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.DexterityId)
                    .HasConstraintName("races_ibfk_11");

                entity.HasOne(d => d.Intuition)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.IntuitionId)
                    .HasConstraintName("races_ibfk_13");

                entity.HasOne(d => d.Vitality)
                    .WithMany(p => p.Races)
                    .HasForeignKey(d => d.VitalityId)
                    .HasConstraintName("races_ibfk_12");
            });

            modelBuilder.Entity<Racesskills>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("racesskills");

                entity.HasIndex(e => e.RaceId)
                    .HasName("RaceId");

                entity.HasIndex(e => e.SkillId)
                    .HasName("SkillId");

                entity.Property(e => e.RaceId).HasColumnType("int(11)");

                entity.Property(e => e.SkillId).HasColumnType("int(11)");

                entity.HasOne(d => d.Race)
                    .WithMany()
                    .HasForeignKey(d => d.RaceId)
                    .HasConstraintName("racesskills_ibfk_3");

                entity.HasOne(d => d.Skill)
                    .WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .HasConstraintName("racesskills_ibfk_2");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.ToTable("skills");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.SkillClass)
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SkillCost).HasColumnType("int(11)");

                entity.Property(e => e.SkillName)
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Vitalitys>(entity =>
            {
                entity.ToTable("vitalitys");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EnduranceDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.EnduranceMax).HasColumnType("int(11)");

                entity.Property(e => e.EnduranceMin).HasColumnType("int(11)");

                entity.Property(e => e.StrengthDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.StrengthMax).HasColumnType("int(11)");

                entity.Property(e => e.StrengthMin).HasColumnType("int(11)");

                entity.Property(e => e.ToughtnessDescription)
                    .HasColumnType("text")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ToughtnessMax).HasColumnType("int(11)");

                entity.Property(e => e.ToughtnessMin).HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
