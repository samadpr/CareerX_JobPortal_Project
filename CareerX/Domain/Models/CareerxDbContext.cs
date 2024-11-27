using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models;

public partial class CareerxDbContext : DbContext
{
    public CareerxDbContext(DbContextOptions<CareerxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUser> AuthUsers { get; set; }

    public virtual DbSet<CompanyAdmin> CompanyAdmins { get; set; }

    public virtual DbSet<HiringManager> HiringManagers { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=priyanka;Initial Catalog=DB_CareerX;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  //{
    //    modelBuilder.Entity<AuthUser>(entity =>
    //    {
    //        entity.HasKey(e => e.Id).HasName("PK__AuthUser__3214EC07D513CE6E");

    //        entity.ToTable("AuthUser");

    //        entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
    //        entity.Property(e => e.Password).HasMaxLength(255);
    //    });

        modelBuilder.Entity<CompanyAdmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CompanyA__3214EC0745D4C12C");

            entity.ToTable("CompanyAdmin");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.LegalName).HasMaxLength(255);
            entity.Property(e => e.Website).HasMaxLength(255);

            entity.HasOne(d => d.Industry).WithMany(p => p.CompanyAdmins)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyAdmin_Industry");

            entity.HasOne(d => d.LocationNavigation).WithMany(p => p.CompanyAdmins)
                .HasForeignKey(d => d.Location)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompanyAdmin_Location");
        });

        modelBuilder.Entity<HiringManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HiringMa__3214EC0718E6366B");

            entity.ToTable("HiringManager");

            entity.HasIndex(e => e.Email, "UQ__HiringMa__A9D10534F09AB67E").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.Company).WithMany(p => p.HiringManagers)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_HiringManager_CompanyAdmin");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Industry__3214EC072DDCCCC8");

            entity.ToTable("Industry");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Intervie__3214EC07F5413196");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Application).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__Interview__Appli__07C12930");

            entity.HasOne(d => d.Company).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interview__Compa__09A971A2");

            entity.HasOne(d => d.IntervieweeNavigation).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.Interviewee)
                .HasConstraintName("FK__Interview__Inter__06CD04F7");

            entity.HasOne(d => d.Job).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__Interview__JobId__05D8E0BE");

            entity.HasOne(d => d.ScheduledByNavigation).WithMany(p => p.Interviews)
                .HasForeignKey(d => d.ScheduledBy)
                .HasConstraintName("FK__Interview__Sched__08B54D69");
        });

        modelBuilder.Entity<JobApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobAppli__3214EC0777659508");

            entity.ToTable("JobApplication");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DateSubmitted)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

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
            entity.HasKey(e => e.Id).HasName("PK__JobCateg__3214EC07783007E5");

            entity.ToTable("JobCategory");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<JobPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobPosts__3214EC072487B189");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.PostedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Category");

            entity.HasOne(d => d.Company).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Company");

            entity.HasOne(d => d.Industry).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Industry");

            entity.HasOne(d => d.Location).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Location");

            entity.HasOne(d => d.PostedByNavigation).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.PostedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_PostedBy");

            entity.HasOne(d => d.Qualification).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.QualificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Qualification");

            entity.HasOne(d => d.Skill).WithMany(p => p.JobPosts)
                .HasForeignKey(d => d.SkillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobPosts_Skill");
        });

        modelBuilder.Entity<JobSeeker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSeeke__3214EC07478DBF8D");

            entity.ToTable("JobSeeker");

            entity.HasIndex(e => e.Email, "UQ__JobSeeke__A9D10534039B4590").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<JobSeekerProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JobSeeke__3214EC070C013632");

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
                        j.HasKey("JobSeekerProfileId", "SkillId").HasName("PK__JobSeeke__C66959E4A3925978");
                        j.ToTable("JobSeekerProfileSkill");
                    });
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07432A7873");

            entity.ToTable("Location");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Qualific__3214EC0779AAB97E");

            entity.ToTable("Qualification");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Resume>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Resume__3214EC0748B6B243");

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
            entity.HasKey(e => e.Id).HasName("PK__SavedJob__3214EC073D2C3B15");

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
            entity.HasKey(e => e.Id).HasName("PK__SignUpRe__3214EC0700B92B55");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3214EC079F28E3DD");

            entity.ToTable("Skill");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
