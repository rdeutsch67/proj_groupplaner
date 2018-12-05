using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Template_Angular7.ViewModels;

namespace Template_Angular7.Data
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion Constructor
        
        #region Methods
        protected override void OnModelCreating(ModelBuilder
            modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("TUsers");
            modelBuilder.Entity<ApplicationUser>().HasMany(u => u.Gruppen).WithOne(i => i.User);
            
            modelBuilder.Entity<Gruppe>().ToTable("TGruppen");
            modelBuilder.Entity<Gruppe>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Gruppe>().HasOne(i => i.User).WithMany(u => u.Gruppen);
            modelBuilder.Entity<Gruppe>().HasMany(i => i.CodesAktivitaeten).WithOne(u => u.Gruppe);
            modelBuilder.Entity<Gruppe>().HasMany(i => i.Teilnehmer).WithOne(u => u.Gruppe);
            
            modelBuilder.Entity<CodeAktivitaeten>().ToTable("TAktivitaeten");
            modelBuilder.Entity<CodeAktivitaeten>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CodeAktivitaeten>().HasOne(i => i.Gruppe).WithMany(u => u.CodesAktivitaeten);
            
            modelBuilder.Entity<Teilnehmer>().ToTable("TTeilnehmer");
            modelBuilder.Entity<Teilnehmer>().Property(i => i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Teilnehmer>().HasOne(i => i.Gruppe).WithMany(u => u.Teilnehmer);
            
            /*modelBuilder.Entity<ApplicationUser>().HasMany(u =>
                u.Quizzes).WithOne(i => i.User);
            modelBuilder.Entity<Quiz>().ToTable("Quizzes");
            modelBuilder.Entity<Quiz>().Property(i =>
                i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Quiz>().HasOne(i => i.User).WithMany(u
                => u.Quizzes);
            modelBuilder.Entity<Quiz>().HasMany(i =>
                i.Questions).WithOne(c => c.Quiz);
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Question>().Property(i =>
                i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>().HasOne(i =>
                i.Quiz).WithMany(u => u.Questions);
            modelBuilder.Entity<Question>().HasMany(i =>
                i.Answers).WithOne(c => c.Question);
            modelBuilder.Entity<Answer>().ToTable("Answers");
            modelBuilder.Entity<Answer>().Property(i =>
                i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Answer>().HasOne(i =>
                i.Question).WithMany(u => u.Answers);
            modelBuilder.Entity<Result>().ToTable("Results");
            modelBuilder.Entity<Result>().Property(i =>
                i.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Result>().HasOne(i =>
                i.Quiz).WithMany(u => u.Results);*/
        }
        #endregion Methods
        
        #region Properties
        public DbSet<ApplicationUser> Benutzer { get; set; }
        public DbSet<Gruppe> Gruppen { get; set; }
        public DbSet<CodeAktivitaeten> CodesAktivitaeten { get; set; }
        public DbSet<Teilnehmer> Teilnehmer { get; set; }
        #endregion Properties
    }
}