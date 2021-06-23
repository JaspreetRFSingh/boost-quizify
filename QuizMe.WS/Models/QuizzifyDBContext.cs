using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QuizMe.WS.Models
{
    public partial class QuizzifyDBContext : DbContext
    {
        public QuizzifyDBContext()
        {
        }

        public QuizzifyDBContext(DbContextOptions<QuizzifyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Quiz> Quizzes { get; set; }
        public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Quizzify;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DifficultyLevel>(entity =>
            {
                entity.ToTable("DifficultyLevel");

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Options).IsUnicode(false);

                entity.HasOne(d => d.DifficultyLevel)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.DifficultyLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_DifficultyLevel");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.HasIndex(e => new { e.MaxDifficulty, e.QuestionsCount }, "IX_Quiz")
                    .IsUnique();

                entity.HasOne(d => d.MaxDifficultyNavigation)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.MaxDifficulty)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_DifficultyLevel");
            });

            modelBuilder.Entity<QuizQuestion>(entity =>
            {
                entity.ToTable("Quiz_Question");

                entity.HasIndex(e => new { e.QuestionId, e.QuizId, e.QuizQuestionId }, "IX_Quiz_Question")
                    .IsUnique();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_Question_Question");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.QuizQuestions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_Question_Quiz");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
