using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CareerX.Models;

public partial class CareerxDbContext : DbContext
{
    public CareerxDbContext()
    {
    }

    public CareerxDbContext(DbContextOptions<CareerxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<CompanyAdmin> CompanyAdmins { get; set; }

    public virtual DbSet<Hiringmanager> Hiringmanagers { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<JobApplication> JobApplications { get; set; }

    public virtual DbSet<JobCategory> JobCategories { get; set; }

    public virtual DbSet<JobPost> JobPosts { get; set; }

    public virtual DbSet<JobSeeker> JobSeekers { get; set; }

    public virtual DbSet<JobSeekerProfile> JobSeekerProfiles { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Resume> Resumes { get; set; }

    public virtual DbSet<SavedJob> SavedJobs { get; set; }

    public virtual DbSet<SignUpRequest> SignUpRequests { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SystemUser> SystemUsers { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=priyanka;Initial Catalog=careerxDB;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuthUser__3214EC075703E5DA");

            entity.ToTable("AuthUser");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<CompanyAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyU__3214EC07F51AD195");

            entity.ToTable("CompanyAdmin");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.LegalName).HasMaxLength(255);
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.Industry).WithMany(p => p.CompanyAdmins)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobProviderCompany_Industry");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.CompanyAdmins)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobProviderCompany_Location");
        });

        modelBuilder.Entity<Hiringmanager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HIRINGMA__3214EC27CA1CF833");

            entity.ToTable("HIRINGMANAGER");

            entity.HasIndex(e => e.Email, "UC_Email2").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.Hiringmanagers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_JobProviderCompany_CompId");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Industry__3214EC077E2F96AF");

            entity.ToTable("Industry");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobAppli__3214EC07E30BC7FA");

            entity.ToTable("JobApplication");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Datesubmitted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.JobPostId).HasColumnName("JobPost_id");

            entity.HasOne(d => d.ApplicantNavigation).WithMany(p => p.JobApplications)
                .HasForeignKey(d => d.Applicant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobApplication_Applicant");

            entity.HasOne(d => d.JobPost).WithMany(p => p.JobApplications)
                .HasForeignKey(d => d.JobPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobApplication_JobPost");

            entity.HasOne(d => d.Resume).WithMany(p => p.JobApplications)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobApplication_Resume");
        });

        modelBuilder.Entity<JobCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobCateg__3214EC076CE72D52");

            entity.ToTable("JobCategory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobPost__3214EC070C2B20D9");

            entity.ToTable("JobPost");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.PostedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_JobCategory");

            entity.HasOne(d => d.Company).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Company");

            entity.HasOne(d => d.Industry).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Industry");

            entity.HasOne(d => d.Location).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Location");

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_PostedBy");

            entity.HasOne(d => d.Qualification).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.QualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Qualification");

            entity.HasOne(d => d.Skill).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPost_Skill");
        });

        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSeeke__3214EC070DB9408E");

            entity.ToTable("JobSeeker");

            entity.HasIndex(e => e.Email, "UC_Email").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSeeke__3214EC076898F1DB");

            entity.ToTable("JobSeekerProfile");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ProfileName).HasMaxLength(255);

            entity.HasOne(d => d.JobSeeker).WithMany(p => p.JobSeekerProfiles)
                .HasForeignKey(d => d.JobSeekerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobSeekerProfile_JobSeeker");

            entity.HasMany(d => d.Skills).WithMany(p => p.JobSeekerProfiles)
                .UsingEntity<Dictionary<string, object>>(
                    "JobSeekerProfileSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_JobSeekerProfileSkill_Skill"),
                    l => l.HasOne<JobSeekerProfile>().WithMany()
                        .HasForeignKey("JobSeekerProfileId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_JobSeekerProfileSkill_JobSeekerProfile"),
                    j =>
                    {
                        j.HasKey("JobSeekerProfileId", "SkillId").HasName("PK__JobSeeke__C66959E4FDDB6DCF");
                        j.ToTable("JobSeekerProfileSkill");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC0725C2DDDE");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qualific__3214EC070EF2A493");

            entity.ToTable("Qualification");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resume__3214EC07751B1A58");

            entity.ToTable("Resume");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateUploaded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.FileType).HasMaxLength(50);

            entity.HasOne(d => d.JobSeekerProfile).WithMany(p => p.Resumes)
                .HasForeignKey(d => d.JobSeekerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resume_JobSeekerProfile");
        });

        modelBuilder.Entity<SavedJob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SavedJob__3214EC07DBA4B396");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateSaved)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.JobNavigation).WithMany(p => p.SavedJobs)
                .HasForeignKey(d => d.Job)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SavedJobs_Job");

            entity.HasOne(d => d.SavedByNavigation).WithMany(p => p.SavedJobs)
                .HasForeignKey(d => d.SavedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SavedJobs_JobSeeker");
        });

        modelBuilder.Entity<SignUpRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SignUpRe__3214EC07BE4F8527");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3214EC073078FB09");

            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<SystemUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__systemUs__3214EC07AEF0A724");

            entity.ToTable("systemUser");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__WorkExpe__3214EC072D800515");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.ServiceEnd).HasColumnType("datetime");
            entity.Property(e => e.ServiceStart).HasColumnType("datetime");

            entity.HasOne(d => d.JobSeekerProfile).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.JobSeekerProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkExperience_JobSeekerProfile");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
